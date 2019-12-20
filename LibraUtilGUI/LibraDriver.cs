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

using AngleSharp;
using AngleSharp.Parser;

namespace LibraUtilGUI
{
    public class LibraDriver
    {
        private string _projectID;
        private IWebDriver _wd;
        private IJavaScriptExecutor _jexe;
        private int systemWait;
        private int longWait;
        private int midWait;
        private int shortWait;
        private string uid;
        private string pswd;
        private string _windowID;
        private string app_url = "https://accessibility.jp/libra/";
        private string index_url = "https://jis.infocreate.co.jp/";
        private string rep_index_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report/projID/";
        private string rep_detail_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/report2/projID/";
        private string sv_mainpage_url_base = "http://jis.infocreate.co.jp/diagnose/indexv2/index/projID/";
        private string guideline_file_name = "guideline_datas.txt";
        private List<List<string>> rep_data;
        private string _basic_auth_flag;
        private Boolean _basic_authenicated;
        private string workDir;

        //コンストラクタ
        public LibraDriver(string uid, string pswd, int[] appWait, string driver_type, string headless_flag, string basic_auth_flag, string workDir)
        {
            this.uid = uid;
            this.pswd = pswd;
            _projectID = "";
            systemWait = appWait[0];
            longWait = appWait[1];
            midWait = appWait[2];
            shortWait = appWait[3];
            this.workDir = workDir;

            //レポートデータ初期化

            //basic認証フラグ
            _basic_auth_flag = basic_auth_flag;
            _basic_authenicated = false;

            if (driver_type.Equals("firefox"))
            {
                FirefoxOptions fxopt = new FirefoxOptions();
                if (headless_flag.Equals("yes")) fxopt.AddArguments("-headless");
                _wd = new FirefoxDriver(fxopt);
            }
            else if (driver_type.Equals("chrome"))
            {
                ChromeOptions chopt = new ChromeOptions();
                if (headless_flag.Equals("yes")) chopt.AddArguments("--headless");
                _wd = new ChromeDriver(chopt);
            }

            _wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(systemWait);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
            _wd.Navigate().GoToUrl(app_url);
            _windowID = _wd.WindowHandles[0];
            _jexe = (IJavaScriptExecutor)_wd;
        }

        //WebDriverのゲッター
        public IWebDriver wd
        {
            get { return _wd; }
        }

        //projectIDのセッター
        public string projectID
        {
            set { _projectID = value; }
        }

        //JavascriptExecutorのゲッター
        public IJavaScriptExecutor jexe
        {
            get { return _jexe; }
        }

        //basic認証済みフラグのゲッター/セッター
        public Boolean basic_authenicated
        {
            get { return _basic_authenicated; }
            set { _basic_authenicated = value; }
        }

        //スクリーンショットを撮る
        public void screenshot(string filename)
        {
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            string save_dir = workDir + filename + ".png";
            sc.SaveAsFile(save_dir, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //スクリーンショットを撮る（ディレクトリ指定）
        public void screenshot_as(string save_path)
        {
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            sc.SaveAsFile(save_path, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }

        //fullpage screenshotを撮る
        public void fullpage_screenshot(string filename)
        {
            //IJavaScriptExecutor jsexe = (IJavaScriptExecutor)wd;
            string ret = jexe.ExecuteScript("return document.body.parentNode.scrollHeight;").ToString();
            int require_height = Int32.Parse(ret);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, require_height);
            DateUtil.app_sleep(longWait);
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            string save_dir = workDir + @"screenshots\";
            if (!Directory.Exists(save_dir)) Directory.CreateDirectory(save_dir);
            sc.SaveAsFile(save_dir + filename + ".png", OpenQA.Selenium.ScreenshotImageFormat.Png);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
        }

        //fullpage screenshotを撮る（ディレクトリも指定）
        public void fullpage_screenshot_as(string save_path)
        {
            //IJavaScriptExecutor jsexe = (IJavaScriptExecutor)wd;
            string ret = jexe.ExecuteScript("return document.body.parentNode.scrollHeight;").ToString();
            int require_height = Int32.Parse(ret);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, require_height);
            DateUtil.app_sleep(longWait);
            Screenshot sc = ((ITakesScreenshot)_wd).GetScreenshot();
            sc.SaveAsFile(save_path, OpenQA.Selenium.ScreenshotImageFormat.Png);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
        }

        //シャットダウン
        public void shutdown()
        {
            _wd.Quit();
        }

        //ログイン
        public void login()
        {
            _wd.FindElement(By.Id("uid")).SendKeys(uid);
            _wd.FindElement(By.Id("pswd")).SendKeys(pswd);
            _wd.FindElement(By.Id("btn")).Click();
        }

        //ログアウト
        public void logout()
        {
            _wd.Navigate().GoToUrl(index_url);
            DateUtil.app_sleep(shortWait);
            IWebElement btnWrap = _wd.FindElement(By.Id("btn"));
            IWebElement btnBase = btnWrap.FindElement(By.TagName("ul"));
            IWebElement btnBaseInner = btnBase.FindElement(By.ClassName("btn2"));
            IWebElement btnA = btnBaseInner.FindElement(By.TagName("a"));
            btnA.Click();
        }

        //レポートインデックスページに遷移
        public void browse_repo()
        {
            _wd.Navigate().GoToUrl(rep_index_url_base + _projectID);
        }

        //検査メインページに移動
        public void browse_sv_mainpage()
        {
            _wd.Navigate().GoToUrl(sv_mainpage_url_base + _projectID);

            //basic認証の処理
            if(_basic_auth_flag.Equals("yes") && _basic_authenicated == false)
            {
                MessageBox.Show("basicAuthオプションが有効化されています。ログインアラートで認証を済ませた後、Enterキーを入力してください。");
                _basic_authenicated = true;
            }
        }

        //レポート詳細ページのURL生成
        public string fetch_report_detail_path(string pageID, string guidelineID)
        {
            return rep_detail_url_base + _projectID + "/controlID/" + pageID + "/guideline/" + guidelineID + "/";
        }

        //DOMを取得
        public AngleSharp.Dom.Html.IHtmlDocument get_dom()
        {
            AngleSharp.Parser.Html.HtmlParser parser = new AngleSharp.Parser.Html.HtmlParser();
            AngleSharp.Dom.Html.IHtmlDocument dom = parser.Parse(_wd.PageSource);
            return dom;
        }

        //サイト一覧を取得
        public List<List<string>> get_site_list()
        {
            List<List<string>> data = new List<List<string>>();
            IWebElement tbl = _wd.FindElement(By.Id("myTable"));
            IEnumerable<IWebElement> trs = tbl.FindElements(By.TagName("tr")).Cast<IWebElement>();
            int cnt = 0;
            foreach(IWebElement tr in trs)
            {
                if (cnt < 1) continue;
                IEnumerable<IWebElement> tds = tr.FindElements(By.TagName("td")).Cast<IWebElement>();
                IWebElement td1 = null;
                IWebElement td2 = null;
                int incnt = 0;
                foreach(IWebElement td in tds)
                {
                    if (incnt == 0) td1 = td;
                    if (incnt == 1) td2 = td;
                    incnt++;
                }
                List<string> row = new List<string>();
                row.Add(td1.Text);
                row.Add(td2.Text);
                data.Add(row);
                cnt++;
            }
            return data;
        }


    }
}
