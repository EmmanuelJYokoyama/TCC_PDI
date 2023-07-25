
namespace TCC_PDI.Forms
{
    partial class FormUpload_IMG
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picBoxImg = new System.Windows.Forms.PictureBox();
            this.dados_img = new System.Windows.Forms.Button();
            this.carregar_img = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picBoxImg
            // 
            this.picBoxImg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBoxImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxImg.Location = new System.Drawing.Point(209, 133);
            this.picBoxImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxImg.Name = "picBoxImg";
            this.picBoxImg.Size = new System.Drawing.Size(629, 421);
            this.picBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxImg.TabIndex = 1;
            this.picBoxImg.TabStop = false;
            this.picBoxImg.Click += new System.EventHandler(this.picBoxImg_Click);
            // 
            // dados_img
            // 
            this.dados_img.Location = new System.Drawing.Point(1051, 510);
            this.dados_img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dados_img.Name = "dados_img";
            this.dados_img.Size = new System.Drawing.Size(121, 44);
            this.dados_img.TabIndex = 5;
            this.dados_img.Text = "Gerar Dados";
            this.dados_img.UseVisualStyleBackColor = true;
            this.dados_img.Click += new System.EventHandler(this.dados_img_Click);
            // 
            // carregar_img
            // 
            this.carregar_img.Location = new System.Drawing.Point(889, 510);
            this.carregar_img.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.carregar_img.Name = "carregar_img";
            this.carregar_img.Size = new System.Drawing.Size(121, 44);
            this.carregar_img.TabIndex = 4;
            this.carregar_img.Text = "Carregar";
            this.carregar_img.UseVisualStyleBackColor = true;
            this.carregar_img.Click += new System.EventHandler(this.carregar_img_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(369, 558);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(340, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 127;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // FormUpload_IMG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 614);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.dados_img);
            this.Controls.Add(this.carregar_img);
            this.Controls.Add(this.picBoxImg);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormUpload_IMG";
            this.Text = "FormSettings";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picBoxImg;
        private System.Windows.Forms.Button dados_img;
        private System.Windows.Forms.Button carregar_img;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}