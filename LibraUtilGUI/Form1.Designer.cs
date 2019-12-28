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
            this.appMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuList = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.projectIDListBox = new System.Windows.Forms.ListBox();
            this.projectIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDGroup = new System.Windows.Forms.GroupBox();
            this.BaseTaskSrcSurvey = new System.Windows.Forms.RadioButton();
            this.BaseTaskSrcReport = new System.Windows.Forms.RadioButton();
            this.pageIDListBoxSelectClearButton = new System.Windows.Forms.Button();
            this.pageIDListBoxSelectAllButton = new System.Windows.Forms.Button();
            this.pageIDLoadButton = new System.Windows.Forms.Button();
            this.pageIDListBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UrlTaskSrcSurvey = new System.Windows.Forms.RadioButton();
            this.UrlTaskSrcReport = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UrlTaskFormatExcel = new System.Windows.Forms.RadioButton();
            this.UrlTaskFormatText = new System.Windows.Forms.RadioButton();
            this.doUrlTaskButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UrlTaskTypePID = new System.Windows.Forms.RadioButton();
            this.UrlTaskTypePIDURL = new System.Windows.Forms.RadioButton();
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
            this.createSiteInfoBookButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.guidelineSelectClearButton = new System.Windows.Forms.Button();
            this.guidelineSelectAllButton = new System.Windows.Forms.Button();
            this.guidelineListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.appMenu.SuspendLayout();
            this.pageIDGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // appMenu
            // 
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuList});
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(648, 24);
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
            this.projectIDListBox.Location = new System.Drawing.Point(3, 15);
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
            this.pageIDGroup.Controls.Add(this.BaseTaskSrcSurvey);
            this.pageIDGroup.Controls.Add(this.BaseTaskSrcReport);
            this.pageIDGroup.Location = new System.Drawing.Point(101, 82);
            this.pageIDGroup.Margin = new System.Windows.Forms.Padding(0);
            this.pageIDGroup.Name = "pageIDGroup";
            this.pageIDGroup.Size = new System.Drawing.Size(152, 34);
            this.pageIDGroup.TabIndex = 3;
            this.pageIDGroup.TabStop = false;
            // 
            // BaseTaskSrcSurvey
            // 
            this.BaseTaskSrcSurvey.AutoSize = true;
            this.BaseTaskSrcSurvey.Location = new System.Drawing.Point(77, 11);
            this.BaseTaskSrcSurvey.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.BaseTaskSrcSurvey.Name = "BaseTaskSrcSurvey";
            this.BaseTaskSrcSurvey.Size = new System.Drawing.Size(71, 16);
            this.BaseTaskSrcSurvey.TabIndex = 3;
            this.BaseTaskSrcSurvey.TabStop = true;
            this.BaseTaskSrcSurvey.Text = "検査画面";
            this.BaseTaskSrcSurvey.UseVisualStyleBackColor = true;
            // 
            // BaseTaskSrcReport
            // 
            this.BaseTaskSrcReport.AutoSize = true;
            this.BaseTaskSrcReport.Location = new System.Drawing.Point(6, 11);
            this.BaseTaskSrcReport.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.BaseTaskSrcReport.Name = "BaseTaskSrcReport";
            this.BaseTaskSrcReport.Size = new System.Drawing.Size(71, 16);
            this.BaseTaskSrcReport.TabIndex = 2;
            this.BaseTaskSrcReport.TabStop = true;
            this.BaseTaskSrcReport.Text = "結果画面";
            this.BaseTaskSrcReport.UseVisualStyleBackColor = true;
            // 
            // pageIDListBoxSelectClearButton
            // 
            this.pageIDListBoxSelectClearButton.Location = new System.Drawing.Point(323, 90);
            this.pageIDListBoxSelectClearButton.Name = "pageIDListBoxSelectClearButton";
            this.pageIDListBoxSelectClearButton.Size = new System.Drawing.Size(63, 23);
            this.pageIDListBoxSelectClearButton.TabIndex = 5;
            this.pageIDListBoxSelectClearButton.Text = "選択解除";
            this.pageIDListBoxSelectClearButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectClearButton.Click += new System.EventHandler(this.pageIDListBoxSelectClearButton_Click);
            // 
            // pageIDListBoxSelectAllButton
            // 
            this.pageIDListBoxSelectAllButton.Location = new System.Drawing.Point(261, 90);
            this.pageIDListBoxSelectAllButton.Name = "pageIDListBoxSelectAllButton";
            this.pageIDListBoxSelectAllButton.Size = new System.Drawing.Size(56, 23);
            this.pageIDListBoxSelectAllButton.TabIndex = 4;
            this.pageIDListBoxSelectAllButton.Text = "全選択";
            this.pageIDListBoxSelectAllButton.UseVisualStyleBackColor = true;
            this.pageIDListBoxSelectAllButton.Click += new System.EventHandler(this.pageIDListBoxSelectAllButton_Click);
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
            this.pageIDListBox.Size = new System.Drawing.Size(381, 64);
            this.pageIDListBox.TabIndex = 0;
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
            this.tabControl1.Size = new System.Drawing.Size(483, 124);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.doUrlTaskButton);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(475, 98);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "URL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UrlTaskSrcSurvey);
            this.groupBox3.Controls.Add(this.UrlTaskSrcReport);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 34);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参照先";
            // 
            // UrlTaskSrcSurvey
            // 
            this.UrlTaskSrcSurvey.AutoSize = true;
            this.UrlTaskSrcSurvey.Location = new System.Drawing.Point(80, 15);
            this.UrlTaskSrcSurvey.Name = "UrlTaskSrcSurvey";
            this.UrlTaskSrcSurvey.Size = new System.Drawing.Size(71, 16);
            this.UrlTaskSrcSurvey.TabIndex = 1;
            this.UrlTaskSrcSurvey.TabStop = true;
            this.UrlTaskSrcSurvey.Text = "検査画面";
            this.UrlTaskSrcSurvey.UseVisualStyleBackColor = true;
            // 
            // UrlTaskSrcReport
            // 
            this.UrlTaskSrcReport.AutoSize = true;
            this.UrlTaskSrcReport.Location = new System.Drawing.Point(3, 15);
            this.UrlTaskSrcReport.Name = "UrlTaskSrcReport";
            this.UrlTaskSrcReport.Size = new System.Drawing.Size(71, 16);
            this.UrlTaskSrcReport.TabIndex = 0;
            this.UrlTaskSrcReport.TabStop = true;
            this.UrlTaskSrcReport.Text = "結果画面";
            this.UrlTaskSrcReport.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UrlTaskFormatExcel);
            this.groupBox2.Controls.Add(this.UrlTaskFormatText);
            this.groupBox2.Location = new System.Drawing.Point(319, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 34);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "フォーマット";
            // 
            // UrlTaskFormatExcel
            // 
            this.UrlTaskFormatExcel.AutoSize = true;
            this.UrlTaskFormatExcel.Location = new System.Drawing.Point(62, 15);
            this.UrlTaskFormatExcel.Name = "UrlTaskFormatExcel";
            this.UrlTaskFormatExcel.Size = new System.Drawing.Size(85, 16);
            this.UrlTaskFormatExcel.TabIndex = 1;
            this.UrlTaskFormatExcel.TabStop = true;
            this.UrlTaskFormatExcel.Text = "Excelファイル";
            this.UrlTaskFormatExcel.UseVisualStyleBackColor = true;
            // 
            // UrlTaskFormatText
            // 
            this.UrlTaskFormatText.AutoSize = true;
            this.UrlTaskFormatText.Location = new System.Drawing.Point(6, 15);
            this.UrlTaskFormatText.Name = "UrlTaskFormatText";
            this.UrlTaskFormatText.Size = new System.Drawing.Size(59, 16);
            this.UrlTaskFormatText.TabIndex = 0;
            this.UrlTaskFormatText.TabStop = true;
            this.UrlTaskFormatText.Text = "テキスト";
            this.UrlTaskFormatText.UseVisualStyleBackColor = true;
            // 
            // doUrlTaskButton
            // 
            this.doUrlTaskButton.Location = new System.Drawing.Point(391, 69);
            this.doUrlTaskButton.Name = "doUrlTaskButton";
            this.doUrlTaskButton.Size = new System.Drawing.Size(75, 23);
            this.doUrlTaskButton.TabIndex = 1;
            this.doUrlTaskButton.Text = "処理実行";
            this.doUrlTaskButton.UseVisualStyleBackColor = true;
            this.doUrlTaskButton.Click += new System.EventHandler(this.doUrlTaskButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UrlTaskTypePID);
            this.groupBox1.Controls.Add(this.UrlTaskTypePIDURL);
            this.groupBox1.Location = new System.Drawing.Point(180, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 34);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力タイプ";
            // 
            // UrlTaskTypePID
            // 
            this.UrlTaskTypePID.AutoSize = true;
            this.UrlTaskTypePID.Location = new System.Drawing.Point(74, 15);
            this.UrlTaskTypePID.Name = "UrlTaskTypePID";
            this.UrlTaskTypePID.Size = new System.Drawing.Size(41, 16);
            this.UrlTaskTypePID.TabIndex = 1;
            this.UrlTaskTypePID.TabStop = true;
            this.UrlTaskTypePID.Text = "PID";
            this.UrlTaskTypePID.UseVisualStyleBackColor = true;
            // 
            // UrlTaskTypePIDURL
            // 
            this.UrlTaskTypePIDURL.AutoSize = true;
            this.UrlTaskTypePIDURL.Location = new System.Drawing.Point(6, 15);
            this.UrlTaskTypePIDURL.Name = "UrlTaskTypePIDURL";
            this.UrlTaskTypePIDURL.Size = new System.Drawing.Size(71, 16);
            this.UrlTaskTypePIDURL.TabIndex = 0;
            this.UrlTaskTypePIDURL.TabStop = true;
            this.UrlTaskTypePIDURL.Text = "PIDとURL";
            this.UrlTaskTypePIDURL.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(475, 98);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(475, 98);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PRESV";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(475, 98);
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
            this.statusStrip1.Size = new System.Drawing.Size(648, 22);
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
            this.operationStatusReport.Location = new System.Drawing.Point(3, 15);
            this.operationStatusReport.Multiline = true;
            this.operationStatusReport.Name = "operationStatusReport";
            this.operationStatusReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationStatusReport.Size = new System.Drawing.Size(614, 94);
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
            this.panel1.Controls.Add(this.createSiteInfoBookButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.projectIDListBox);
            this.panel1.Controls.Add(this.projectIDLoadButton);
            this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 124);
            this.panel1.TabIndex = 10;
            // 
            // createSiteInfoBookButton
            // 
            this.createSiteInfoBookButton.Location = new System.Drawing.Point(150, 90);
            this.createSiteInfoBookButton.Name = "createSiteInfoBookButton";
            this.createSiteInfoBookButton.Size = new System.Drawing.Size(75, 23);
            this.createSiteInfoBookButton.TabIndex = 8;
            this.createSiteInfoBookButton.Text = "Excel出力";
            this.createSiteInfoBookButton.UseVisualStyleBackColor = true;
            this.createSiteInfoBookButton.Click += new System.EventHandler(this.createSiteInfoBookButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pageIDListBox);
            this.panel2.Controls.Add(this.pageIDLoadButton);
            this.panel2.Controls.Add(this.pageIDGroup);
            this.panel2.Controls.Add(this.pageIDListBoxSelectAllButton);
            this.panel2.Controls.Add(this.pageIDListBoxSelectClearButton);
            this.panel2.Location = new System.Drawing.Point(243, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 124);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Location = new System.Drawing.Point(144, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 143);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.operationStatusReport);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 334);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(623, 116);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.guidelineSelectClearButton);
            this.panel5.Controls.Add(this.guidelineSelectAllButton);
            this.panel5.Controls.Add(this.guidelineListBox);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(12, 168);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(130, 143);
            this.panel5.TabIndex = 14;
            // 
            // guidelineSelectClearButton
            // 
            this.guidelineSelectClearButton.Location = new System.Drawing.Point(61, 112);
            this.guidelineSelectClearButton.Name = "guidelineSelectClearButton";
            this.guidelineSelectClearButton.Size = new System.Drawing.Size(65, 23);
            this.guidelineSelectClearButton.TabIndex = 3;
            this.guidelineSelectClearButton.Text = "選択解除";
            this.guidelineSelectClearButton.UseVisualStyleBackColor = true;
            this.guidelineSelectClearButton.Click += new System.EventHandler(this.guidelineSelectClearButton_Click);
            // 
            // guidelineSelectAllButton
            // 
            this.guidelineSelectAllButton.Location = new System.Drawing.Point(5, 112);
            this.guidelineSelectAllButton.Name = "guidelineSelectAllButton";
            this.guidelineSelectAllButton.Size = new System.Drawing.Size(51, 23);
            this.guidelineSelectAllButton.TabIndex = 2;
            this.guidelineSelectAllButton.Text = "全選択";
            this.guidelineSelectAllButton.UseVisualStyleBackColor = true;
            this.guidelineSelectAllButton.Click += new System.EventHandler(this.guidelineSelectAllButton_Click);
            // 
            // guidelineListBox
            // 
            this.guidelineListBox.FormattingEnabled = true;
            this.guidelineListBox.ItemHeight = 12;
            this.guidelineListBox.Location = new System.Drawing.Point(3, 15);
            this.guidelineListBox.Name = "guidelineListBox";
            this.guidelineListBox.ScrollAlwaysVisible = true;
            this.guidelineListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.guidelineListBox.Size = new System.Drawing.Size(123, 88);
            this.guidelineListBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "達成基準";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 483);
            this.Controls.Add(this.panel5);
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
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSettings;
        private System.Windows.Forms.ListBox projectIDListBox;
        private System.Windows.Forms.GroupBox pageIDGroup;
        private System.Windows.Forms.ListBox pageIDListBox;
        private System.Windows.Forms.Button projectIDLoadButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button pageIDLoadButton;
        private System.Windows.Forms.RadioButton BaseTaskSrcSurvey;
        private System.Windows.Forms.RadioButton BaseTaskSrcReport;
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
        private System.Windows.Forms.Button doUrlTaskButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton UrlTaskTypePID;
        private System.Windows.Forms.RadioButton UrlTaskTypePIDURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton UrlTaskFormatExcel;
        private System.Windows.Forms.RadioButton UrlTaskFormatText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton UrlTaskSrcSurvey;
        private System.Windows.Forms.RadioButton UrlTaskSrcReport;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox guidelineListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button guidelineSelectClearButton;
        private System.Windows.Forms.Button guidelineSelectAllButton;
        private System.Windows.Forms.Button createSiteInfoBookButton;
    }
}

