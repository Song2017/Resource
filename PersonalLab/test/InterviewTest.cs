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
    public partial class InterviewTest : Form
    {
        //测试面试题
        //1 const变量可以参与初始化
        private const int i = 3;
        private const int i2 = i + 3;

        public InterviewTest()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            int j = i + 3;
            int j0 = 0;
            //2 throw 可以直接抛出exception,不需要专门声明
            try
            {
             //   j = 1 / j0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                j = 1 / j0;
            }
            catch
            {
                throw ;
            }
        }
    }
}
