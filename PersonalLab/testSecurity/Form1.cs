using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitUI();
            InitLogic();
        }

        private void InitLogic()
        {
            string strKey =  string.Empty ;
            SecurityA sa = new SecurityA();

            btnEncode.Click += delegate 
            {
                //加密
                string strCode = sa.enCrypt(txtBefore.EditValue.ToString(),strKey);
                txtAfter.Text = strCode;
            };

            btnDecode.Click += delegate 
            {
                //解密
                string strCode = sa.deCrypt(txtAfter.EditValue.ToString(), strKey);
                txtDecode.Text = strCode;
            };

            txtKey.EditValueChanged += delegate {   strKey = txtKey.EditValue == null ? string.Empty : txtKey.EditValue.ToString(); };
        }

        private void InitUI()
        {
        }




    }
}
