using System;
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
        private LibraDriver ldr;
        private Boolean ldr_activated = false;

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            pageIDLoadButton.Enabled = false;
            doOperationButton.Enabled = false;
            cancelOperationButton.Enabled = false;
        }

        //wdインスタンス生成
        private void load_wd()
        {
            if(checkSettings() == false)
            {
                operationStatusReport.AppendText(txt_buf);
                return;
            }
            try
            {
                int[] appWait = { systemWait, longWait, midWait, shortWait };
                ldr = new LibraDriver(uid, pswd, appWait, driver, headless, basic_auth, workDir);
                ldr_activated = true;
            }
            catch(Exception ex)
            {
                operationStatusReport.AppendText("【エラー】ブラウザドライバの起動に失敗しました。考えられる理由は、ブラウザのドライバが古いことです。ブラウザのドライバを更新してください。");
            }
        }
        
        //wdインスタンス解放
        private void destroy_wd()
        {
            if(ldr != null) ldr.shutdown();
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

        //フォームを閉じようとしたとき
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            destroy_wd();
        }

        //サイトID読込クリック
        private void projectIDLoadButton_Click(object sender, EventArgs e)
        {
            set_projectID_combo();
        }

        //ページID読込クリック
        private void pageIDLoadButton_Click(object sender, EventArgs e)
        {
            set_pageID_combo();
        }
    }

}
