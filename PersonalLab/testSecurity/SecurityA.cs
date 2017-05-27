using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace testSecurity
{
    public class SecurityA
    {
        //extern修饰符支持在外部实现方法
        //外部修饰符的常见方法是在使用Interop 服务调入非托管代码时与 DllImport 属性一起使用；
        //方法还必须声明为 static
        [DllImport("securityA.dll")]
        static extern IntPtr DeCode(IntPtr source, IntPtr key);
        [DllImport("securityA.dll")]
        static extern IntPtr EnCode(IntPtr source, IntPtr key);

        public string enCrypt(string source,string key) 
        {
            string output = string.Empty;
            try 
            {
                //转换为基本类型 IntPtr: 用于表示指针或句柄的平台特定类型。
                IntPtr ptrIn = Marshal.StringToHGlobalAnsi(source);
                IntPtr ptrInKey = Marshal.StringToHGlobalAnsi(key);
                IntPtr ptrRtn = EnCode(ptrIn, ptrInKey);
                output = Marshal.PtrToStringAnsi(ptrRtn);
            }
            catch(Exception e) 
            {
                throw e;
            }
            return output;
        }

        public string deCrypt(string source, string key)
        {
            string strRtn = string.Empty;
            try 
            {
                IntPtr ptrIn = Marshal.StringToHGlobalAnsi(source);
                IntPtr ptrInKey = Marshal.StringToHGlobalAnsi(key);
                IntPtr ptrRtn = DeCode(ptrIn, ptrInKey);
                strRtn = Marshal.PtrToStringAnsi(ptrRtn);
            }
            catch(Exception e)
            {
                throw e;
            }

            return strRtn;
        }
    }
}
