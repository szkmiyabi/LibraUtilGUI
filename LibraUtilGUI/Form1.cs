﻿using System;
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

        //Form1インスタンス
        private static Form1 _main_form;

        private static DataGridForm _data_grid_form;

        //Taskのキャンセル
        private CancellationTokenSource token_src;
        private CancellationToken token;

        //Errorバッファ
        private string error_buff;

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            //環境設定のロード
            settings_filename = Application.UserAppDataPath + @"\settings.config";
            loadAppSettings();

            //ガイドラインIDコンボの処理
            init_guideline_combo();

            //静的プロパティに自身を代入
            _main_form = this;

            //Errorバッファ初期化
            error_buff = "";

            //Imageボタンの初期化
            imgButtonInit();

            //起動時のコントロール無効化設定
            createSiteInfoBookButton.Enabled = false;
            pageIDLoadButton.Enabled = false;
            pageIDListBoxSelectAllButton.Enabled = false;
            pageIDListBoxSelectClearButton.Enabled = false;
            
            techIDLoadButton.Enabled = false;
            techSelectAllButton.Enabled = false;
            techSelectClearButton.Enabled = false;

            openAsFirefoxButton.Enabled = false;
            openAsIEButton.Enabled = false;
            openAsChromeButton.Enabled = false;

        }

        //Formのゲッターとセッター
        public static Form1 main_form
        {
            get { return _main_form; }
            set { _main_form = value; }
        }

        //DataGridFormのゲッター
        public static DataGridForm data_grid_form
        {
            get
            {
                if(_data_grid_form == null || _data_grid_form.IsDisposed)
                {
                    _data_grid_form = new DataGridForm();
                }
                return _data_grid_form;
            }
        }

        //wdインスタンス生成
        private Boolean load_wd()
        {
            Boolean flag = false;

            if (checkSettings() == false) return flag;

            try
            {
                int[] appWait = { systemWait, longWait, midWait, shortWait };
                ldr = new LibraDriver(uid, pswd, appWait, driver, headless, basic_auth, workDir, debugMode);
                ldr_activated = true;
                flag = true;
            }
            catch(Exception ex)
            {
                error_buff = ex.Message;
            }
            return flag;
        }
        
        //wdインスタンス解放
        private void destroy_wd()
        {
            if(ldr != null) ldr.shutdown();
        }

        //子フォームインスタンス解放
        private void destroy_child_form()
        {
            if(data_grid_form != null || !data_grid_form.IsDisposed)
            {
                data_grid_form.Dispose();
            }
        }

        //ガイドラインIDコンボの設定
        private void init_guideline_combo()
        {
            List<guidelineComboItem> ListBoxItem = new List<guidelineComboItem>();
            List<string> guideline_arr = guidelineComboItem.get_guideline_list(guidelineLevel);
            guidelineComboItem itm;
            for(int i=0; i<guideline_arr.Count; i++)
            {
                string val = (string)guideline_arr[i];
                itm = new guidelineComboItem(val, val);
                ListBoxItem.Add(itm);
            }
            guidelineListBox.DisplayMember = "id_str";
            guidelineListBox.ValueMember = "display_str";
            guidelineListBox.DataSource = ListBoxItem;
            SendMessage(guidelineListBox.Handle, LB_SETSEL, 0, -1);
            guidelineListBox.SetSelected(0, false);
        }

        //設定ボタンクリック
        private void openAsSettingButton_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

        //作業フォルダボタンクリック
        private void openAsFolderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(workDir);
        }

        //フォームを閉じようとしたとき
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            destroy_child_form();
            destroy_wd();
        }

        //サイトID読込クリック
        private void projectIDLoadButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            set_projectID_combo();
        }

        //ページID読込クリック
        private void pageIDLoadButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            set_pageID_combo();
        }

        //ページID全選択クリック
        private void pageIDListBoxSelectAllButton_Click(object sender, EventArgs e)
        {
            SendMessage(pageIDListBox.Handle, LB_SETSEL, 1, -1);
            pageIDListBox.SetSelected(0, true);
        }

        //ページID選択解除クリック
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

            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;

            //条件分岐で処理実行
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

        //URLオペレーション処理キャンセル
        private void cancelUrlTaskButton_Click(object sender, EventArgs e)
        {
            token_src.Cancel();
        }

        //ガイドライン全選択クリック
        private void guidelineSelectAllButton_Click(object sender, EventArgs e)
        {
            SendMessage(guidelineListBox.Handle, LB_SETSEL, 1, -1);
            guidelineListBox.SetSelected(0, true);
        }

        //ガイドライン選択解除クリック
        private void guidelineSelectClearButton_Click(object sender, EventArgs e)
        {
            SendMessage(guidelineListBox.Handle, LB_SETSEL, 0, -1);
            guidelineListBox.SetSelected(0, false);
        }

        //Excel出力クリック
        private void createSiteInfoBookButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            create_site_info_book();
        }

        //REPORTオペレーション処理実行
        private void doRepoTaskButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;

            string mode = "";
            if (RepoTaskModeExcel.Checked) mode = "excel";
            else if (RepoTaskModeDataGrid.Checked) mode = "datagrid";

            //処理実行
            switch (mode)
            {
                case "excel":
                    create_survey_report();
                    break;
                case "datagrid":
                    display_survey_report();
                    break;
            }
        }

        //レポートオペレーション処理キャンセル
        private void cancelRepoTaskButton_Click(object sender, EventArgs e)
        {
            token_src.Cancel();
        }

        //PRESVオペレーション処理実行
        private void doPreSvTaskButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            create_presv_report();
        }

        //PRESVオペレーション処理キャンセル
        private void cancelPreSvTaskButton_Click(object sender, EventArgs e)
        {
            token_src.Cancel();
        }

        //BrowseTask Firefoxをクリック
        private void openAsFirefoxButton_Click(object sender, EventArgs e)
        {
            do_browse_page_as("firefox");
        }

        //BrowseTask IEをクリック
        private void openAsIEButton_Click(object sender, EventArgs e)
        {
            do_browse_page_as("ie");
        }

        //BrowseTask Chromeをクリック
        private void openAsChromeButton_Click(object sender, EventArgs e)
        {
            do_browse_page_as("chrome");
        }

        //達成基準ID読み込みクリック
        private void techIDLoadButton_Click(object sender, EventArgs e)
        {
            set_techID_combo();
        }
        //達成基準ID全選択クリック
        private void techSelectAllButton_Click(object sender, EventArgs e)
        {
            SendMessage(techListBox.Handle, LB_SETSEL, 1, -1);
            techListBox.SetSelected(0, true);
        }
        //達成基準ID選択解除クリック
        private void techSelectClearButton_Click(object sender, EventArgs e)
        {
            SendMessage(techListBox.Handle, LB_SETSEL, 0, -1);
            techListBox.SetSelected(0, false);
        }

        //SRCオペレーション処理実行
        private void doSrcTaskButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            display_srccode_report();
        }

        //DOM展開後ソース取得ボタンクリック
        private void doDomExpandedSrccodeButton_Click(object sender, EventArgs e)
        {
            //CancellationTokenを発行
            token_src = new CancellationTokenSource();
            token = token_src.Token;
            //処理実行
            get_dom_expanded_srccode();
        }
    }

}
