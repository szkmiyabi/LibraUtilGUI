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
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.projectIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDGroup = new System.Windows.Forms.GroupBox();
            this.pageIDListBoxSelectClearButton = new System.Windows.Forms.Button();
            this.pageIDListBoxSelectAllButton = new System.Windows.Forms.Button();
            this.loadPageIDFromSvPageRadio = new System.Windows.Forms.RadioButton();
            this.loadPageIDFromRpPageRadio = new System.Windows.Forms.RadioButton();
            this.pageIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.cancelOperationButton = new System.Windows.Forms.Button();
            this.doOperationButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.operationStatusReport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.appMenu.SuspendLayout();
            this.pageIDGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 36);
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
            this.appMenu.Size = new System.Drawing.Size(681, 24);
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
            // projectIDListBox
            // 
            this.projectIDListBox.FormattingEnabled = true;
            this.projectIDListBox.ItemHeight = 12;
            this.projectIDListBox.Location = new System.Drawing.Point(5, 15);
            this.projectIDListBox.Name = "projectIDListBox";
            this.projectIDListBox.ScrollAlwaysVisible = true;
            this.projectIDListBox.Size = new System.Drawing.Size(222, 64);
            this.projectIDListBox.TabIndex = 0;
            // 
            // projectIDLoadButton
            // 
            this.projectIDLoadButton.Location = new System.Drawing.Point(5, 90);
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
            this.pageIDGroup.Location = new System.Drawing.Point(95, 82);
            this.pageIDGroup.Margin = new System.Windows.Forms.Padding(0);
            this.pageIDGroup.Name = "pageIDGroup";
            this.pageIDGroup.Size = new System.Drawing.Size(183, 33);
            this.pageIDGroup.TabIndex = 3;
            this.pageIDGroup.TabStop = false;
            // 
            // pageIDListBoxSelectClearButton
            // 
            this.pageIDListBoxSelectClearButton.Location = new System.Drawing.Point(339, 90);
            this.pageIDListBoxSelectClearButton.Name = "pageIDListBoxSelectClearButton";
            this.pageIDListBoxSelectClearButton.Size = new System.Drawing.Size(63, 23);
            this.pageIDListBoxSelectClearButton.TabIndex = 5;
            this.pageIDListBoxSelectClearButton.Text = "選択解除";
            this.pageIDListBoxSelectClearButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectClearButton.Click += new System.EventHandler(this.pageIDListBoxSelectClearButton_Click);
            // 
            // pageIDListBoxSelectAllButton
            // 
            this.pageIDListBoxSelectAllButton.Location = new System.Drawing.Point(282, 90);
            this.pageIDListBoxSelectAllButton.Name = "pageIDListBoxSelectAllButton";
            this.pageIDListBoxSelectAllButton.Size = new System.Drawing.Size(56, 23);
            this.pageIDListBoxSelectAllButton.TabIndex = 4;
            this.pageIDListBoxSelectAllButton.Text = "全選択";
            this.pageIDListBoxSelectAllButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectAllButton.Click += new System.EventHandler(this.pageIDListBoxSelectAllButton_Click);
            // 
            // loadPageIDFromSvPageRadio
            // 
            this.loadPageIDFromSvPageRadio.AutoSize = true;
            this.loadPageIDFromSvPageRadio.Location = new System.Drawing.Point(90, 11);
            this.loadPageIDFromSvPageRadio.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.loadPageIDFromSvPageRadio.Name = "loadPageIDFromSvPageRadio";
            this.loadPageIDFromSvPageRadio.Size = new System.Drawing.Size(83, 16);
            this.loadPageIDFromSvPageRadio.TabIndex = 3;
            this.loadPageIDFromSvPageRadio.TabStop = true;
            this.loadPageIDFromSvPageRadio.Text = "検査画面頁";
            this.loadPageIDFromSvPageRadio.UseVisualStyleBackColor = true;
            // 
            // loadPageIDFromRpPageRadio
            // 
            this.loadPageIDFromRpPageRadio.AutoSize = true;
            this.loadPageIDFromRpPageRadio.Location = new System.Drawing.Point(6, 11);
            this.loadPageIDFromRpPageRadio.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.loadPageIDFromRpPageRadio.Name = "loadPageIDFromRpPageRadio";
            this.loadPageIDFromRpPageRadio.Size = new System.Drawing.Size(83, 16);
            this.loadPageIDFromRpPageRadio.TabIndex = 2;
            this.loadPageIDFromRpPageRadio.TabStop = true;
            this.loadPageIDFromRpPageRadio.Text = "結果画面頁";
            this.loadPageIDFromRpPageRadio.UseVisualStyleBackColor = true;
            // 
            // pageIDLoadButton
            // 
            this.pageIDLoadButton.Location = new System.Drawing.Point(5, 90);
            this.pageIDLoadButton.Name = "pageIDLoadButton";
            this.pageIDLoadButton.Size = new System.Drawing.Size(82, 23);
            this.pageIDLoadButton.TabIndex = 1;
            this.pageIDLoadButton.Text = "ページID読込";
            this.pageIDLoadButton.UseVisualStyleBackColor = true;
            this.pageIDLoadButton.Click += new System.EventHandler(this.pageIDLoadButton_Click);
            // 
            // pageIDListBox
            // 
            this.pageIDListBox.FormattingEnabled = true;
            this.pageIDListBox.ItemHeight = 12;
            this.pageIDListBox.Location = new System.Drawing.Point(5, 15);
            this.pageIDListBox.Name = "pageIDListBox";
            this.pageIDListBox.ScrollAlwaysVisible = true;
            this.pageIDListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.pageIDListBox.Size = new System.Drawing.Size(397, 64);
            this.pageIDListBox.TabIndex = 0;
            // 
            // cancelOperationButton
            // 
            this.cancelOperationButton.Location = new System.Drawing.Point(575, 112);
            this.cancelOperationButton.Name = "cancelOperationButton";
            this.cancelOperationButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOperationButton.TabIndex = 4;
            this.cancelOperationButton.Text = "キャンセル";
            this.cancelOperationButton.UseVisualStyleBackColor = true;
            // 
            // doOperationButton
            // 
            this.doOperationButton.Location = new System.Drawing.Point(575, 83);
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
            this.tabControl1.Location = new System.Drawing.Point(5, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(555, 124);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(547, 98);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "URL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(547, 98);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(681, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // operationStatusReport
            // 
            this.operationStatusReport.Location = new System.Drawing.Point(9, 15);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(641, 94);
            this.operationStatusReport.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "サイトID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "ページID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "オペレーション";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.projectIDListBox);
            this.panel1.Controls.Add(this.projectIDLoadButton);
            this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 124);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pageIDListBox);
            this.panel2.Controls.Add(this.pageIDLoadButton);
            this.panel2.Controls.Add(this.pageIDGroup);
            this.panel2.Controls.Add(this.pageIDListBoxSelectAllButton);
            this.panel2.Controls.Add(this.pageIDListBoxSelectClearButton);
            this.panel2.Location = new System.Drawing.Point(255, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 124);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.cancelOperationButton);
            this.panel3.Controls.Add(this.doOperationButton);
            this.panel3.Location = new System.Drawing.Point(12, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 143);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.operationStatusReport);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 334);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(658, 116);
            this.panel4.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "処理状況";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 483);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.Name = "Form1";
            this.Text = "LibraUtilGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.pageIDGroup.ResumeLayout(false);
            this.pageIDGroup.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSettings;
        private System.Windows.Forms.ListBox projectIDListBox;
        private System.Windows.Forms.GroupBox pageIDGroup;
        private System.Windows.Forms.ListBox pageIDListBox;
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
        private System.Windows.Forms.Button pageIDLoadButton;
        private System.Windows.Forms.RadioButton loadPageIDFromSvPageRadio;
        private System.Windows.Forms.RadioButton loadPageIDFromRpPageRadio;
        public System.Windows.Forms.TextBox operationStatusReport;
        private System.Windows.Forms.Button pageIDListBoxSelectAllButton;
        private System.Windows.Forms.Button pageIDListBoxSelectClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
    }
}

