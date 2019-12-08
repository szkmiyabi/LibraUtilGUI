using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using System.Threading;


namespace LibraUtilGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int[] appWait = { 60, 10, 6, 5 };
            LibraDriver ldr = new LibraDriver("", "", "600", appWait, "chrome", "no", "no");
            ldr.login();
            Thread.Sleep(5000);
            ldr.logout();
            ldr.shutdown();

        }
    }

}
