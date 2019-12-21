using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraUtilGUI
{
    class TextUtil
    {

        //改行やタブを除去
        public static string text_clean(string str)
        {
            return Regex.Replace(str, @"(\r\n|\n|\t)", "");
        }

    }
}
