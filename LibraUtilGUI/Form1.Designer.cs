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
            this.projectIDGroup = new System.Windows.Forms.GroupBox();
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.projectIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDGroup = new System.Windows.Forms.GroupBox();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.operationGroup = new System.Windows.Forms.GroupBox();
            this.cancelOperationButton = new System.Windows.Forms.Button();
            this.doOperationButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.reportGroup = new System.Windows.Forms.GroupBox();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.pageIDLoadButton = new System.Windows.Forms.Button();
            this.loadPageIDFromRpPageRadio = new System.Windows.Forms.RadioButton();
            this.loadPageIDFromSvPageRadio = new System.Windows.Forms.RadioButton();
            this.appMenu.SuspendLayout();
            this.projectIDGroup.SuspendLayout();
            this.pageIDGroup.SuspendLayout();
            this.operationGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.reportGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // appMenu
            // 
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuList});
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(585, 24);
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
            // projectIDGroup
            // 
            this.projectIDGroup.Controls.Add(this.projectIDListBox);
            this.projectIDGroup.Controls.Add(this.projectIDLoadButton);
            this.projectIDGroup.Location = new System.Drawing.Point(12, 39);
            this.projectIDGroup.Name = "projectIDGroup";
            this.projectIDGroup.Size = new System.Drawing.Size(232, 118);
            this.projectIDGroup.TabIndex = 2;
            this.projectIDGroup.TabStop = false;
            this.projectIDGroup.Text = "サイト";
            // 
            // projectIDListBox
            // 
            this.projectIDListBox.FormattingEnabled = true;
            this.projectIDListBox.ItemHeight = 12;
            this.projectIDListBox.Location = new System.Drawing.Point(3, 15);
            this.projectIDListBox.Name = "projectIDListBox";
            this.projectIDListBox.ScrollAlwaysVisible = true;
            this.projectIDListBox.Size = new System.Drawing.Size(222, 64);
            this.projectIDListBox.TabIndex = 0;
            // 
            // projectIDLoadButton
            // 
            this.projectIDLoadButton.Location = new System.Drawing.Point(7, 85);
            this.projectIDLoadButton.Name = "projectIDLoadButton";
            this.projectIDLoadButton.Size = new System.Drawing.Size(75, 23);
            this.projectIDLoadButton.TabIndex = 2;
            this.projectIDLoadButton.Text = "サイトID読込";
            this.projectIDLoadButton.UseVisualStyleBackColor = true;
            this.projectIDLoadButton.Click += new System.EventHandler(this.projectIDLoadButton_Click);
            // 
            // pageIDGroup
            // 
            this.pageIDGroup.Controls.Add(this.loadPageIDFromSvPageRadio);
            this.pageIDGroup.Controls.Add(this.loadPageIDFromRpPageRadio);
            this.pageIDGroup.Controls.Add(this.pageIDLoadButton);
            this.pageIDGroup.Controls.Add(this.pageIDListBox);
            this.pageIDGroup.Location = new System.Drawing.Point(250, 39);
            this.pageIDGroup.Name = "pageIDGroup";
            this.pageIDGroup.Size = new System.Drawing.Size(325, 118);
            this.pageIDGroup.TabIndex = 3;
            this.pageIDGroup.TabStop = false;
            this.pageIDGroup.Text = "ページID";
            // 
            // pageIDListBox
            // 
            this.pageIDListBox.FormattingEnabled = true;
            this.pageIDListBox.ItemHeight = 12;
            this.pageIDListBox.Location = new System.Drawing.Point(6, 15);
            this.pageIDListBox.Name = "pageIDListBox";
            this.pageIDListBox.ScrollAlwaysVisible = true;
            this.pageIDListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.pageIDListBox.Size = new System.Drawing.Size(313, 64);
            this.pageIDListBox.TabIndex = 0;
            // 
            // operationGroup
            // 
            this.operationGroup.Controls.Add(this.cancelOperationButton);
            this.operationGroup.Controls.Add(this.doOperationButton);
            this.operationGroup.Controls.Add(this.button1);
            this.operationGroup.Controls.Add(this.tabControl1);
            this.operationGroup.Location = new System.Drawing.Point(12, 163);
            this.operationGroup.Name = "operationGroup";
            this.operationGroup.Size = new System.Drawing.Size(563, 133);
            this.operationGroup.TabIndex = 4;
            this.operationGroup.TabStop = false;
            this.operationGroup.Text = "オペレーション";
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
            this.statusStrip1.Size = new System.Drawing.Size(585, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // reportGroup
            // 
            this.reportGroup.Controls.Add(this.operationStatusReport);
            this.reportGroup.Location = new System.Drawing.Point(12, 302);
            this.reportGroup.Name = "reportGroup";
            this.reportGroup.Size = new System.Drawing.Size(563, 100);
            this.reportGroup.TabIndex = 6;
            this.reportGroup.TabStop = false;
            this.reportGroup.Text = "処理状況";
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationStatusReport.Location = new System.Drawing.Point(3, 15);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(557, 82);
            this.operationStatusReport.TabIndex = 0;
            // 
            // pageIDLoadButton
            // 
            this.pageIDLoadButton.Location = new System.Drawing.Point(6, 85);
            this.pageIDLoadButton.Name = "pageIDLoadButton";
            this.pageIDLoadButton.Size = new System.Drawing.Size(82, 23);
            this.pageIDLoadButton.TabIndex = 1;
            this.pageIDLoadButton.Text = "ページID読込";
            this.pageIDLoadButton.UseVisualStyleBackColor = true;
            this.pageIDLoadButton.Click += new System.EventHandler(this.pageIDLoadButton_Click);
            // 
            // loadPageIDFromRpPageRadio
            // 
            this.loadPageIDFromRpPageRadio.AutoSize = true;
            this.loadPageIDFromRpPageRadio.Location = new System.Drawing.Point(94, 88);
            this.loadPageIDFromRpPageRadio.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.loadPageIDFromRpPageRadio.Name = "loadPageIDFromRpPageRadio";
            this.loadPageIDFromRpPageRadio.Size = new System.Drawing.Size(53, 16);
            this.loadPageIDFromRpPageRadio.TabIndex = 2;
            this.loadPageIDFromRpPageRadio.TabStop = true;
            this.loadPageIDFromRpPageRadio.Text = "report";
            this.loadPageIDFromRpPageRadio.UseVisualStyleBackColor = true;
            // 
            // loadPageIDFromSvPageRadio
            // 
            this.loadPageIDFromSvPageRadio.AutoSize = true;
            this.loadPageIDFromSvPageRadio.Location = new System.Drawing.Point(147, 88);
            this.loadPageIDFromSvPageRadio.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.loadPageIDFromSvPageRadio.Name = "loadPageIDFromSvPageRadio";
            this.loadPageIDFromSvPageRadio.Size = new System.Drawing.Size(59, 16);
            this.loadPageIDFromSvPageRadio.TabIndex = 3;
            this.loadPageIDFromSvPageRadio.TabStop = true;
            this.loadPageIDFromSvPageRadio.Text = "svpage";
            this.loadPageIDFromSvPageRadio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 429);
            this.Controls.Add(this.reportGroup);
            this.Controls.Add(this.pageIDGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.operationGroup);
            this.Controls.Add(this.projectIDGroup);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.Name = "Form1";
            this.Text = "LibraUtilGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.projectIDGroup.ResumeLayout(false);
            this.pageIDGroup.ResumeLayout(false);
            this.pageIDGroup.PerformLayout();
            this.operationGroup.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.reportGroup.ResumeLayout(false);
            this.reportGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSettings;
        private System.Windows.Forms.GroupBox projectIDGroup;
        private System.Windows.Forms.ListBox projectIDListBox;
        private System.Windows.Forms.GroupBox pageIDGroup;
        private System.Windows.Forms.ListBox pageIDListBox;
        private System.Windows.Forms.GroupBox operationGroup;
        private System.Windows.Forms.Button cancelOperationButton;
        private System.Windows.Forms.Button doOperationButton;
        private System.Windows.Forms.Button projectIDLoadButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox reportGroup;
        private System.Windows.Forms.Button pageIDLoadButton;
        private System.Windows.Forms.RadioButton loadPageIDFromSvPageRadio;
        private System.Windows.Forms.RadioButton loadPageIDFromRpPageRadio;
        public System.Windows.Forms.TextBox operationStatusReport;
    }
}

