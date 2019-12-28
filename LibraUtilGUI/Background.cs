using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LibraUtilGUI
{

    partial class Form1
    {
        private Settings appSettings;
        private string settings_filename;

        private string uid;
        private string pswd;
        private int systemWait;
        private int longWait;
        private int midWait;
        private int shortWait;
        private string driver;
        private string headless;
        private string guidelineLevel;
        private string basic_auth;
        private string workDir;
        private string debugMode;

        //環境設定ダイアログを開く
        private void showSettingsForm()
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog(this);
            sf.Dispose();
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

        }

        //環境設定をロード
        private void loadAppSettings()
        {
            try
            {
                appSettings = new Settings();
                XmlSerializer xsz = new XmlSerializer(typeof(Settings));
                StreamReader sr = new StreamReader(
                    settings_filename,
                    new System.Text.UTF8Encoding(false)
                );
                appSettings = (Settings)xsz.Deserialize(sr);
                sr.Close();

                uid = appSettings.uid;
                pswd = appSettings.pswd;
                systemWait = appSettings.systemWait;
                longWait = appSettings.longWait;
                midWait = appSettings.midWait;
                shortWait = appSettings.shortWait;
                driver = appSettings.driver;
                headless = appSettings.headless;
                guidelineLevel = appSettings.guidelineLevel;
                basic_auth = appSettings.basic_auth;
                workDir = (appSettings.workDir == "") ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" : appSettings.workDir;
                debugMode = (appSettings.debugMode == "" || appSettings.debugMode == "no") ? "no" : "yes";

            }
            catch (Exception ex)
            {
            }
        }

        //環境設定パラメータチェック
        private Boolean checkSettings()
        {
            d_status_messenger message = new d_status_messenger(w_status_messenger);
            Boolean flag = true;
            StringBuilder sb = new StringBuilder();
            string err_txt = "";

            if (uid == "")
            {
                flag = false;
                sb.Append("・ユーザIDが未設定です。\r\n");
            }
            if (pswd == "")
            {
                flag = false;
                sb.Append("・パスワードが未設定です。\r\n");
            }
            if (headless == "")
            {
                flag = false;
                sb.Append("・ヘッドレス起動の有無効が未設定です。\r\n");
            }
            if(systemWait < 60)
            {
                flag = false;
                sb.Append("・システム待時間が60秒未満です。\r\n");
            }
            if (shortWait < 3)
            {
                flag = false;
                sb.Append("・待時間【小】が3秒未満です。\r\n");
            }
            if (midWait < 3)
            {
                flag = false;
                sb.Append("・待時間【中】が3秒未満です。\r\n");
            }
            if (longWait < 3)
            {
                flag = false;
                sb.Append("・待時間【大】が3秒未満です。\r\n");
            }

            err_txt = sb.ToString();
            if(flag == false)
            {
                err_txt = "【エラー】ブラウザドライバの起動要件を満たしません。\r\n考えられる理由は、初回起動である、あるいは環境設定の不具合です。環境設定をご確認ください。\r\n" + err_txt;
                this.Invoke(message, err_txt);
            }
            return flag;
        }

    }
}
