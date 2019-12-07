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

        private void browse_ch()
        {
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            string url = "https://www.google.com/";
            driver.Url = url;
            Thread.Sleep(5000);
            driver.Quit();
        }


        private void browse_fx()
        {
            FirefoxDriver driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            string url = "https://www.google.com/";
            driver.Url = url;
            Thread.Sleep(5000);
            driver.Quit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browse_ch();
            browse_fx();
        }
    }

}
