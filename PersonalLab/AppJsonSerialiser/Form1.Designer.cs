namespace AppJsonSerialiser
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
            this.memoToSerialize = new DevExpress.XtraEditors.MemoEdit();
            this.btnToSerialize = new DevExpress.XtraEditors.SimpleButton();
            this.btnSerialized = new DevExpress.XtraEditors.SimpleButton();
            this.memoSerialized = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.memoToSerialize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSerialized.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoToSerialize
            // 
            this.memoToSerialize.Location = new System.Drawing.Point(12, 12);
            this.memoToSerialize.Name = "memoToSerialize";
            this.memoToSerialize.Size = new System.Drawing.Size(251, 93);
            this.memoToSerialize.TabIndex = 0;
            this.memoToSerialize.UseOptimizedRendering = true;
            // 
            // btnToSerialize
            // 
            this.btnToSerialize.Location = new System.Drawing.Point(269, 32);
            this.btnToSerialize.Name = "btnToSerialize";
            this.btnToSerialize.Size = new System.Drawing.Size(75, 23);
            this.btnToSerialize.TabIndex = 1;
            this.btnToSerialize.Text = "Serialize";
            // 
            // btnSerialized
            // 
            this.btnSerialized.Location = new System.Drawing.Point(269, 61);
            this.btnSerialized.Name = "btnSerialized";
            this.btnSerialized.Size = new System.Drawing.Size(75, 23);
            this.btnSerialized.TabIndex = 2;
            this.btnSerialized.Text = "DeSerialize";
            // 
            // memoSerialized
            // 
            this.memoSerialized.Location = new System.Drawing.Point(350, 12);
            this.memoSerialized.Name = "memoSerialized";
            this.memoSerialized.Size = new System.Drawing.Size(251, 93);
            this.memoSerialized.TabIndex = 3;
            this.memoSerialized.UseOptimizedRendering = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 262);
            this.Controls.Add(this.memoSerialized);
            this.Controls.Add(this.btnSerialized);
            this.Controls.Add(this.btnToSerialize);
            this.Controls.Add(this.memoToSerialize);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.memoToSerialize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSerialized.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoToSerialize;
        private DevExpress.XtraEditors.SimpleButton btnToSerialize;
        private DevExpress.XtraEditors.SimpleButton btnSerialized;
        private DevExpress.XtraEditors.MemoEdit memoSerialized;
    }
}

