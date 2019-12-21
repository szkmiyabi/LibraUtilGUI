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
        private void set_projectID_combo()
        {

            Task.Run(() =>
            {
                _set_projectID_combo_ worker = new _set_projectID_combo_(_set_projectID_combo_worker);

                if (ldr_activated == false)
                {
                    load_wd();
                }

                ldr.home();
                ldr.login();
                DateUtil.app_sleep(5);

                List<List<string>> data = ldr.get_site_list();
                this.Invoke(worker, data);

                ldr.logout();

            });

        }
        private void _set_projectID_combo_worker(List<List<string>> data)
        {
            for(int i=0; i<data.Count; i++)
            {
                List<string> col = (List<string>) data[i];
                string text = col[0] + " " + col[1];
                projectIDListBox.Items.Add(text);
            }
        }




    }
}
