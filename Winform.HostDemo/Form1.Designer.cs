namespace Winform.HostDemo
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGet = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtMessageLog = new System.Windows.Forms.RichTextBox();
            this.btnWebApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGet.Location = new System.Drawing.Point(657, 77);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(127, 41);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "GET";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnPost
            // 
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.Location = new System.Drawing.Point(657, 142);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(127, 41);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "POST";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtMessageLog
            // 
            this.txtMessageLog.Location = new System.Drawing.Point(12, 12);
            this.txtMessageLog.Name = "txtMessageLog";
            this.txtMessageLog.Size = new System.Drawing.Size(617, 426);
            this.txtMessageLog.TabIndex = 2;
            this.txtMessageLog.Text = "";
            // 
            // btnWebApp
            // 
            this.btnWebApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWebApp.Location = new System.Drawing.Point(657, 12);
            this.btnWebApp.Name = "btnWebApp";
            this.btnWebApp.Size = new System.Drawing.Size(127, 41);
            this.btnWebApp.TabIndex = 0;
            this.btnWebApp.Text = "Start WebAPI";
            this.btnWebApp.UseVisualStyleBackColor = true;
            this.btnWebApp.Click += new System.EventHandler(this.btnWebApp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMessageLog);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnWebApp);
            this.Controls.Add(this.btnGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.RichTextBox txtMessageLog;
        private System.Windows.Forms.Button btnWebApp;
    }
}

