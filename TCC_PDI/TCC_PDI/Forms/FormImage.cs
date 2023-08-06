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

        int coluna = 0;
        int linha = 0;
        bool verf = false;
        string nomeFormatado = DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss");
        float area = 0;
        Color cor;
        Bitmap img;
        Bitmap imgnova;



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
            GC.Collect();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
        

        }

        /*----------------------------------------------------------------*/

        private void carregar_img_Click(object sender, EventArgs e)
        {
            img = new Bitmap(picBoxCam.Image);
            verf = true;
            coluna = img.Width; // O número colunas 
            linha = img.Height; // O número de linhas
            imgnova = new Bitmap(coluna, linha);
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
            imgnova.Save(nomeFormatado + ".jpg");
            picBoxImg.Image = imgnova;
            GC.Collect();
            
        }

        /*----------------------------------------------------------------*/

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
           if (picBoxImg.Image == null ){
                MessageBox.Show("CARREGUE A IMAGEM");

           }else{
                coluna = img.Width;
                linha = img.Height;
                imgnova = new Bitmap(coluna, linha);
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
                GC.Collect();

            }
            
        }

        /*----------------------------------------------------------------*/

        private void dados_img_Click(object sender, EventArgs e)
        {
            imgnova = new Bitmap(nomeFormatado+".jpg");
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

        /*----------------------------------------------------------------*/

        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
