using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppJsonSerialiser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //List<string> lst = new List<string> {"123","345" };
            //string str = "123";
            //ConvertJson.ListToJson<string>(lst);

        }
    }
}
