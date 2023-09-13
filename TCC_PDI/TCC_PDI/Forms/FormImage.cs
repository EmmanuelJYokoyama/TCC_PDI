using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TCC_PDI.Forms
{
    public partial class FormImage : Form
    {

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        bool foco;
        int pixelsBrancos = 0;
        int pixelsPretos = 0;
        int coluna = 0;
        int linha = 0;
        float areaOcupada = 0f;
        Bitmap imgOriginal;
        Bitmap[] vetorImgs = new Bitmap[2];

        public FormImage()
        {
            InitializeComponent();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cmbCameras.Items.Add(filterInfo.Name);

            cmbCameras.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (foco)
            {
                picBoxCam.Image = (Bitmap)e.Frame.Clone();
                GC.Collect();
            }
        }

        void Abrir_Banco()
        {
            string database = "SERVER=localhost;DATABASE=pdi;UID=root;PASSWORD=;";
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
            fecharCamera();
            foco = false;
            tirarFoto.Visible = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.jpg)|";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName;
                imgOriginal = new Bitmap(path);
                picBoxCam.Image = imgOriginal;
                carregar_img.Visible = true;
                abrirCamera.Visible = true;
            }

        }

        Bitmap[] ProcessarImg(int indiceLimiar)
        {
            coluna = linha = 0;
            coluna = imgOriginal.Width; // O número colunas 
            linha = imgOriginal.Height; // O número de linhas
            label6.Text = (coluna * linha).ToString();
            Bitmap imgPretoBranco = new Bitmap(coluna, linha);
            Bitmap imgEscalaCinza = new Bitmap(coluna, linha);

            vetorImgs = new Bitmap[2] { imgPretoBranco, imgEscalaCinza };

            int[] histograma_GrayLevel = new int[256];
            pixelsBrancos = pixelsPretos = 0;
            areaOcupada = 0;

            Color cor = new Color();

            for (int i = 0; i < coluna; i++)
            {
                for (int j = 0; j < linha; j++)
                {
                    double r = imgOriginal.GetPixel(i, j).R;
                    double g = imgOriginal.GetPixel(i, j).G;
                    double b = imgOriginal.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;
                    histograma_GrayLevel[(int)K] += 1;

                    cor = definirCor(K, K, K);
                    vetorImgs[1].SetPixel(i, j, cor);

                    if (K >= indiceLimiar)
                    {
                        K = 255;
                        pixelsBrancos++;
                    }
                    else
                    {
                        K = 0;
                        pixelsPretos++;
                    }

                    cor = definirCor(K,K,K);
                    vetorImgs[0].SetPixel(i, j, cor);

                }
            }

            File.WriteAllText(@"dados.xml", "<Registro>");
            for (int i = 0; i <= 255; i++)
            {
                File.AppendAllText(@"dados.xml", " < Dado>" + Environment.NewLine + "<Espectro>" + histograma_GrayLevel[i] + "</Espectro>" + Environment.NewLine + "</Dado>");
            }
            File.AppendAllText(@"dados.xml", "</Registro>");

            GC.Collect();
            return vetorImgs;
        }
        private void tirarFoto_Click(object sender, EventArgs e)
        {
            imgOriginal = new Bitmap(picBoxCam.Image);
            salvarImagem.Visible = true;
            vetorImgs = ProcessarImg(127);
            picBoxImg.Image = vetorImgs[0];
        }

        private void carregar_img_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 127;
            salvarImagem.Visible = true;
            vetorImgs = ProcessarImg(127);
            picBoxImg.Image = vetorImgs[0];
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (picBoxImg.Image == null)
                MessageBox.Show("CARREGUE A IMAGEM");
            else
                vetorImgs = ProcessarImg(trackBar1.Value);
                picBoxImg.Image = vetorImgs[0];
        }

        private void abrir_trocarCamera()
        {
            foco = true;
            carregar_img.Visible = false;
            tirarFoto.Visible = true;
            abrirCamera.Visible = false;

            videoCaptureDevice = new VideoCaptureDevice
            (filterInfoCollection[cmbCameras.SelectedIndex].MonikerString);

            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
   
        private void abrirCamera_Click(object sender, EventArgs e)
        {
            abrir_trocarCamera();
        }

        private void fecharCamera()
        {
            if(!(videoCaptureDevice == null))
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.SignalToStop();
                    videoCaptureDevice = null;
                }
        }

        private void salvarImagem_Click(object sender, EventArgs e)
        {
            vetorImgs[0].Save("ImgPretoBranco.jpg");
            vetorImgs[1].Save("ImgEscalaCinza.jpg");

            areaOcupada = 100 * (pixelsBrancos / (float)(coluna * linha));

            label2.Text = areaOcupada.ToString("0.00") + "% da área total ocupada.";

            if (areaOcupada <= 33.3)
                label3.Text = "Ocupação ruim.";
            else if (areaOcupada <= 66.6)
                label3.Text = "Ocupação regular.";
            else
                label3.Text = "Boa ocupação.";
        }

        private void FormImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            fecharCamera();
        }
    }
}
