﻿namespace LibraUtilGUI
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.uidText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pswdText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guidelineLevelCombo = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.systemWaitCombo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.longWaitCombo = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.midWaitCombo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.shortWaitCombo = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.driverCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.headlessCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.basicAuthCombo = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.workDirText = new System.Windows.Forms.TextBox();
            this.workDirBrowseButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.debugModeCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemWaitCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.longWaitCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midWaitCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortWaitCombo)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.11267F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.88733F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 174);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.uidText);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.pswdText);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.guidelineLevelCombo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(533, 26);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ユーザID";
            // 
            // uidText
            // 
            this.uidText.Location = new System.Drawing.Point(55, 3);
            this.uidText.Name = "uidText";
            this.uidText.Size = new System.Drawing.Size(100, 19);
            this.uidText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "パスワード";
            // 
            // pswdText
            // 
            this.pswdText.Location = new System.Drawing.Point(219, 3);
            this.pswdText.Name = "pswdText";
            this.pswdText.Size = new System.Drawing.Size(100, 19);
            this.pswdText.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(325, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "ガイドラインレベル";
            // 
            // guidelineLevelCombo
            // 
            this.guidelineLevelCombo.FormattingEnabled = true;
            this.guidelineLevelCombo.Items.AddRange(new object[] {
            "AA",
            "A",
            "AAA"});
            this.guidelineLevelCombo.Location = new System.Drawing.Point(419, 3);
            this.guidelineLevelCombo.Name = "guidelineLevelCombo";
            this.guidelineLevelCombo.Size = new System.Drawing.Size(61, 20);
            this.guidelineLevelCombo.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.systemWaitCombo);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.longWaitCombo);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.midWaitCombo);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.shortWaitCombo);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(533, 24);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "システム待時間";
            // 
            // systemWaitCombo
            // 
            this.systemWaitCombo.Location = new System.Drawing.Point(88, 3);
            this.systemWaitCombo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.systemWaitCombo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.systemWaitCombo.Name = "systemWaitCombo";
            this.systemWaitCombo.Size = new System.Drawing.Size(45, 19);
            this.systemWaitCombo.TabIndex = 1;
            this.systemWaitCombo.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "待時間【大】";
            // 
            // longWaitCombo
            // 
            this.longWaitCombo.Location = new System.Drawing.Point(210, 3);
            this.longWaitCombo.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.longWaitCombo.Name = "longWaitCombo";
            this.longWaitCombo.Size = new System.Drawing.Size(49, 19);
            this.longWaitCombo.TabIndex = 3;
            this.longWaitCombo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "待時間【中】";
            // 
            // midWaitCombo
            // 
            this.midWaitCombo.Location = new System.Drawing.Point(336, 3);
            this.midWaitCombo.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.midWaitCombo.Name = "midWaitCombo";
            this.midWaitCombo.Size = new System.Drawing.Size(59, 19);
            this.midWaitCombo.TabIndex = 5;
            this.midWaitCombo.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "待時間【小】";
            // 
            // shortWaitCombo
            // 
            this.shortWaitCombo.Location = new System.Drawing.Point(472, 3);
            this.shortWaitCombo.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.shortWaitCombo.Name = "shortWaitCombo";
            this.shortWaitCombo.Size = new System.Drawing.Size(51, 19);
            this.shortWaitCombo.TabIndex = 7;
            this.shortWaitCombo.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.driverCombo);
            this.flowLayoutPanel3.Controls.Add(this.label8);
            this.flowLayoutPanel3.Controls.Add(this.headlessCombo);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.basicAuthCombo);
            this.flowLayoutPanel3.Controls.Add(this.label12);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 65);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(533, 29);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "ブラウザ";
            // 
            // driverCombo
            // 
            this.driverCombo.FormattingEnabled = true;
            this.driverCombo.Items.AddRange(new object[] {
            "chrome",
            "firefox"});
            this.driverCombo.Location = new System.Drawing.Point(50, 3);
            this.driverCombo.Name = "driverCombo";
            this.driverCombo.Size = new System.Drawing.Size(86, 20);
            this.driverCombo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "ヘッドレス起動";
            // 
            // headlessCombo
            // 
            this.headlessCombo.FormattingEnabled = true;
            this.headlessCombo.Items.AddRange(new object[] {
            "yes",
            "no"});
            this.headlessCombo.Location = new System.Drawing.Point(221, 3);
            this.headlessCombo.Name = "headlessCombo";
            this.headlessCombo.Size = new System.Drawing.Size(65, 20);
            this.headlessCombo.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "基本認証";
            // 
            // basicAuthCombo
            // 
            this.basicAuthCombo.FormattingEnabled = true;
            this.basicAuthCombo.Items.AddRange(new object[] {
            "no",
            "yes"});
            this.basicAuthCombo.Location = new System.Drawing.Point(351, 3);
            this.basicAuthCombo.Name = "basicAuthCombo";
            this.basicAuthCombo.Size = new System.Drawing.Size(62, 20);
            this.basicAuthCombo.TabIndex = 7;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.OkButton);
            this.flowLayoutPanel4.Controls.Add(this.CancelButton);
            this.flowLayoutPanel4.Controls.Add(this.ClearButton);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(169, 139);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(367, 32);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(3, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(84, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "キャンセル";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(165, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "設定消去";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label11);
            this.flowLayoutPanel5.Controls.Add(this.workDirText);
            this.flowLayoutPanel5.Controls.Add(this.workDirBrowseButton);
            this.flowLayoutPanel5.Controls.Add(this.debugModeCheck);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 100);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(533, 33);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "作業ディレクトリ";
            // 
            // workDirText
            // 
            this.workDirText.Location = new System.Drawing.Point(87, 3);
            this.workDirText.Name = "workDirText";
            this.workDirText.Size = new System.Drawing.Size(275, 19);
            this.workDirText.TabIndex = 1;
            // 
            // workDirBrowseButton
            // 
            this.workDirBrowseButton.Location = new System.Drawing.Point(368, 3);
            this.workDirBrowseButton.Name = "workDirBrowseButton";
            this.workDirBrowseButton.Size = new System.Drawing.Size(47, 23);
            this.workDirBrowseButton.TabIndex = 2;
            this.workDirBrowseButton.Text = "参照";
            this.workDirBrowseButton.UseVisualStyleBackColor = true;
            this.workDirBrowseButton.Click += new System.EventHandler(this.workDirBrowseButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 12);
            this.label12.TabIndex = 8;
            // 
            // debugModeCheck
            // 
            this.debugModeCheck.AutoSize = true;
            this.debugModeCheck.Location = new System.Drawing.Point(433, 6);
            this.debugModeCheck.Margin = new System.Windows.Forms.Padding(15, 6, 3, 3);
            this.debugModeCheck.Name = "debugModeCheck";
            this.debugModeCheck.Size = new System.Drawing.Size(88, 16);
            this.debugModeCheck.TabIndex = 3;
            this.debugModeCheck.Text = "開発者モード";
            this.debugModeCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 174);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "環境設定";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemWaitCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.longWaitCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midWaitCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortWaitCombo)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uidText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pswdText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox guidelineLevelCombo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown systemWaitCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown longWaitCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown midWaitCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown shortWaitCombo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox driverCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox headlessCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox basicAuthCombo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox workDirText;
        private System.Windows.Forms.Button workDirBrowseButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox debugModeCheck;
    }
}