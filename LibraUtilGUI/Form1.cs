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
using System.Runtime.InteropServices;

namespace LibraUtilGUI
{
    public partial class Form1 : Form
    {

        //ListBoxの全選択/選択解除のWindowsAPI宣言
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int LB_SETSEL = 0x185;

        //LibraDriverインスタンス監視
        private LibraDriver ldr;
        private Boolean ldr_activated = false;

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            pageIDLoadButton.Enabled = false;
            BaseTaskSrcReport.Enabled = false;
            BaseTaskSrcSurvey.Enabled = false;
            pageIDListBoxSelectAllButton.Enabled = false;
            pageIDListBoxSelectClearButton.Enabled = false;

        }

        //wdインスタンス生成
        private void load_wd()
        {
            if(checkSettings() == false)
            {
                return;
            }
            try
            {
                int[] appWait = { systemWait, longWait, midWait, shortWait };
                ldr = new LibraDriver(this, uid, pswd, appWait, driver, headless, basic_auth, workDir);
                ldr_activated = true;
            }
            catch(Exception ex)
            {
                operationStatusReport.AppendText("【エラー】ブラウザドライバの起動に失敗しました。考えられる理由は、ブラウザのドライバが古いことです。ブラウザのドライバを更新してください。\r\n");
            }
        }
        
        //wdインスタンス解放
        private void destroy_wd()
        {
            if(ldr != null) ldr.shutdown();
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

        //全選択クリック
        private void pageIDListBoxSelectAllButton_Click(object sender, EventArgs e)
        {
            SendMessage(pageIDListBox.Handle, LB_SETSEL, 1, -1);
            pageIDListBox.SetSelected(0, true);
        }

        //選択解除クリック
        private void pageIDListBoxSelectClearButton_Click(object sender, EventArgs e)
        {
            SendMessage(pageIDListBox.Handle, LB_SETSEL, 0, -1);
            pageIDListBox.SetSelected(0, false);
        }

        //URLオペレーション処理実行
        private void doUrlTaskButton_Click(object sender, EventArgs e)
        {
            string type = "";
            if (UrlTaskTypePID.Checked) type = "pid-only";
            else type = "pid-url";

            string format = "";
            if (UrlTaskFormatExcel.Checked) format = "excel";
            else format = "text";

            switch (type)
            {
                case "pid-only":
                    do_create_pid_list();
                    break;
                case "pid-url":
                    if (format == "excel") do_create_pid_url_list_xlsx();
                    else do_create_pid_url_list();
                    break;
            }

        }
    }

}
