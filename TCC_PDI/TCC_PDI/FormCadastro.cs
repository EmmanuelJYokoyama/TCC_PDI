using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_PDI
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            double cpf_cnpj = double.Parse(textCPF_CNPJ.Text);
            string nomeEmpresa = textNomeEmpresa.Text;
            string ramoAtividade = textRamoAtividade.Text;
            string senha = textSenha.Text;

            this.Close();

            //inserirDados(cpf_cnpj, nomeEmpresa, ramoAtividade, senha);
        }

        //void inserirDados(double cpf_cnpj, string nomeEmpresa, string ramoAtividade, string senha)
        //{
        //    string database = "SERVER=localhost;DATABASE=pdi;UID=root;PASSWORD=;";
        //    MySqlConnection con = new MySqlConnection(database);
        //    con.Open();

        //    MySqlCommand comandosql = con.CreateCommand();
        //    comandosql.CommandText = String.Format(@"insert into dados_empresa values ('{0}', '{1}', '{2}', '{3}')", cpf_cnpj, nomeEmpresa, ramoAtividade, senha);
        //    comandosql.ExecuteNonQuery();
        //    comandosql.Connection.Close();

        //    MessageBox.Show("Inserido com sucesso!");
        //}

        private void btnLoginBack_Click(object sender, EventArgs e)
        {
            using (FormLogin modal = new FormLogin())
            {
                modal.ShowDialog();
            }
            this.Close();
        }
    }
}
