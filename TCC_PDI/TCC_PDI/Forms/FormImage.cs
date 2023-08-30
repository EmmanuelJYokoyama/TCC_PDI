using AForge.Video;
using AForge.Video.DirectShow;
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
    public partial class FormImage : Form
    {

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        bool foco;
        int coluna = 0;
        int linha = 0;
        bool verf = false;
        float area = 0;
        Bitmap img;
        Bitmap imgnova;
        string nomeFormatado = DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss");

        public FormImage()
        {
            InitializeComponent();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cmbCameras.Items.Add(filterInfo.Name);

            cmbCameras.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void FormImage_Load(object sender, EventArgs e)
        {

            videoCaptureDevice = new VideoCaptureDevice
                (filterInfoCollection[cmbCameras.SelectedIndex].MonikerString);

            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (foco)
            {
                picBoxCam.Image = (Bitmap)e.Frame.Clone();
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (videoCaptureDevice.)
            //{
            //    videoCaptureDevice;
            //    picBoxCam.Image = null;
            //}  
        }

        void Abrir_Banco()
        {
            string database = "SERVER=databasedojapa.c4fsrgel8mzi.sa-east-1.rds.amazonaws.com;DATABASE=PDI;UID=root;PASSWORD=euamoopaulo;";
            MySqlConnection connection = new MySqlConnection(database);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();

        }

        Color definirCor(double r, double g, double b)
        {
            return Color.FromArgb((int)r, (int)g, (int)b);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picBoxImg.Image = null;
            foco = false;
            carregar_img.Visible = true;
            tirarFoto.Visible = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.jpg)|";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName;
                Bitmap img = new Bitmap(path);
                picBoxCam.Image = img;
            }

        }

        Bitmap ProcessarImg(int indiceLimiar)
        {
            img = new Bitmap(picBoxCam.Image);
            verf = true;
            coluna = img.Width; // O número colunas 
            linha = img.Height; // O número de linhas
            imgnova = new Bitmap(coluna, linha);
            Color cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = img.GetPixel(i, j).R;
                    double g = img.GetPixel(i, j).G;
                    double b = img.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;

                    if (K >= indiceLimiar)
                        K = 255;
                    else
                        K = 0;

                    cor = definirCor((int)K, (int)K, (int)K);
                    imgnova.SetPixel(i, j, cor);

                }
            }
            imgnova.Save(nomeFormatado + ".jpg");
            GC.Collect();
            return imgnova;
        }

        private void carregar_img_Click(object sender, EventArgs e)
        {
            picBoxImg.Image = ProcessarImg(127);
        }

        private void tirarFoto_Click(object sender, EventArgs e)
        {
            picBoxImg.Image = ProcessarImg(127);
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (picBoxImg.Image == null)
            {
                MessageBox.Show("CARREGUE A IMAGEM");

            }
            else
            {
                picBoxImg.Image = ProcessarImg(trackBar1.Value);
            }

        }

        private void dados_img_Click(object sender, EventArgs e)
        {
            imgnova = new Bitmap(nomeFormatado + ".jpg");
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

            label2.Text = (((int)area).ToString() + "% da área total vazia.");
        }

   
        private void abrirCamera_Click(object sender, EventArgs e)
        {
            abrirCamera.Visible = false;
            picBoxImg.Image = null;
            foco = true;
            tirarFoto.Visible = true;

            videoCaptureDevice = new VideoCaptureDevice
            (filterInfoCollection[cmbCameras.SelectedIndex].MonikerString);

            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }









        /*----------------------------------------------------------------*/
        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
