
namespace TCC_PDI.Forms
{
    partial class FormImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxCam = new System.Windows.Forms.PictureBox();
            this.carregar_img = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.dados_img = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picBoxImg = new System.Windows.Forms.PictureBox();
            this.cmbCameras = new System.Windows.Forms.ComboBox();
            this.TirarFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxCam
            // 
            this.picBoxCam.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBoxCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxCam.Location = new System.Drawing.Point(186, 34);
            this.picBoxCam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxCam.Name = "picBoxCam";
            this.picBoxCam.Size = new System.Drawing.Size(340, 236);
            this.picBoxCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxCam.TabIndex = 0;
            this.picBoxCam.TabStop = false;
            this.picBoxCam.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // carregar_img
            // 
            this.carregar_img.Location = new System.Drawing.Point(977, 44);
            this.carregar_img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.carregar_img.Name = "carregar_img";
            this.carregar_img.Size = new System.Drawing.Size(121, 44);
            this.carregar_img.TabIndex = 1;
            this.carregar_img.Text = "Carregar";
            this.carregar_img.UseVisualStyleBackColor = true;
            this.carregar_img.Click += new System.EventHandler(this.carregar_img_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(312, 329);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(340, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 127;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // dados_img
            // 
            this.dados_img.Location = new System.Drawing.Point(977, 113);
            this.dados_img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dados_img.Name = "dados_img";
            this.dados_img.Size = new System.Drawing.Size(121, 44);
            this.dados_img.TabIndex = 3;
            this.dados_img.Text = "Gerar Dados";
            this.dados_img.UseVisualStyleBackColor = true;
            this.dados_img.Click += new System.EventHandler(this.dados_img_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picBoxImg
            // 
            this.picBoxImg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBoxImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxImg.Location = new System.Drawing.Point(555, 34);
            this.picBoxImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxImg.Name = "picBoxImg";
            this.picBoxImg.Size = new System.Drawing.Size(340, 236);
            this.picBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxImg.TabIndex = 0;
            this.picBoxImg.TabStop = false;
            this.picBoxImg.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmbCameras
            // 
            this.cmbCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameras.FormattingEnabled = true;
            this.cmbCameras.Location = new System.Drawing.Point(186, 274);
            this.cmbCameras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.Size = new System.Drawing.Size(340, 23);
            this.cmbCameras.TabIndex = 4;
            this.cmbCameras.SelectedIndexChanged += new System.EventHandler(this.cmbCameras_SelectedIndexChanged);
            // 
            // TirarFoto
            // 
            this.TirarFoto.Location = new System.Drawing.Point(555, 273);
            this.TirarFoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TirarFoto.Name = "TirarFoto";
            this.TirarFoto.Size = new System.Drawing.Size(340, 22);
            this.TirarFoto.TabIndex = 5;
            this.TirarFoto.Text = "Tirar foto";
            this.TirarFoto.UseVisualStyleBackColor = true;
            this.TirarFoto.Click += new System.EventHandler(this.TirarFoto_Click);
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 418);
            this.Controls.Add(this.TirarFoto);
            this.Controls.Add(this.cmbCameras);
            this.Controls.Add(this.dados_img);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.carregar_img);
            this.Controls.Add(this.picBoxImg);
            this.Controls.Add(this.picBoxCam);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormImage";
            this.Text = "FormImage";
            this.Load += new System.EventHandler(this.FormImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxCam;
        private System.Windows.Forms.Button carregar_img;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button dados_img;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBoxImg;
        private System.Windows.Forms.ComboBox cmbCameras;
        private System.Windows.Forms.Button TirarFoto;
    }
}