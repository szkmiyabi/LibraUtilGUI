namespace LibraUtilGUI
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.appMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuList = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.appMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // appMenu
            // 
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuList});
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(392, 24);
            this.appMenu.TabIndex = 1;
            this.appMenu.Text = "menuStrip1";
            // 
            // FileMenuList
            // 
            this.FileMenuList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuSettings});
            this.FileMenuList.Name = "FileMenuList";
            this.FileMenuList.Size = new System.Drawing.Size(53, 20);
            this.FileMenuList.Text = "ファイル";
            // 
            // FileMenuSettings
            // 
            this.FileMenuSettings.Name = "FileMenuSettings";
            this.FileMenuSettings.Size = new System.Drawing.Size(152, 22);
            this.FileMenuSettings.Text = "環境設定";
            this.FileMenuSettings.Click += new System.EventHandler(this.FileMenuSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSettings;
    }
}

