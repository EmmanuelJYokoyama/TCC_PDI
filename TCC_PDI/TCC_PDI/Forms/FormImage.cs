using AForge.Video;
using AForge.Video.DirectShow;
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

        Bitmap img = new Bitmap(@"C:\Users\giuel\Downloads\PAISAGEM.jpg");
        int coluna = 0;
        int linha = 0;
        bool verf = false;
        float area = 0;
        Color cor;

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
            picBoxCam.Image = (Bitmap)e.Frame.Clone();
        }

        private void TirarFoto_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetImage(picBoxCam.Image);
            picBoxImg.Image = Clipboard.GetImage();
            Clipboard.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picBoxCam.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

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
            imgnova.Save("novaImagem.jpg");
            picBoxCam.Image = imgnova;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
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

            //imgnova.Save("novaImagem.jpg");
            picBoxCam.Image = imgnova;
        }

        private void dados_img_Click(object sender, EventArgs e)
        {
            Bitmap imgnova = new Bitmap("novaImagem.jpg");
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
        }
    }
}
