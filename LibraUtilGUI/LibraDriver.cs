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
using System.Text.RegularExpressions;

namespace LibraUtilGUI
{
    public class LibraDriver
    {
        private Form1 main_form;
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
        public LibraDriver(string uid, string pswd, int[] appWait, string driver_type, string headless_flag, string basic_auth_flag, string workDir, string debugMode)
        {
            main_form = Form1.main_form;
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
                FirefoxDriverService fxserv = FirefoxDriverService.CreateDefaultService(workDir);
                fxserv.FirefoxBinaryPath = get_firefox_binary_path();
                if(debugMode == "no") fxserv.HideCommandPromptWindow = true;
                if (headless_flag.Equals("yes")) fxopt.AddArguments("-headless");
                _wd = new FirefoxDriver(fxserv, fxopt);
            }
            else if (driver_type.Equals("chrome"))
            {
                ChromeOptions chopt = new ChromeOptions();
                ChromeDriverService chserv = ChromeDriverService.CreateDefaultService(workDir);
                if(debugMode == "no") chserv.HideCommandPromptWindow = true;
                if (headless_flag.Equals("yes")) chopt.AddArguments("--headless");
                _wd = new ChromeDriver(chserv, chopt);
            }

            _wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(systemWait);
            _wd.Manage().Window.Size = new System.Drawing.Size(1280, 900);
            _windowID = _wd.WindowHandles[0];
            //MessageBox.Show(_windowID);
            _jexe = (IJavaScriptExecutor)_wd;
        }

        //Firefoxバイナリパスの取得
        private string get_firefox_binary_path()
        {
            string ffpath = "";
            string ffpath1 = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            string ffpath2 = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            if (System.IO.File.Exists(ffpath1)) ffpath = ffpath1;
            else if (System.IO.File.Exists(ffpath2)) ffpath = ffpath2;
            return ffpath;
        }

        //operationStatusReportのデリゲート
        public delegate void d_messenger(string msg);
        public void w_messenger(string msg)
        {
            main_form.operationStatusReport.AppendText(msg + "\r\n");
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
                d_messenger message = new d_messenger(w_messenger);
                main_form.Invoke(message, "【お知らせ】基本認証オプションが有効化されています。ログインアラートで認証してください。");
                _basic_authenicated = true;
            }
            _wd.Navigate().GoToUrl(sv_mainpage_url_base + _projectID);
        }

        //レポート詳細ページのURL生成
        public string fetch_report_detail_path(string pageID, string guidelineID)
        {
            return rep_detail_url_base + _projectID + "/controlID/" + pageID + "/guideline/" + guidelineID + "/";
        }

        //達成基準番号を選択
        public void select_guideline(string guidelineID)
        {
            IWebElement guidelineSelect = _wd.FindElement(By.Id("guideline"));
            var guidelineOptions = guidelineSelect.FindElements(By.TagName("option"));
            for (int i = 0; i< guidelineOptions.Count<IWebElement>(); i++)
            {
                if (i == 0) continue;
                IWebElement guidelineOP = guidelineOptions.ElementAt<IWebElement>(i);
                string guidelineOP_val = guidelineOP.Text.TrimStart().TrimEnd();
                Regex pt = new Regex(guidelineID + @".*");
                if(pt.IsMatch(guidelineOP_val))
                {
                    guidelineOP.Click();
                    break;
                }
            }
        }

        //実装番号一覧を取得
        public List<string> get_tech_list()
        {
            List<string> data = new List<string>();
            Func<List<string>, string, Boolean> _contains = delegate (List<string> arr, string str)
            {
                Boolean flg = true;
                if (arr.Count < 1)
                {
                    flg = false;
                }
                else if (arr.Contains(str) == false)
                {
                    flg = false;
                }
                return flg;
            };
            var tbl = _wd.FindElements(By.TagName("table")).ElementAt<IWebElement>(2);
            var trs = tbl.FindElements(By.TagName("tr"));

            for (int i = 0; i < trs.Count<IWebElement>(); i++)
            {
                if (i == 0) continue;
                var tr = trs.ElementAt<IWebElement>(i);
                var tds = tr.FindElements(By.TagName("td"));
                var td = tds.ElementAt<IWebElement>(1);
                string td_val = td.Text.TrimStart().TrimEnd();
                if (!_contains(data, td_val)) data.Add(td_val);
            }

            return data;
        }

        //実装番号一覧を取得（検査メイン画面から）
        public List<string> get_tech_list_from_svpage(){
            List<string> data = new List<string>();
            IWebElement techSelect = _wd.FindElement(By.Id("techList"));
            var techOptions = techSelect.FindElements(By.TagName("option"));
            for(int i=0; i<techOptions.Count<IWebElement>(); i++)
            {
                if (i == 0) continue;
                IWebElement techOP = techOptions.ElementAt<IWebElement>(i);
                string techOP_val = techOP.Text.TrimStart().TrimEnd();
                Regex pt = new Regex(@"([A-Z0-9]+)(.*)");
                if (pt.IsMatch(techOP_val))
                {
                    Match mt = pt.Match(techOP_val);
                    string row = mt.Groups[1].Value;
                    data.Add(row);
                }
            }
            return data;
        }

        //実装番号を選択
        public void select_techlist(string techID)
        {
            IWebElement techSelect = _wd.FindElement(By.Id("techList"));
            var techOptions = techSelect.FindElements(By.TagName("option"));
            for (int i = 0; i < techOptions.Count<IWebElement>(); i++)
            {
                if (i == 0) continue;
                IWebElement techOP = techOptions.ElementAt<IWebElement>(i);
                string techOP_val = techOP.Text.TrimStart().TrimEnd();
                Regex pt = new Regex(techID + @".*");
                if (pt.IsMatch(techOP_val))
                {
                    techOP.Click();
                    _wd.FindElement(By.Id("footer")).Click();
                    break;
                }
            }
        }

        //一括検査画面を表示する
        public void browse_all_sv_page()
        {
            _wd.FindElement(By.XPath("//*[@id='all_btn']/button")).Click();
            DateUtil.app_sleep(longWait);
            var windowsIDS = _wd.WindowHandles;
            foreach(string row in windowsIDS)
            {
                //MessageBox.Show(row);
                if (!row.Equals(_windowID))
                {
                    _wd.SwitchTo().Window(row);
                    break;
                }
            }

        }

        //一括検査画面を退出する
        public void leave_all_sv_page()
        {
            _wd.FindElement(By.Id("close_diag_form")).Click();
            _wd.SwitchTo().Window(_windowID);
            DateUtil.app_sleep(midWait);
        }

        //サイト一覧を取得
        public List<List<string>> get_site_list()
        {
            List<List<string>> data = new List<List<string>>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var trs = tbl.FindElements(By.TagName("tr"));
            int nx = trs.Count<IWebElement>();

            for(int i=1; i<nx; i++)
            {
                var tds = trs.ElementAt<IWebElement>(i).FindElements(By.TagName("td"));
                List<string> row = new List<string>();
                string td1 = TextUtil.text_clean(tds.ElementAt<IWebElement>(0).Text);
                string td2 = TextUtil.text_clean(tds.ElementAt<IWebElement>(1).Text);
                row.Add(td1);
                row.Add(td2);
                data.Add(row);
            }
            return data;
        }

        //サイト名を取得
        public string get_site_name()
        {
            string sname = "";
            var tbls = _wd.FindElements(By.TagName("table"));
            var tbl = tbls.ElementAt<IWebElement>(1);
            var tds = tbl.FindElements(By.CssSelector("tr td"));
            var td = tds.ElementAt<IWebElement>(0);
            string td_val = TextUtil.text_clean(td.Text);
            Regex pt = new Regex(@"(\[)([a-zA-Z0-9]+)(\])(\s*)(.+)");
            if (pt.IsMatch(td_val))
            {
                Match mt = pt.Match(td_val);
                sname = mt.Groups[5].Value;
            }
            return sname;
        }

        //サイトID＋サイト名＋備考＋期間データを取得
        public List<List<string>> get_site_info_data()
        {
            List<List<string>> data = new List<List<string>>();
            var tbl = _wd.FindElement(By.Id("myTable"));
            var trs = tbl.FindElements(By.TagName("tr"));
            int nx = trs.Count<IWebElement>();
            for (int i = 1; i < nx; i++)
            {
                var tds = trs.ElementAt<IWebElement>(i).FindElements(By.TagName("td"));
                List<string> row = new List<string>();
                string id = TextUtil.text_clean(tds.ElementAt<IWebElement>(0).Text);
                string name = TextUtil.text_clean(tds.ElementAt<IWebElement>(1).Text);
                string note = TextUtil.text_clean(tds.ElementAt<IWebElement>(2).Text);
                string period = TextUtil.text_clean(tds.ElementAt<IWebElement>(4).Text);
                row.Add(id);
                row.Add(name);
                row.Add(note);
                row.Add(period);
                data.Add(row);
            }
            return data;
        }


        //PID+URL一覧データを生成
        public List<List<string>> get_page_list_data()
        {
            List<List<string>> data = new List<List<string>>();
            var tbls = _wd.FindElements(By.TagName("table"));
            var tbl = tbls.ElementAt<IWebElement>(2);

            List<string> col1 = new List<string>();
            List<string> col2 = new List<string>();

            var first_tds = tbl.FindElements(By.CssSelector("tr td:first-child"));
            int fnx = first_tds.Count<IWebElement>();
            for(int i=0; i<fnx; i++)
            {
                string pageID = TextUtil.text_clean(first_tds.ElementAt<IWebElement>(i).Text);
                col1.Add(pageID);
            }
            var second_tds = tbl.FindElements(By.CssSelector("tr td:nth-child(2)"));

            int snx = second_tds.Count<IWebElement>();
            for(int i=0; i<snx; i++)
            {
                string pageURL = TextUtil.text_clean(second_tds.ElementAt<IWebElement>(i).Text);
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

        //レポート詳細ページから検査結果データを生成
        public List<List<string>> get_detail_table_data(string pageID, string pageURL, string guideline)
        {
            List<List<string>> data = new List<List<string>>();
            var parser = new AngleSharp.Html.Parser.HtmlParser();
            var dom = parser.ParseDocument(_wd.PageSource);
            var tbl = dom.GetElementsByTagName("table").ElementAt<AngleSharp.Dom.IElement>(2);
            var trs = tbl.GetElementsByTagName("tr");
            for(int i=0; i<trs.Count<AngleSharp.Dom.IElement>(); i++)
            {
                if (i == 0) continue;
                List<string> row_data = new List<string>();
                row_data.Add(pageID);
                row_data.Add(pageURL);
                row_data.Add(guideline);
                var tr = trs.ElementAt<AngleSharp.Dom.IElement>(i);
                var tds = tr.GetElementsByTagName("td");
                int col_num = 0;
                for(int j=0; j<tds.Count<AngleSharp.Dom.IElement>(); j++)
                {
                    var td = tds.ElementAt<AngleSharp.Dom.IElement>(j);
                    string td_val = td.InnerHtml;
                    //コメント列
                    if(col_num == 4)
                    {
                        td_val = TextUtil.br_decode(td_val);
                        td_val = TextUtil.tag_decode(td_val);
                    }
                    //それ以外
                    else
                    {
                        td_val = TextUtil.tag_decode(td_val);
                    }
                    if(td_val == "" || td_val == null)
                    {
                        row_data.Add("");
                    }
                    else
                    {
                        row_data.Add(td_val);
                    }
                    col_num++;
                }
                data.Add(row_data);
            }
            return data;
        }

        //検査メイン画面のURL取得
        public string get_sv_mainpage_url(string pageID)
        {
            return sv_mainpage_url_base + _projectID + "/controlID/\"" + pageID + "\"";
        }

        //対象ソースコード一覧を取得
        public List<string> get_srccode_list()
        {
            browse_all_sv_page();
            List<string> data = new List<string>();
            string ret = "";
            IJavaScriptExecutor act = (IJavaScriptExecutor)_wd;
            ret = (string)act.ExecuteScript(JsUtil.get_srccode_list());
            string[] sep = { "<bkmk:br>" };
            string[] lines = ret.Split(sep, StringSplitOptions.None);
            foreach(string line in lines)
            {
                data.Add(line);
            }
            leave_all_sv_page();
            return data;
        }

    }
}
