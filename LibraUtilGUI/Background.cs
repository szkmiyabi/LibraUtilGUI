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


        //環境設定
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
                workDir = appSettings.workDir;
                if (appSettings.workDir == "") workDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

            }
            catch (Exception ex)
            {
            }
        }

    }
}
