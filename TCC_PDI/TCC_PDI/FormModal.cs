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
    public partial class FormModal : Form
    {
        public FormModal()
        {
            InitializeComponent();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            double cpf_cnpj = double.Parse(textCPF_CNPJ.Text);
            string nomeEmpresa = textNomeEmpresa.Text;
            string ramoAtividade = textRamoAtividade.Text;
            string senha = textSenha.Text;

            inserirDados(cpf_cnpj, nomeEmpresa, ramoAtividade, senha);
        }

        void inserirDados(double cpf_cnpj, string nomeEmpresa, string ramoAtividade, string senha)
        {
            string database = "SERVER=localhost;DATABASE=pdi;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(database);
            con.Open();

            MySqlCommand comandosql = con.CreateCommand();
            comandosql.CommandText = String.Format(@"insert into dados_empresa values ('{0}', '{1}', '{2}', '{3}')", cpf_cnpj, nomeEmpresa, ramoAtividade, senha);
            comandosql.ExecuteNonQuery();
            comandosql.Connection.Close();

            MessageBox.Show("Inserido com sucesso!");
        }

        void verificarCodigo(double cpf_cnpj, string senha)
        {
            string database = "SERVER=localhost;DATABASE=pdi;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(database);
            con.Open();

            MySqlCommand comandosql = con.CreateCommand();
            comandosql.CommandText = String.Format("select * from dados_empresa where cpf_cnpj = '{0}' and senha = '{1}'", cpf_cnpj, senha);
            MySqlDataReader Query = comandosql.ExecuteReader();

            string nomeEmpresa = "", ramoAtividade = "";
            if (Query.Read())
            {
                nomeEmpresa = Query.GetString("nome_empresa");
                ramoAtividade = Query.GetString("ramo_atividade");
            }
            else
                MessageBox.Show("Usuário inexistente");

            
            textNomeEmpresa.Text = nomeEmpresa;
            textRamoAtividade.Text = ramoAtividade;

            comandosql.Connection.Close();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            double cpf_cnpj = double.Parse(textCPF_CNPJ.Text);
            string nomeEmpresa = textNomeEmpresa.Text;
            string ramoAtividade = textRamoAtividade.Text;
            string senha = textSenha.Text;

            verificarCodigo(cpf_cnpj, senha);
        }

    }
}
