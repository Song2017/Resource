using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.ComponentModel;
using NLog;
using System.Runtime.InteropServices;

namespace VssConfigFileCleaner
{
    public partial class Clearner : Form
    {
        //禁用启用窗口
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelControl = new DevExpress.XtraWaitForm.ProgressPanel();


        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Clearner()
        {
            //git test
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        delegate void AddLogDelegate(string log);
        private void AddLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new AddLogDelegate(AddLog), log);
            }
            else
            {
                string show = String.Format("{0} {1}", DateTime.Now.ToString(), log);
                listLog.Items.Add(show);
                listLog.SelectedIndex = listLog.Items.Count - 1;

                logger.Info(show);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //AddLog(" btnClear_Click 开始");
            btnClear.Enabled = false;
            listLog.Items.Clear();

            //初始化数据
            string path = this.txtPath.Text.Trim();

            //数据校验
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择要清理的目录！");
                this.txtPath.Focus();
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("您选择的路径不存在！");
                this.txtPath.Focus();
                this.txtPath.SelectAll();
                return;
            }

            //git pull test
            DoClear(path);
        }

        private void DoClear(string path)
        {
            this.BeginWait();
            BackgroundWorker bwCleanVssFile = new BackgroundWorker();
            //定义需要在子线程中干的事情
            bwCleanVssFile.DoWork += new DoWorkEventHandler(bwCleanVssFile_DoWork);
            //定义执行完毕后需要做的事情
            bwCleanVssFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwCleanVssFile_RunWorkerCompleted);
            //开始执行
            bwCleanVssFile.RunWorkerAsync(path);
           
            this.BeginWait();
            BackgroundWorker bwDeleteBinDirectory = new BackgroundWorker();
            //定义需要在子线程中干的事情
            bwDeleteBinDirectory.DoWork += new DoWorkEventHandler(bwDeleteBinDirectory_DoWork);
            //定义执行完毕后需要做的事情
            bwDeleteBinDirectory.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwDeleteBinDirectory_RunWorkerCompleted);
            //开始执行
            bwDeleteBinDirectory.RunWorkerAsync(path);
           
            this.BeginWait();
            BackgroundWorker bwRemoveVssTag = new BackgroundWorker();
            //定义需要在子线程中干的事情
            bwRemoveVssTag.DoWork += new DoWorkEventHandler(bwRemoveVssTag_DoWork);
            //定义执行完毕后需要做的事情
            bwRemoveVssTag.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwRemoveVssTag_RunWorkerCompleted);
            //开始执行
            bwRemoveVssTag.RunWorkerAsync(path);
        }

        void bwCleanVssFile_DoWork(object sender, DoWorkEventArgs e)
        {

            //AddLog(" bwCleanVssFile_DoWork 开始");
            string path = e.Argument.ToString();
            int deletedFileCount = 0;

            try
            {
                lock (path)
                {
                    deletedFileCount = CleanVssFile(path);
                }
            }
            catch (Exception ex)
            {
                logger.Error("ERROR: {0}", ex);
            }
            CleanResult result = new CleanResult();
            result.DeletedFileCount = deletedFileCount;
            e.Result = result;
            //AddLog(" bwCleanVssFile_DoWork 结束");
        }

        void bwCleanVssFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //AddLog(" bwCleanVssFile_RunWorkerCompleted 开始");
            CleanResult result = (CleanResult)e.Result;
            string msg;
            msg = String.Format("Vss文件清理成功，共清理了{0}个文件！", result.DeletedFileCount.ToString());
            AddLog(msg);

            btnClear.Enabled = true;
            //AddLog(" bwCleanVssFile_RunWorkerCompleted 结束");
            this.EndWait();
        }

        void bwDeleteBinDirectory_DoWork(object sender, DoWorkEventArgs e)
        {

            //AddLog(" bwDeleteBinDirectory_DoWork 开始");
            string path = e.Argument.ToString();
            int deletedDirectoryCount;
            lock (path)
            {
                // 删除bin和obj目录
                deletedDirectoryCount = DeleteBinAndObjDirectory(path);
            }

            CleanResult result = new CleanResult();
            result.DeletedDirectoryCount = deletedDirectoryCount;
            e.Result = result;
            //AddLog(" bwDeleteBinDirectory_DoWork 结束");
        }

        void bwDeleteBinDirectory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //AddLog(" bwDeleteBinDirectory_RunWorkerCompleted 开始");
            CleanResult result = (CleanResult)e.Result;
            string msg;
            msg = String.Format("Bin和Obj目录清理成功，共清理了{0}个目录！", result.DeletedDirectoryCount.ToString());
            AddLog(msg);

            btnClear.Enabled = true;
            //AddLog(" bwDeleteBinDirectory_RunWorkerCompleted 结束");
            EndWait();
        }

        void bwRemoveVssTag_DoWork(object sender, DoWorkEventArgs e)
        {

            //AddLog(" bwRemoveVssTag_DoWork 开始");
            string path = e.Argument.ToString();
            int removeVssTagFileCount;
            lock (path)
            {
                removeVssTagFileCount = RemoveVssTag(path);
            }
            CleanResult result = new CleanResult();
            result.RemoveVssTagFileCount = removeVssTagFileCount;
            e.Result = result;
            //AddLog(" bwRemoveVssTag_DoWork 结束");
        }

        void bwRemoveVssTag_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //AddLog(" bwRemoveVssTag_RunWorkerCompleted 开始");
            CleanResult result = (CleanResult)e.Result;
            string msg;
            msg = String.Format("VSS标记内容清理成功，共清理了{0}个文件！", result.RemoveVssTagFileCount.ToString());
            AddLog(msg);

            btnClear.Enabled = true;
            //AddLog(" bwRemoveVssTag_RunWorkerCompleted 结束");
            EndWait();
        }

        private int DeleteBinAndObjDirectory(string path)
        {
            //AddLog(" DeleteBinAndObjDirectory 开始");
            //删除目录数量
            int deletedDirectoryCount = 0;

            deletedDirectoryCount += IOHelper.DeleteDirectorys(path, "bin");
            deletedDirectoryCount += IOHelper.DeleteDirectorys(path, "obj");

            //AddLog(" DeleteBinAndObjDirectory 结束");
            return deletedDirectoryCount;
        }

        private int CleanVssFile(string path)
        {
            //AddLog(" CleanVssFile 开始");
            //删除文件数量
            int deletedFileCount = 0;

            string[] arrFileSearchPattern = new string[]{
                    "*.vssscc",
                    "*.scc",
                    "*.vspscc",
                    "*.user",
                    "*.pdsync",
                    "*.pdsyncu"
                };
            foreach (string pattern in arrFileSearchPattern)
            {
                deletedFileCount += IOHelper.DeleteFiles(path, pattern);
            }

            //AddLog(" CleanVssFile 结束");
            return deletedFileCount;
        }

        /// <summary>
        /// 去除"*.sln"解决方案文件和"*.csproj"C#项目文件的.Vss关联标签。
        /// </summary>
        /// <param name="path">当前处理路径</param>
        private int RemoveVssTag(string path)
        {
            //AddLog(" RemoveVssTag 开始");
            int count = 0;
            count = IOHelper.RemoveContents(path, "*.sln", "GlobalSection(SourceCodeControl)", "EndGlobalSection");

            count += IOHelper.RemoveFileContents(path, "*.csproj", @"<SccProjectName>[\w*\W*\s*\S*]*</SccProvider>");

            string[] removeStrings = new string[] { 
                "\"SccProjectName\" = \"8:SAK\"",
                "\"SccLocalPath\" = \"8:SAK\"",
                "\"SccAuxPath\" = \"8:SAK\"",
                "\"SccProvider\" = \"8:SAK\""
            };
            count += IOHelper.RemoveContents(path, "*.vdproj", removeStrings);

            //AddLog(" RemoveVssTag 结束");
            return count;
        }


        //等待控件
        private void BeginWait()
        {
            if (progressPanelControl == null)
                progressPanelControl = new DevExpress.XtraWaitForm.ProgressPanel();
            progressPanelControl.Name = "progressPanel";
            //ProgressPanelControl.BackColor = Color.Transparent;
            progressPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //ProgressPanelControl.ShowCaption = false;
            progressPanelControl.Description = "请等待……";
            progressPanelControl.Size = new System.Drawing.Size(246, 36);
            progressPanelControl.Location = new System.Drawing.Point(this.Width / 2 - progressPanelControl.Width / 2, this.Height / 2 - progressPanelControl.Height / 2);
            this.Controls.Add(progressPanelControl);
            progressPanelControl.BringToFront();
            EnableWindow(this.Handle, false);
        }
        private void EndWait()
        {
            if (progressPanelControl != null)
            {
                progressPanelControl.Dispose();
                progressPanelControl = null;
            }
            EnableWindow(this.Handle, true);
        }



    }






    public class CleanResult
    {
        public int DeletedFileCount { get; set; }
        public int DeletedDirectoryCount { get; set; }
        public int RemoveVssTagFileCount { get; set; }
    }
}
