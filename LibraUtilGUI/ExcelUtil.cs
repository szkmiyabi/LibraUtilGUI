using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;

namespace LibraUtilGUI
{
    class ExcelUtil
    {
        private Form1 main_form;

        //コンストラクタ
        public ExcelUtil()
        {
            main_form = Form1.main_form;
        }

        //デリゲート
        public delegate void d_messenger(string msg);
        public void w_messenger(string msg)
        {
            main_form.operationStatusReport.AppendText(msg + "\r\n");
        }

        //最大文字数32767に収める
        private string fetch_overflow_characters(string data)
        {
            if(data.Length > 32767)
            {
                string prefix = "【注意】セルに入力可能な文字数の上限を超えました。32767文字以降は切り捨てられます。\n\n";
                int prefix_cnt = prefix.Length + 1;
                return prefix + data.Substring(0, (32767 - prefix_cnt));
            }
            else
            {
                return data;
            }
        }

        //Excelファイルに出力
        public void save_xlsx_as(List<List<string>> data, string filename)
        {
            d_messenger message = new d_messenger(w_messenger);

            try
            {
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Sheet1");

                    //行のループ
                    for (int i = 0; i < data.Count; i++)
                    {
                        List<string> row = (List<string>)data[i];

                        //列のループ
                        for (int j = 0; j < row.Count; j++)
                        {
                            string col = (string)row[j];
                            ws.Cell(i + 1, j + 1).Value = fetch_overflow_characters(col);
                            ws.Cell(i + 1, j + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;


                        }

                    }

                    wb.SaveAs(filename);
                    main_form.Invoke(message, "保存に成功しました。（" + filename + "）");
                }
            }
            catch(Exception ex)
            {
                main_form.Invoke(message, "【エラー】" + ex.Message);
                return;
            }



        }

        //Excelファイルに出力（RepoTask）
        public void repo_task_save_xlsx(List<List<string>> data, string filename)
        {
            d_messenger message = new d_messenger(w_messenger);

            try
            {
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("検査結果");

                    int sv_index = 5;

                    //行のループ
                    for (int i = 0; i < data.Count; i++)
                    {
                        List<string> row = (List<string>)data[i];

                        //列のループ
                        for (int j = 0; j < row.Count; j++)
                        {
                            string col = (string)row[j];
                            col = TextUtil.trim(col);

                            //32767文字を超える文字列処理
                            col = fetch_overflow_characters(col);


                            //達成基準番号をJIS2016形式に変換
                            if (i > 0 && j == 2)
                            {
                                col = TextUtil.jis2016_encode(col);
                            }

                            //達成基準番号が日付に変換されるためSetValue<string>()を使用する
                            ws.Cell(i + 1, j + 1).SetValue<string>(col);

                            //基本的な書式設定
                            ws.Cell(i + 1, j + 1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                            ws.Cell(i + 1, j + 1).Style.Font.FontName = "ＭＳ Ｐゴシック";
                            ws.Cell(i + 1, j + 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                            ws.Cell(i + 1, j + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                            //header cell
                            if (i == 0)
                            {
                                ws.Cell(i + 1, j + 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Cell(i + 1, j + 1).Style.Font.Bold = true;
                            }
                            //data cell
                            else
                            {

                                string sv_val = (string)row[sv_index];
                                sv_val = TextUtil.trim(sv_val);

                                if (sv_val == "適合")
                                {
                                    ws.Cell(i + 1, j + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(0x00CCFF);
                                }
                                else if (sv_val == "適合(注記)")
                                {
                                    ws.Cell(i + 1, j + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(0x00FF00);
                                }
                                else if (sv_val == "不適合")
                                {
                                    ws.Cell(i + 1, j + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(0xFF8080);
                                }
                                else if (sv_val == "非適用")
                                {
                                    ws.Cell(i + 1, j + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(0xC0C0C0);
                                }
                            }
                        }
                    }

                    wb.SaveAs(filename);
                    main_form.Invoke(message, "保存に成功しました。（" + filename + "）");
                }
            }
            catch(Exception ex)
            {
                main_form.Invoke(message, "【エラー】" + ex.Message);
                return;
            }

        }


    }
}
