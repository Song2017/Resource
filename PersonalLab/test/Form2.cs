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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {

            string[] t = "apple->banana->123".Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in t)
            {
                for (int v = 0; v < listBox1.Items.Count; v++)
                    if (this.listBox1.Items[v].ToString().Contains(str))
                    {
                        MessageBox.Show(string.Format("Name:'{0}' Exists!", str));
                        return;
                    }

                MessageBox.Show(string.Format("Name:'{0}' Not Exists!", str));
            }

        }
    }
}
