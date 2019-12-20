using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        
        //進捗状況の保持用バッファ
        private string txt_buf = "";

        //デリゲートの定義
        //別スレッドからフォームを操作時必須
        public delegate void BufTxtWriteDelg();
        public delegate void TxtWriteDelg(string txt);

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

        //ステータステキストの更新
        public void buf_txt_write()
        {
            operationStatusReport.AppendText(txt_buf);
            operationStatusReport.AppendText("\r\n");
        }

        public void txt_write(string txt)
        {
            operationStatusReport.AppendText(txt);
            operationStatusReport.AppendText("\r\n");
        }

        //設定メニュークリック
        private void FileMenuSettings_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

    }

}
