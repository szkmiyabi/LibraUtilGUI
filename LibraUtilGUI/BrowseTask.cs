using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    partial class Form1
    {
        //選択されたPIDのページをブラウズ
        private void do_browse_page_as(string browser_name)
        {

            Task.Run(() =>
            {
                d_get_browse_mode _mode = w_get_browse_mode;
                d_get_projectID _projectID = w_get_projectID;
                d_pageID_data _page_rows = w_pageID_data;
                d_ldr_activate _ldr_activate = w_ldr_activate;

                string mode = (string)this.Invoke(_mode);
                string projectId = (string)this.Invoke(_projectID);
                List<List<string>> page_rows = (List<List<string>>)this.Invoke(_page_rows);

                foreach (List<string> col in page_rows)
                {
                    string pageID = col[0];
                    string pageURL = col[1];

                    if (mode == "normal")
                    {
                        switch (browser_name)
                        {
                            case "firefox":
                                browseByFirefox(pageURL);
                                break;
                            case "ie":
                                browseByIE(pageURL);
                                break;
                            case "chrome":
                                browseByChrome(pageURL);
                                break;
                        }
                    }
                    else if(mode == "survey")
                    {
                        if (ldr_activated == false)
                        {
                            if (!(Boolean)this.Invoke(_ldr_activate)) return;
                            ldr.projectID = _projectID();
                        }
                        string svpage_url = ldr.get_sv_mainpage_url() + "/controlID/\"" + pageID + "\"";
                        switch (browser_name)
                        {
                            case "firefox":
                                browseByFirefox(svpage_url);
                                break;
                            case "ie":
                                browseByIE(svpage_url);
                                break;
                            case "chrome":
                                browseByChrome(svpage_url);
                                break;
                        }
                    }
                }
            });
        }

        //IEでURLを開く
        private void browseByIE(string burl)
        {
            try
            {
                System.Diagnostics.Process.Start(iePath, " " + burl);
            }
            catch (Exception ex)
            {
            }
        }

        //FirefoxでURLを開く
        private void browseByFirefox(string burl)
        {
            try
            {
                System.Diagnostics.Process.Start(ffPath, "-new-tab " + burl);
            }
            catch (Exception ex)
            {
            }
        }

        //ChromeでURLを開く
        private void browseByChrome(string burl)
        {
            try
            {
                System.Diagnostics.Process.Start(gcPath, " " + burl);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
