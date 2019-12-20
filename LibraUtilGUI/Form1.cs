﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using AngleSharp;
using AngleSharp.Parser;


namespace LibraUtilGUI
{
    public partial class Form1 : Form
    {

        private string txt_buf = "";

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            toolStripStatusLabel1.Text = "はじめに事前処理を実行してください。";
        }

        //実験用Button1メソッド
        private void button1_Click(object sender, EventArgs e)
        {
            test_method();
        }



        //設定メニュークリック
        private void FileMenuSettings_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

        //事前準備クリック
        private void preOperationButton_Click(object sender, EventArgs e)
        {
            set_projectID_combo();
        }
    }

}
