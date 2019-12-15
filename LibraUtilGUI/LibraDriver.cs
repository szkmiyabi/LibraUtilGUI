using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace LibraUtilGUI
{
    public class LibraDriver
    {
        private string projectID;
        private IWebDriver wd;
        private int systemWait;
        private int longWait;
        private int midWait;
        private int shortWait;
        private string uid;
        private string pswd;
        private string windowID;
        private string app_url = "https://accessibility.jp/libra/";
        private string index_url = "https://jis.infocreate.co.jp/";
        private string rep_index_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report/projID/";
        private string rep_detail_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report2/projID/";
        private string sv_mainpage_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/index/projID/";
        private string guideline_file_name = "guideline_datas.txt";
        private List<List<string>> rep_data;
        private string basic_auth_flag;
        private Boolean basic_authenicated;
        private string workDir;

        //コンストラクタ
        public LibraDriver(string uid, string pswd, string projectID, int[] appWait, string driver_type, string headless_flag, string basic_auth_flag, string workDir)
        {
            this.uid = uid;
            this.pswd = pswd;
            this.projectID = projectID;
            systemWait = appWait[0];
            longWait = appWait[1];
            midWait = appWait[2];
            shortWait = appWait[3];
            this.workDir = workDir;

            //レポートデータ初期化

            //basic認証フラグ
            this.basic_auth_flag = basic_auth_flag;
            basic_authenicated = false;

            if (driver_type.Equals("firefox"))
            {
                FirefoxOptions fxopt = new FirefoxOptions();
                if (headless_flag.Equals("yes")) fxopt.AddArguments("-headless");
                wd = new FirefoxDriver(fxopt);
            }
            else if (driver_type.Equals("chrome"))
            {
                ChromeOptions chopt = new ChromeOptions();
                if (headless_flag.Equals("yes")) chopt.AddArguments("--headless");
                wd = new ChromeDriver(chopt);
            }

            wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(systemWait);
            wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
            wd.Navigate().GoToUrl(app_url);
            windowID = wd.WindowHandles[0];
        }

        //WebDriverのゲッター
        public IWebDriver getWd()
        {
            return wd;
        }

        //JavascriptExecutorのゲッター
        public IJavaScriptExecutor getJsExe()
        {
            IJavaScriptExecutor jsx = (IJavaScriptExecutor)wd;
            return jsx;
        }

        //basic認証済みフラグのゲッター
        public Boolean getBasicAuthenicated()
        {
            return basic_authenicated;
        }

        //basic認証済みフラグのセッター
        public void setBasicAuthenicated(Boolean flag)
        {
            basic_authenicated = flag;
        }

        //スクリーンショットを撮る
        public void screenshot(string filename)
        {
            Screenshot sc = ((ITakesScreenshot)wd).GetScreenshot();
            string save_dir = workDir + filename + ".png";
            sc.SaveAsFile(save_dir, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //スクリーンショットを撮る（ディレクトリ指定）
        public void screenshot_as(string save_path)
        {
            Screenshot sc = ((ITakesScreenshot)wd).GetScreenshot();
            sc.SaveAsFile(save_path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //シャットダウン
        public void shutdown()
        {
            wd.Quit();
        }

        //ログイン
        public void login()
        {
            wd.FindElement(By.Id("uid")).SendKeys(uid);
            wd.FindElement(By.Id("pswd")).SendKeys(pswd);
            wd.FindElement(By.Id("btn")).Click();
        }

        //ログアウト
        public void logout()
        {
            wd.Navigate().GoToUrl(index_url);
            Thread.Sleep(shortWait);
            IWebElement btnWrap = wd.FindElement(By.Id("btn"));
            IWebElement btnBase = btnWrap.FindElement(By.TagName("ul"));
            IWebElement btnBaseInner = btnBase.FindElement(By.ClassName("btn2"));
            IWebElement btnA = btnBaseInner.FindElement(By.TagName("a"));
            btnA.Click();
        }

        //レポートインデックスページに遷移
        public void browse_repo()
        {
            wd.Navigate().GoToUrl(rep_index_url_base + projectID);
        }

        //検査メインページに移動
        public void browse_sv_mainpage()
        {
            wd.Navigate().GoToUrl(sv_mainpage_url_base + projectID);

            //basic認証の処理
            if(basic_auth_flag.Equals("yes") && basic_authenicated == false)
            {
                MessageBox.Show("basicAuthオプションが有効化されています。ログインアラートで認証を済ませた後、Enterキーを入力してください。");
                basic_authenicated = true;
            }
        }

        //レポート詳細ページのURL生成
        public string fetch_report_detail_path(string pageID, string guidelineID)
        {
            return rep_detail_url_base + projectID + "/controlID/" + pageID + "/guideline/" + guidelineID + "/";
        }

    }
}
