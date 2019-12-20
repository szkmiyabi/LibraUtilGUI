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
        private void test_method()
        {

            //非同期処理で実行
            Task task = Task.Run(() =>
            {
                //デリゲートのインスタンス生成
                BufTxtWriteDelg btwdl = new BufTxtWriteDelg(buf_txt_write);

                int[] appWait = { systemWait, longWait, midWait, shortWait };
                LibraDriver ldr = new LibraDriver(uid, pswd, appWait, driver, headless, basic_auth, workDir);
                ldr.login();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));


                txt_buf = "ログインしました。";
                this.Invoke(btwdl);

                AngleSharp.Dom.Html.IHtmlDocument dom = ldr.get_dom();
                string src = dom.DocumentElement.OuterHtml;
                TxtWriteDelg twdl = new TxtWriteDelg(txt_write);
                this.Invoke(twdl, new object[] { src });

                ldr.projectID = "600";
                txt_buf = "プロジェクトIDセットしました。";
                this.Invoke(btwdl);

                ldr.browse_repo();
                DateUtil.app_sleep(5);
                ldr.fullpage_screenshot(DateUtil.fetch_filename_from_datetime("png"));
                txt_buf = "レポートインデックスページにアクセスしました。";
                this.Invoke(btwdl);

                ldr.logout();
                ldr.shutdown();
                txt_buf = "処理が終了しました。";
                this.Invoke(btwdl);

            });
        }
    }
}
