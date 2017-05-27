using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Init();
            //InitVariable();
            InitTestValueVariable();
        }

        private void InitTestValueVariable()
        {
            //因为值类型是存储在内存中的堆栈（以后简称栈），而引用类型的变量在栈中仅仅是存储引用类型变量的地址，而其本身则存储在堆中。
            //==操作比较的是两个变量的值是否相等，对于引用型变量表示的是两个变量在堆中存储的地址是否相同，即栈中的内容是否相同。
            //equals操作表示的两个变量是否是对同一个对象的引用，即堆中的内容是否相同。
            //string(public sealed class String)很特别,虽然是引用类型,但是值相同就会指向同一个引用,应该是因为他的密封性.
            //a,b指向同一个引用,当a或b的值修改了,才会重新分配内存
            string a = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string b = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
            //True
            //True

            object g = a;
            object h = b;
            Console.WriteLine(g == h);//栈中存的是a,b本身的地址
            Console.WriteLine(g.Equals(h));//new char[] { 'h', 'e', 'l', 'l', 'o' }
            //False
            //True

            Person p1 = new Person("jia");
            Person p2 = new Person("jia");
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Equals(p2));
            //False
            //False

            Person p3 = new Person("jia");
            Person p4 = p3;
            Console.WriteLine(p3 == p4);
            Console.WriteLine(p3.Equals(p4));
            //True
            //True
            //p4的地址和值里存的地址都和p3一致,
            p4.p = "modified";
            Console.WriteLine(p3.p);
            Console.ReadLine();
            //modified
        }



        private void InitVariable()
        {
            //验证值传递和引用传递
            //值传递 : 传递的实参的值,改变的是形参的值
            //引用传递 : 传递的实参的地址,改变的是形参的值,同时实参的值也发生改变
            int i = 5;
            Console.WriteLine(valueWrite(i));
            Console.WriteLine(i);
            ClassTest ct = new ClassTest();
            ct.itest = 5;
            Console.WriteLine(valueWrite(ct));
            Console.WriteLine(ct.itest);

            /*0
            5
            0
            0*/
        }

        private int valueWrite(ClassTest ct)
        {
            int ilocalVraiable = 0;
            ct.itest = ilocalVraiable;

            return ct.itest;
        }

        private int valueWrite(int iFormal)
        {
            int ilocalVraiable = 0;
            iFormal = ilocalVraiable;

            return iFormal;
        }









        private void Init()
        {
            memoEdit1.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)(13))
                {
                    btn.PerformClick();
                }
            };
            btn.Click += delegate
            {
                MessageBox.Show("按钮单击");
            };


        }


    }
}
