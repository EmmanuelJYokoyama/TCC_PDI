using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC_PDI.Forms
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
        private void FormReport_Load(object sender, EventArgs e)
        {
            abrirAba();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            abrirAba();
        }

        private void abrirAba()
        {
            TabPage aba = new TabPage();
            aba.Text = "Relatório";
            tabControl1.Controls.Add(aba);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            WebBrowser browser = new WebBrowser() { ScriptErrorsSuppressed = true };
            browser.Parent = aba;
            browser.Dock = DockStyle.Fill;
            browser.Navigate("http://www.google.com");
            browser.DocumentCompleted += Browser_DocumentCompleted;
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
                tabControl1.SelectedTab.Text = browser.DocumentTitle;
        }

        //private void btnRetorna_Click(object sender, EventArgs e)
        //{
        //    WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
        //    if (browser != null)
        //    {
        //        browser.Navigate(txtUrl.Text);
        //    }
        //}

        //private void btnAvanca_Click(object sender, EventArgs e)
        //{
        //    WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
        //    if (browser != null)
        //    {
        //        if (browser.CanGoForward)
        //            browser.GoForward();
        //    }
        //}

        //private void btnIr_Click(object sender, EventArgs e)
        //{
        //    WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
        //    if (browser != null)
        //    {
        //        browser.Navigate(txtUrl.Text);
        //    }
        //}

    }
}
