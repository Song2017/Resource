using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using System.IO;
using System.Net;

namespace testFtp
{
    public partial class Form1 : Form
    {
        private const string FTPUserName = "ftpuser";
        private const string FTPPassword = "test2000";
        private const string FTPFloderName = "FtpTest01";
        private const string FTPRoot = "ftp://120.200.150.60";
        //文件夹首尾特殊字符
        private static readonly char[] CHARS_TRIM = new char[] { ' ', '　', '/', '\\', '\r', '\n', '\t', '\u0085', '\u00A0' };

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            btnOpen.Click += delegate
            {
                OpenFile();
            };

            btnUpload.Click += delegate
            {
                DataUpload();
            };

            btnDownLoad.Click += delegate
            {
                //下载的Stream保存到内存MemoryStream
                MemoryStream msLocalStream = DataDownload();
                //将MemoryStream保存为本地文件
                byte[] bts = msLocalStream.ToArray();
                string strpath = string.Empty;
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.AddExtension = true;
                    dialog.DefaultExt = ".txt";
                    dialog.FilterIndex = 1;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = dialog.FileName;
                        using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
                        {
                            fs.Write(bts, 0, bts.Length);
                        }
                    }
                };

                #region
                //FolderBrowserDialog较SaveFileDialog需要代码中指定文件名称
                //byte[] bts = msLocalStream.ToArray();
                //string strpath = string.Empty;
                //using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                //{
                //    if (dialog.ShowDialog() == DialogResult.OK)
                //    {
                //        strpath = dialog.SelectedPath;
                //        strpath = strpath + @"/2016.1.4.txt";
                //    }
                //};

                //using(A a = new A()){};  等价于 A a = new A(); ... a.Dispose()
                //using (FileStream fs = File.Create(strpath))
                //{
                //    fs.Write(bts, 0, bts.Length);
                //};

                //FileStream fs;
                //fs = File.Create(strpath);
                //fs.Write(bts, 0, bts.Length);
                //fs.Dispose();
                #endregion
            };
        }

        private MemoryStream DataDownload()
        {
            //组装FTP文件名全路径
            StringBuilder sbFtpFullFileName = new StringBuilder();
            string strTrimFtpRoot;
            if (!(strTrimFtpRoot = FTPRoot.Trim(CHARS_TRIM)).IsNullOrEmpty())
                sbFtpFullFileName.Append(strTrimFtpRoot).Append("/");
            string strTrimFtpFolder;
            if (!FTPFloderName.IsNullOrEmpty() && !(strTrimFtpFolder = FTPFloderName.Trim(CHARS_TRIM)).IsNullOrEmpty())
                sbFtpFullFileName.Append(strTrimFtpFolder).Append("/");
            sbFtpFullFileName.Append("2016.1.4.txt");

            //创建FTP连接请求
            FtpWebRequest ftpReqFtpRequest = (FtpWebRequest)FtpWebRequest.Create(sbFtpFullFileName.ToString().Replace("\\", "/"));
            ftpReqFtpRequest.Proxy = null;
            ftpReqFtpRequest.UseBinary = true;
            ftpReqFtpRequest.KeepAlive = false;
            ftpReqFtpRequest.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。
            ftpReqFtpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            if (!FTPUserName.IsNullOrEmpty())
                ftpReqFtpRequest.Credentials = new NetworkCredential(FTPUserName, FTPPassword);

            //下载文件
            using (FtpWebResponse fresFtpResponse = (FtpWebResponse)ftpReqFtpRequest.GetResponse())
            {
                using (Stream sFtpStream = fresFtpResponse.GetResponseStream())
                {
                    MemoryStream msLocalStream = new MemoryStream();
                    byte[] arrBuffer = new byte[1024];
                    int nReadBytes = 0;
                    while ((nReadBytes = sFtpStream.Read(arrBuffer, 0, arrBuffer.Length)) != 0)
                    {
                        msLocalStream.Write(arrBuffer, 0, nReadBytes);
                    }

                    return msLocalStream;
                }
            }
        }

        private void DataUpload()
        {
            if (txtName.EditValue.ToStringEx().IsNullOrEmpty())
                return;
            string strlocalFileName = txtName.EditValue.ToStringEx();
            FileInfo fiLocalFileInfo = new FileInfo(strlocalFileName);
            if (!fiLocalFileInfo.Exists)
            {
                MessageBox.Show("file not exists");
                return;
            }

            string strFtpFileName = Guid.NewGuid().ToString() + fiLocalFileInfo.Extension;//目标文件,文件名和扩展名

            //组装FTP文件名全路径
            StringBuilder sbFtpFullFileName = new StringBuilder();
            string strTrimFtpRoot;
            if (!(strTrimFtpRoot = FTPRoot.Trim(CHARS_TRIM)).IsNullOrEmpty())
                sbFtpFullFileName.Append(strTrimFtpRoot).Append("/");
            string strTrimFtpFolder;
            if (!FTPFloderName.IsNullOrEmpty() && !(strTrimFtpFolder = FTPFloderName.Trim(CHARS_TRIM)).IsNullOrEmpty())
                sbFtpFullFileName.Append(strTrimFtpFolder);
            CreateDirectory(sbFtpFullFileName.ToString().Replace("\\", "/"));//尝试创建文件夹
            sbFtpFullFileName.Append("/").Append(strFtpFileName);

            FtpWebRequest freqFtpRequest = (FtpWebRequest)FtpWebRequest.Create(sbFtpFullFileName.ToString().Replace("\\", "/"));
            freqFtpRequest.Proxy = null;//     获取或设置用于与 FTP 服务器通信的代理。
            freqFtpRequest.UseBinary = true;//该值指定文件传输的数据类型。
            freqFtpRequest.KeepAlive = false;//该值指定在请求完成之后是否关闭到 FTP 服务器的控制连接。
            freqFtpRequest.Method = WebRequestMethods.Ftp.UploadFile;     //     获取或设置要发送到 FTP 服务器的命令。
            freqFtpRequest.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。
            freqFtpRequest.ContentLength = fiLocalFileInfo.Length; //获取或设置被 System.Net.FtpWebRequest 类忽略的值。
            if (!FTPUserName.IsNullOrEmpty())
                freqFtpRequest.Credentials = new NetworkCredential(FTPUserName, FTPPassword);//     用指定的用户名和密码初始化 System.Net.NetworkCredential 类的新实例。

            //上传文件 通过Stream上传
            using (Stream sFtpStream = freqFtpRequest.GetRequestStream())
            {
                using (FileStream fsLocalStream = File.Open(strlocalFileName, FileMode.Open))
                {
                    byte[] arrBuffer = new byte[1024];
                    int nReadBytes = 0;
                    while ((nReadBytes = fsLocalStream.Read(arrBuffer, 0, arrBuffer.Length)) != 0)
                    {
                        sFtpStream.Write(arrBuffer, 0, nReadBytes);
                    }

                    txtFtpFileName.EditValue = strFtpFileName;//目标文件名称赋值到txtFtpFileName控件
                }
            }
        }

        //尝试创建文件夹
        private void CreateDirectory(string p)
        {
            try
            {
                FtpWebRequest freqFtpRequest = (FtpWebRequest)FtpWebRequest.Create(p);
                freqFtpRequest.Proxy = null;
                freqFtpRequest.UseBinary = true;
                freqFtpRequest.KeepAlive = false;
                freqFtpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                freqFtpRequest.ContentLength = 0;
                freqFtpRequest.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。
                if (!FTPUserName.IsNullOrEmpty())
                    freqFtpRequest.Credentials = new NetworkCredential(FTPUserName, FTPPassword);

                using (freqFtpRequest.GetResponse())
                {
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ConnectFailure)
                    throw;
            } 
        }

        //打开文件,将文件的路径/名称赋值到txtName控件
        private void OpenFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = dialog.FileName;
                    txtName.EditValue = strFileName;
                }
            };
        }
    }
}
