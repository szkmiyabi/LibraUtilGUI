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
using System.Text.RegularExpressions;

namespace LibraUtilGUI
{
    public class LibraDriver
    {
        private Form1 form1;
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
        public LibraDriver(Form1 form1, string uid, string pswd, int[] appWait, string driver_type, string headless_flag, string basic_auth_flag, string workDir)
        {
            this.form1 = form1;
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
            _windowID = _wd.WindowHandles[0];
            _jexe = (IJavaScriptExecutor)_wd;
        }

        //operationStatusReportのデリゲート
        public delegate void d_messanger(string msg);
        public void w_messanger(string msg)
        {
            form1.operationStatusReport.AppendText(msg + "\r\n");
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

        //ホームページを開く
        public void home()
        {
            _wd.Navigate().GoToUrl(app_url);
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
            //basic認証の処理
            if (_basic_auth_flag.Equals("yes") && _basic_authenicated == false)
            {
                d_messanger message = new d_messanger(w_messanger);
                form1.Invoke(message, "【お知らせ】基本認証オプションが有効化されています。ログインアラートで認証してください。");
                _basic_authenicated = true;
            }
            _wd.Navigate().GoToUrl(sv_mainpage_url_base + _projectID);
        }

        //レポート詳細ページのURL生成
        public string fetch_report_detail_path(string pageID, string guidelineID)
        {
            return rep_detail_url_base + _projectID + "/controlID/" + pageID + "/guideline/" + guidelineID + "/";
        }

        //サイト一覧を取得
        public List<List<string>> get_site_list()
        {
            List<List<string>> data = new List<List<string>>();
            var parser = new AngleSharp.Parser.Html.HtmlParser();
            var dom = parser.Parse(_wd.PageSource);
            var tbl = dom.GetElementById("myTable");

            var trs = tbl.GetElementsByTagName("tr");
            int nx = trs.Count<AngleSharp.Dom.IElement>();
            for(int i=1; i<nx; i++)
            {
                var tds = trs.ElementAt<AngleSharp.Dom.IElement>(i).GetElementsByTagName("td");

                List<string> row = new List<string>();
                string td1 = TextUtil.text_clean(tds.ElementAt<AngleSharp.Dom.IElement>(0).TextContent);
                string td2 = TextUtil.text_clean(tds.ElementAt<AngleSharp.Dom.IElement>(1).TextContent);
                row.Add(td1);
                row.Add(td2);
                data.Add(row);
            }
            return data;
        }


        //PID+URL一覧データを生成
        public List<List<string>> get_page_list_data()
        {
            List<List<string>> data = new List<List<string>>();
            var parser = new AngleSharp.Parser.Html.HtmlParser();
            var dom = parser.Parse(_wd.PageSource);
            var tbls = dom.GetElementsByTagName("table");
            var tbl = tbls.ElementAt<AngleSharp.Dom.IElement>(2);

            List<string> col1 = new List<string>();
            List<string> col2 = new List<string>();

            var first_tds = tbl.QuerySelectorAll("tr td:first-child");
            int fnx = first_tds.Count<AngleSharp.Dom.IElement>();
            for(int i=0; i<fnx; i++)
            {
                string pageID = TextUtil.text_clean(first_tds.ElementAt<AngleSharp.Dom.IElement>(i).TextContent);
                col1.Add(pageID);
            }
            var second_tds = tbl.QuerySelectorAll("tr td:nth-child(2)");
            int snx = second_tds.Count<AngleSharp.Dom.IElement>();
            for(int i=0; i<snx; i++)
            {
                string pageURL = TextUtil.text_clean(second_tds.ElementAt<AngleSharp.Dom.IElement>(i).TextContent);
                col2.Add(pageURL);
            }

            int nx = 0;
            if (fnx == snx) nx = fnx;
            for(int n=0; n<fnx; n++)
            {
                List<string> data_row = new List<string>();
                string vl1 = col1[n];
                string vl2 = col2[n];
                data_row.Add(vl1);
                data_row.Add(vl2);
                data.Add(data_row);
            }

            return data;
        }
        
        //PID+URL一覧データを生成（検査メイン画面から）
        public List<List<string>> get_page_list_data_from_svpage()
        {
            List<List<string>> data = new List<List<string>>();
            var url_ddl = _wd.FindElement(By.Id("urlList"));
            var opts = url_ddl.FindElements(By.TagName("option"));
            for(int i=0; i<opts.Count<IWebElement>(); i++)
            {
                IWebElement opt = opts.ElementAt<IWebElement>(i);
                List<string> row = new List<string>();
                string v1 = opt.GetAttribute("value");
                string v2 = _get_option_urltext(opt);
                row.Add(v1);
                row.Add(v2);
                data.Add(row);
            }
            return data;
        }
        private string _get_option_urltext(IWebElement opt)
        {
            string ret = "";
            string val = opt.Text;
            Regex pt = new Regex(@"(\[[a-zA-Z0-9\-]+\] )(.+)");
            if (pt.IsMatch(val))
            {
                MatchCollection mc = pt.Matches(val);
                ret = mc[0].Groups[2].Value;
            }
            return ret;
        }


    }
}
