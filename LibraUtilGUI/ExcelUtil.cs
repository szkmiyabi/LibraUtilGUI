﻿using System;
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

            var wb = new ClosedXML.Excel.XLWorkbook();
            var ws = wb.Worksheets.Add("Sheet1");

            //行のループ
            for (int i = 0; i < data.Count; i++)
            {
                List<string> row = (List<string>)data[i];

                //列のループ
                for(int j=0; j<row.Count; j++)
                {
                    string col = (string)row[j];
                    ws.Cell(i+1, j+1).Value = fetch_overflow_characters(col);
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
}
