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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cancelOperationButton = new System.Windows.Forms.Button();
            this.doOperationButton = new System.Windows.Forms.Button();
            this.preOperationButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.appMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 41);
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
            this.appMenu.Size = new System.Drawing.Size(587, 24);
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
            this.FileMenuSettings.Size = new System.Drawing.Size(122, 22);
            this.FileMenuSettings.Text = "環境設定";
            this.FileMenuSettings.Click += new System.EventHandler(this.FileMenuSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.projectIDListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "サイト";
            // 
            // projectIDListBox
            // 
            this.projectIDListBox.FormattingEnabled = true;
            this.projectIDListBox.ItemHeight = 12;
            this.projectIDListBox.Location = new System.Drawing.Point(3, 15);
            this.projectIDListBox.Name = "projectIDListBox";
            this.projectIDListBox.ScrollAlwaysVisible = true;
            this.projectIDListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.projectIDListBox.Size = new System.Drawing.Size(239, 88);
            this.projectIDListBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pageIDListBox);
            this.groupBox2.Location = new System.Drawing.Point(266, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ページID";
            // 
            // pageIDListBox
            // 
            this.pageIDListBox.FormattingEnabled = true;
            this.pageIDListBox.ItemHeight = 12;
            this.pageIDListBox.Location = new System.Drawing.Point(6, 15);
            this.pageIDListBox.Name = "pageIDListBox";
            this.pageIDListBox.ScrollAlwaysVisible = true;
            this.pageIDListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.pageIDListBox.Size = new System.Drawing.Size(203, 76);
            this.pageIDListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cancelOperationButton);
            this.groupBox3.Controls.Add(this.doOperationButton);
            this.groupBox3.Controls.Add(this.preOperationButton);
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(12, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 133);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "オペレーション";
            // 
            // cancelOperationButton
            // 
            this.cancelOperationButton.Location = new System.Drawing.Point(479, 100);
            this.cancelOperationButton.Name = "cancelOperationButton";
            this.cancelOperationButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOperationButton.TabIndex = 4;
            this.cancelOperationButton.Text = "キャンセル";
            this.cancelOperationButton.UseVisualStyleBackColor = true;
            // 
            // doOperationButton
            // 
            this.doOperationButton.Location = new System.Drawing.Point(479, 71);
            this.doOperationButton.Name = "doOperationButton";
            this.doOperationButton.Size = new System.Drawing.Size(75, 23);
            this.doOperationButton.TabIndex = 3;
            this.doOperationButton.Text = "実行";
            this.doOperationButton.UseVisualStyleBackColor = true;
            // 
            // preOperationButton
            // 
            this.preOperationButton.Location = new System.Drawing.Point(479, 37);
            this.preOperationButton.Name = "preOperationButton";
            this.preOperationButton.Size = new System.Drawing.Size(75, 23);
            this.preOperationButton.TabIndex = 2;
            this.preOperationButton.Text = "事前処理";
            this.preOperationButton.UseVisualStyleBackColor = true;
            this.preOperationButton.Click += new System.EventHandler(this.preOperationButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(470, 112);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(462, 86);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "URL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(462, 86);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(462, 86);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PRESV";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(462, 86);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "SRC";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(587, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.operationStatusReport);
            this.groupBox4.Location = new System.Drawing.Point(12, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 100);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "処理状況";
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationStatusReport.Location = new System.Drawing.Point(3, 15);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(554, 82);
            this.operationStatusReport.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 429);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.Name = "Form1";
            this.Text = "LibraUtilGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox projectIDListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox pageIDListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cancelOperationButton;
        private System.Windows.Forms.Button doOperationButton;
        private System.Windows.Forms.Button preOperationButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox operationStatusReport;
    }
}

