using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{

    partial class Form1
    {

        //サンプルメソッド
        public delegate void BufTxtWriteDelg();
        public delegate void TxtWriteDelg(string txt);
        private void test_method()
        {


            //非同期処理で実行
            Task task = Task.Run(() =>
            {
                //デリゲートのインスタンス生成
                BufTxtWriteDelg btwdl = new BufTxtWriteDelg(_buf_txt_write);

                if (ldr_activated == false)
                {
                    load_wd();
                }

                ldr.home();
                DateUtil.app_sleep(3);

                ldr.login();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));


                txt_buf = "ログインしました。";
                this.Invoke(btwdl);

                var parser = new AngleSharp.Parser.Html.HtmlParser();
                var dom = parser.Parse(ldr.wd.PageSource);
                string src = dom.DocumentElement.OuterHtml;
                TxtWriteDelg twdl = new TxtWriteDelg(_txt_write);
                this.Invoke(twdl, src);

                ldr.projectID = "600";
                txt_buf = "プロジェクトIDセットしました。";
                this.Invoke(btwdl);

                ldr.browse_repo();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));
                txt_buf = "レポートインデックスページにアクセスしました。";
                this.Invoke(btwdl);

                ldr.logout();

                txt_buf = "処理が終了しました。";
                this.Invoke(btwdl);

            });
        }
        public void _buf_txt_write()
        {
            operationStatusReport.AppendText(txt_buf);
            operationStatusReport.AppendText("\r\n");
        }

        public void _txt_write(string txt)
        {
            operationStatusReport.AppendText(txt);
            operationStatusReport.AppendText("\r\n");
        }



        //プロジェクトIDコンボをセット
        public delegate void _set_projectID_combo_(List<List<string>> data);
        public delegate void _set_projectID_combo_msg_(string msg);
        private void set_projectID_combo()
        {

            Task.Run(() =>
            {
                _set_projectID_combo_ worker = new _set_projectID_combo_(_set_projectID_combo_worker);
                _set_projectID_combo_msg_ message = new _set_projectID_combo_msg_(_set_projectID_combo_msg_dispatcher);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_site_list();
                this.Invoke(message, "サイト一覧を取得しています。（" + DateUtil.get_logtime() + "）");
                this.Invoke(worker, data);
                this.Invoke(message, "サイト名コンボが設定完了しました。（" + DateUtil.get_logtime() + "）");
                ldr.logout();
            });

        }
        private void _set_projectID_combo_worker(List<List<string>> data)
        {
            List<projectIDComboItem> ListBoxItem = new List<projectIDComboItem>();
            projectIDComboItem itm;
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>) data[i];
                string text = col[0] + "  " + col[1];
                itm = new projectIDComboItem(col[0], text);
                ListBoxItem.Add(itm);
            }
            projectIDListBox.DisplayMember = "display_str";
            projectIDListBox.ValueMember = "id_str";
            projectIDListBox.DataSource = ListBoxItem;
            pageIDLoadButton.Enabled = true;

        }
        private void _set_projectID_combo_msg_dispatcher(string msg)
        {
            operationStatusReport.AppendText(msg + "\r\n");
        }



        //ページIDコンボをセット
        public delegate void _set_pageID_combo_(List<List<string>> data);
        public delegate string _get_projectID_gate_();
        public delegate void _set_pageID_combo_msg_(string msg);
        private void set_pageID_combo()
        {

            Task.Run(() =>
            {
                _set_pageID_combo_ worker = new _set_pageID_combo_(_set_pageID_combo_worker);
                _get_projectID_gate_ gate = new _get_projectID_gate_(_get_projectID_gate_dispatcher);
                _set_projectID_combo_msg_ message = new _set_projectID_combo_msg_(_set_projectID_combo_msg_dispatcher);

                if (ldr_activated == false)
                {
                    load_wd();
                    this.Invoke(message, "ブラウザドライバを起動しています。（" + DateUtil.get_logtime() + "）");
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string cr = (string) this.Invoke(gate);
                ldr.projectID = cr;

                this.Invoke(message, "レポートインデックスページにアクセスしています。（" + DateUtil.get_logtime() + "）");
                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);

                List<List<string>> data = ldr.get_page_list_data();
                this.Invoke(worker, data);
                this.Invoke(message, "ページIDコンボが設定完了しました。（" + DateUtil.get_logtime() + "）");

                ldr.logout();
            });
        }
        private void _set_pageID_combo_worker(List<List<string>> data)
        {
            List<pageIDComboItem> ListBoxItem = new List<pageIDComboItem>();
            pageIDComboItem itm;
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>)data[i];
                string text = col[0] + "  " + col[1];
                itm = new pageIDComboItem(col[1], text);
                ListBoxItem.Add(itm);
            }
            pageIDListBox.DisplayMember = "display_str";
            pageIDListBox.ValueMember = "id_str";
            pageIDListBox.DataSource = ListBoxItem;
            doOperationButton.Enabled = true;
            cancelOperationButton.Enabled = true;
        }
        private string _get_projectID_gate_dispatcher()
        {
            string cr = projectIDListBox.SelectedValue.ToString();
            return cr;
        }
        private void _set_pageID_combo_msg_dispatcher(string msg)
        {
            operationStatusReport.AppendText(msg + "\r\n");
        }

    }


}
