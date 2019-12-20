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

namespace LibraUtilGUI
{
    public partial class Form1 : Form
    {
        
        //進捗状況の保持用バッファ
        private string txt_buf = "";

        //デリゲートの定義
        //別スレッドからフォームを操作時必須
        public delegate void statusTextUpdateDelegate();

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

            //非同期処理で実行
            Task task = Task.Run(()=>
            {
                //デリゲートのインスタンス生成
                statusTextUpdateDelegate dlg = new statusTextUpdateDelegate(status_text_update);

                int[] appWait = { systemWait, longWait, midWait, shortWait };
                LibraDriver ldr = new LibraDriver(uid, pswd, appWait, driver, headless, basic_auth, workDir);
                ldr.login();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));
                txt_buf = "ログインしました。";
                this.Invoke(dlg);

                ldr.setProjectID("600");
                txt_buf = "プロジェクトIDセットしました。";
                this.Invoke(dlg);

                ldr.browse_repo();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));
                txt_buf = "レポートインデックスページにアクセスしました。";
                this.Invoke(dlg);

                ldr.logout();
                ldr.shutdown();
                txt_buf = "処理が終了しました。";
                this.Invoke(dlg);

            });
        }

        //ステータステキストの更新
        public void status_text_update()
        {
            string cr = operationStatusReport.Text;
            string new_cr = (operationStatusReport.Text == "") ? txt_buf : cr + "\r\n" + txt_buf;
            operationStatusReport.Text = new_cr;
        }

        //設定メニュークリック
        private void FileMenuSettings_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

    }

}
