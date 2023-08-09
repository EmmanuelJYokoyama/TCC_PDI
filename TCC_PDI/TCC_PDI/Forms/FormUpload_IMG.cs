using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC_PDI.Forms
{
    public partial class FormUpload_IMG : Form
    {
        public FormUpload_IMG()
        {
            InitializeComponent();
        }

        
        int coluna = 0;
        int linha = 0;
        bool verf = false;
        float area = 0;
        Bitmap img;
        string nomeFormatado = DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss");
        Color cor;


        void abrir_Banco()
        {
            string database = "SERVER=databasedojapa.c4fsrgel8mzi.sa-east-1.rds.amazonaws.com;DATABASE=PDI;UID=root;PASSWORD=euamoopaulo;";
            MySqlConnection connection = new MySqlConnection(database);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();

        }



        private void picBoxImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(@"" + openFileDialog1.FileName);
                picBoxImg.Image = new Bitmap(openFileDialog1.FileName);
                
            }

        }

        /*------------------------------------------*/

        private void carregar_img_Click(object sender, EventArgs e)
        {
            
            verf = true;
            coluna = img.Width; // O número colunas 
            linha = img.Height; // O número de linhas
            Bitmap imgnova = new Bitmap(coluna, linha);
            cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;

                    if (K >= 127)
                        K = 255;
                    else
                        K = 0;

                    cor = Color.FromArgb((int)K, (int)K, (int)K);
                    imgnova.SetPixel(i, j, cor);

                }
            }
            
            imgnova.Save(nomeFormatado+".jpg");
            picBoxImg.Image = imgnova;
            GC.Collect();
        }

        /*------------------------------------------*/

        private void dados_img_Click(object sender, EventArgs e)
        {
            string database = "SERVER=databasedojapa.c4fsrgel8mzi.sa-east-1.rds.amazonaws.com;DATABASE=PDI;UID=root;PASSWORD=euamoopaulo;";
            MySqlConnection connection = new MySqlConnection(database);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();

            Bitmap imgnova = new Bitmap(nomeFormatado+".jpg");
            coluna = imgnova.Width;
            linha = imgnova.Height;
            int pixelsB = 0;
            int pixelsP = 0;


            if (verf == true)
            {
                for (int i = 0; i <= coluna - 1; i++)
                {
                    for (int j = 0; j <= linha - 1; j++)
                    {
                        int r = imgnova.GetPixel(i, j).R;
                        int g = imgnova.GetPixel(i, j).G;
                        int b = imgnova.GetPixel(i, j).B;

                        if (r == 255 && g == 255 && b == 255)
                            pixelsB++;
                        else
                            pixelsP++;
                    }
                }
                //MessageBox.Show(coluna.ToString() + "\n" + linha.ToString());


                MessageBox.Show("PIXELS BRANCOS: " + pixelsB.ToString() + "\nPIXELS PRETOS: " + pixelsP.ToString());
                area = 100 * ((pixelsB / (float)(coluna * linha)));
            }
            else
            {
                MessageBox.Show("PROCESSE A IMAGEM PRIMEIRO!");
            }
            MessageBox.Show(((int)area).ToString() + "% da área total vazia.");

            //command.CommandText = "INSERT INTO dados_projeto (`imagem`, `status`, `porcentagem`, `CODIGO_REL`) VALUES ('"+ imgnova.ToString() +"', 'INDEFINIDO' ,'"+ area.ToString() +"', '99999' );";
            //MySqlDataReader Query1 = command.ExecuteReader();

            

            connection.Close();
        }




        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            coluna = img.Width;
            linha = img.Height;
            Bitmap imgnova = new Bitmap(coluna, linha);
            cor = new Color();

            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;

                    if (K >= trackBar1.Value)
                        K = 255;
                    else
                        K = 0;

                    cor = Color.FromArgb((int)K, (int)K, (int)K);
                    imgnova.SetPixel(i, j, cor);

                }
            }
        
            picBoxImg.Image = imgnova;
        }
    }
}
