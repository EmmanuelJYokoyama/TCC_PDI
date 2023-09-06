using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TCC_PDI.Forms
{
    public partial class FormReport : Form
    {
        string html;

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
            gerarRelatorio();
            TabPage aba = new TabPage();
            tabControl1.Controls.Add(aba);
            tabControl1.SelectTab(tabControl1.TabCount - 1);
            WebBrowser browser = new WebBrowser() { ScriptErrorsSuppressed = true };
            browser.Parent = aba;
            browser.Dock = DockStyle.Fill;
            browser.DocumentText = html;
            browser.DocumentCompleted += Browser_DocumentCompleted;
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            if (browser != null)
                tabControl1.SelectedTab.Text = browser.DocumentTitle;
        }

        private void gerarRelatorio()
        {
            //Inicia a Table
            html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 12pt;font-family:arial'>";

            //Incluir o Header
            html += "<tr>";
            html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Nome</th>";
            html += "</tr>";

            //Adiciona uma linha.
            html += "<tr>";
            html += "<td style='width:120px;border: 1px solid #ccc'>Aí Messiiiiiiiiiiii</td>";
            html += "</tr>";

            //Fecha a table.
            html += "</table>";

            //Define o caminho e cria o arquivo HTML
            var caminhoArquivoHTML = @"C:\Users\aluno\Desktop\Teste.html";

            File.WriteAllText(caminhoArquivoHTML, html);
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
