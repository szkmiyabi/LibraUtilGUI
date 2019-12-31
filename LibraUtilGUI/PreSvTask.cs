using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraUtilGUI
{
    partial class Form1
    {
        //解析レポートを作成
        private void create_presv_report()
        {
            Task.Run(() =>
            {
                d_status_messenger message = w_status_messenger;
                d_get_projectID _d_get_projectID = w_get_projectID;
                d_ldr_activate ldr_activate = w_ldr_activate;
                d_task_cancel canceler = w_task_cancel;
                d_get_workDir _d_get_workDir = w_get_workDir;
                d_is_pageID_selected _is_pageID_selected = w_is_pageID_selected;
                d_pageID_data get_page_rows = w_pageID_data;
                d_get_presv_operation get_operation_rows = w_get_presv_operation;
                d_get_layer_flag _get_layer_flag = w_get_layer_flag;

                if (ldr_activated == false)
                {
                    //Libraドライバ起動しエラーの場合早期退出
                    if (!(Boolean)this.Invoke(ldr_activate)) return;
                }

                ldr.home();
                this.Invoke(message, "Libraにログインします。（" + DateUtil.get_logtime() + "）");
                ldr.login();
                DateUtil.app_sleep(shortWait);

                string projectID = (string)this.Invoke(_d_get_projectID);
                ldr.projectID = projectID;

                //サイト名取得
                this.Invoke(message, "レポートインデックスページに移動します。（" + DateUtil.get_logtime() + "）");
                ldr.browse_repo();
                DateUtil.app_sleep(shortWait);
                string site_name = ldr.get_site_name();

                //解析結果保存ディレクトリ作成
                string save_path = (string)this.Invoke(_d_get_workDir) + projectID + "_" + site_name + @"\";
                if (!Directory.Exists(save_path)) Directory.CreateDirectory(save_path);

                //pageIDコンボから選択値を取得
                List<List<string>> page_rows = (List<List<string>>)this.Invoke(get_page_rows);

                //operationコンボから選択値を取得
                List<string> operation_rows = (List<string>)this.Invoke(get_operation_rows);

                //重ね掛け判定
                Boolean layer_flag = (Boolean)this.Invoke(_get_layer_flag);

                this.Invoke(message, "解析対象ページに順次アクセスしていきます。（" + DateUtil.get_logtime() + "）");

                //pageのループ
                foreach(var page_row in page_rows)
                {
                    string pageID = page_row[0];
                    string pageURL = page_row[1];
                    this.Invoke(message, pageID + " を処理しています。（" + DateUtil.get_logtime() + "）");
                    ldr.wd.Navigate().GoToUrl(pageURL);
                    DateUtil.app_sleep(shortWait);

                    //タスクのキャンセル判定
                    if ((Boolean)this.Invoke(canceler)) return;

                    //operationのループ
                    foreach(string opt in operation_rows)
                    {
                        switch (opt)
                        {
                            case "css-cut":
                                ldr.jexe.ExecuteScript(JsUtil.css_cut());
                                break;
                            case "document-link":
                                ldr.jexe.ExecuteScript(JsUtil.document_link());
                                break;
                            case "target-attr":
                                ldr.jexe.ExecuteScript(JsUtil.target_attr());
                                break;
                            case "image-alt":
                                ldr.jexe.ExecuteScript(JsUtil.image_alt());
                                break;
                            case "lang-attr":
                                ldr.jexe.ExecuteScript(JsUtil.lang_attr());
                                break;
                            case "semantic-check":
                                ldr.jexe.ExecuteScript(JsUtil.semantic_check());
                                break;
                            case "tag-label-and-title-attr":
                                ldr.jexe.ExecuteScript(JsUtil.tag_label_and_title_attr());
                                break;
                        }
                        if(layer_flag == false)
                        {
                            ldr.fullpage_screenshot_as(save_path + pageID + "." + opt + ".png");
                            ldr.wd.Navigate().GoToUrl(pageURL); //reload
                        }
                    }
                    if(layer_flag == true)
                    {
                        string sufix = "";
                        foreach(string cop in operation_rows)
                        {
                            sufix += cop + ".";
                        }
                        ldr.fullpage_screenshot_as(save_path + pageID + "." + sufix + "png");
                    }

                }

                ldr.logout();
                this.Invoke(message, "処理が完了しました。（" + DateUtil.get_logtime() + "）");

            });
        }
    }
}
