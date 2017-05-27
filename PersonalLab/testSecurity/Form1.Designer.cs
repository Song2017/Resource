namespace testSecurity
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBefore = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAfter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDecode = new DevExpress.XtraEditors.TextEdit();
            this.btnEncode = new DevExpress.XtraEditors.SimpleButton();
            this.btnDecode = new DevExpress.XtraEditors.SimpleButton();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtBefore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBefore
            // 
            this.txtBefore.Location = new System.Drawing.Point(103, 34);
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.Size = new System.Drawing.Size(156, 22);
            this.txtBefore.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "加密前字段";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "加密后字段";
            // 
            // txtAfter
            // 
            this.txtAfter.Location = new System.Drawing.Point(103, 62);
            this.txtAfter.Name = "txtAfter";
            this.txtAfter.Size = new System.Drawing.Size(156, 22);
            this.txtAfter.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "解密后字段";
            // 
            // txtDecode
            // 
            this.txtDecode.Location = new System.Drawing.Point(103, 90);
            this.txtDecode.Name = "txtDecode";
            this.txtDecode.Size = new System.Drawing.Size(156, 22);
            this.txtDecode.TabIndex = 4;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(12, 138);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 6;
            this.btnEncode.Text = "Encode";
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(116, 138);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 7;
            this.btnDecode.Text = "Decode";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(103, 6);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 22);
            this.txtKey.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 14);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "加密KEY";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 262);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDecode);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtAfter);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBefore);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtBefore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBefore;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAfter;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDecode;
        private DevExpress.XtraEditors.SimpleButton btnEncode;
        private DevExpress.XtraEditors.SimpleButton btnDecode;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}

