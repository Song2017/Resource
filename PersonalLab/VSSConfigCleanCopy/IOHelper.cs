using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VssConfigFileCleaner
{
    public class IOHelper
    {
        public static int RemoveContents(string path, string filePattern, string[] removeStrings)
        {
            int count;
            var files = Directory.EnumerateFiles(path, filePattern, SearchOption.AllDirectories);
            count = files.Count();

            foreach (string file in files)
            {
                RemoveContent(file, removeStrings);
            }

            return count;
        }

        public static void RemoveContent(string filePath, string[] removeStrings)
        {           
            string content;//文件内容
            content = ReadFileContent(filePath);

            foreach (string s in removeStrings)
            {
                content = content.Replace(s, "");
            }

            WriteFile(filePath, content);
 
        }        

        public static int RemoveContents(string path, string filePattern, string start, string end)
        {
            int count;
            var files = Directory.EnumerateFiles(path, filePattern, SearchOption.AllDirectories);
            count = files.Count();
       
            foreach (string file in files)
            {
                RemoveContent(file, start, end);
            }   

            return count;
        }

        /// <summary>
        /// 移除指定文件指定内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="start">开始字符串</param>
        /// <param name="end">结束字符串</param>
        public static void RemoveContent(string filePath, string start, string end)
        {
            int startIndex;//Vss标签文本开始索引
            int endIndex;//Vss标签文本结束索引
            string content;//文件内容
            content = ReadFileContent(filePath);

            startIndex = content.IndexOf(start);
            if (startIndex != -1)//文件需要去除标签
            {
                endIndex = content.IndexOf(end, startIndex) + end.Length;
                content = content.Substring(0, startIndex) + content.Substring(endIndex);

                WriteFile(filePath, content);
            }     
        }        

        public static int RemoveFileContents(string path, string filePattern, string contentPattern)
        {
            int count;
            var files = Directory.EnumerateFiles(path, filePattern, SearchOption.AllDirectories);
            count = files.Count();

            foreach (string file in files)
            {
                RemoveFileContent(file, contentPattern);
            }

            return count;
        }

        /// <summary>
        /// 移除指定文件指定内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="pattern">正则表达式</param>
        public static void RemoveFileContent(string filePath, string pattern)
        {
            string content;

            content = ReadFileContent(filePath);

            content = Regex.Replace(content, pattern, String.Empty);

            WriteFile(filePath, content);
        }

        /// <summary>
        /// 删除指定目录下符合指定搜索字符串的所有文件
        /// </summary>
        /// <param name="directory">包含完整路径的目录名</param>
        /// <param name="searchPattern">搜索字符串，如“*.txt”</param>
        /// <returns>删除文件数量</returns>
        public static int DeleteFiles(string directory, string searchPattern)
        {
            int deletedCount;
            var files = Directory.EnumerateFiles(directory, searchPattern, SearchOption.AllDirectories);
            deletedCount = files.Count();
            
            foreach (string file in files)
            {
                DeleteFile(file);
            }            

            return deletedCount;
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="path">包含完整路径的文件名</param>
        public static void DeleteFile(string path)
        {
            File.SetAttributes(path, FileAttributes.Normal);
            File.Delete(path);
        }

        /// <summary>
        /// 删除指定目录下符合指定搜索字符串的所有子目录
        /// </summary>
        /// <param name="directory">包含完整路径的目录名</param>
        /// <param name="searchPattern">搜索字符串，如“bin”</param>
        /// <returns>删除目录数量</returns>
        public static int DeleteDirectorys(string directory, string searchPattern)
        {
            int deletedCount;
            var dirs = Directory.EnumerateDirectories(directory, searchPattern, SearchOption.AllDirectories);
            deletedCount = dirs.Count();

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }    

            return deletedCount;
        }

        /// <summary>
        /// 删除指定目录
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            DeleteFiles(path, "*.*");

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
            dirInfo.Delete(true);
        }

        public static string ReadFileContent(string filePath)
        {
            string content;
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            return content;
        }

        public static void WriteFile(string filePath, string content)
        {
            File.SetAttributes(filePath, FileAttributes.Normal);

            using (FileStream fs = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(content);
                sw.Close();
            }
        }  
    }
}
