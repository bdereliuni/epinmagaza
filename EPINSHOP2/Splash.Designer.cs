namespace EPINSHOP2
{
    partial class Splash
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MyProgress = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.PercentLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EPINSHOP2.Properties.Resources.icons8_shop_90;
            this.pictureBox1.Location = new System.Drawing.Point(32, 249);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label1.Location = new System.Drawing.Point(146, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "E-PIN Mağazası Yönetim Sistemi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MyProgress
            // 
            this.MyProgress.AllowAnimations = false;
            this.MyProgress.Animation = 0;
            this.MyProgress.AnimationSpeed = 220;
            this.MyProgress.AnimationStep = 10;
            this.MyProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.MyProgress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MyProgress.BackgroundImage")));
            this.MyProgress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.MyProgress.BorderRadius = 9;
            this.MyProgress.BorderThickness = 1;
            this.MyProgress.Location = new System.Drawing.Point(150, 277);
            this.MyProgress.Maximum = 100;
            this.MyProgress.MaximumValue = 100;
            this.MyProgress.Minimum = 0;
            this.MyProgress.MinimumValue = 0;
            this.MyProgress.Name = "MyProgress";
            this.MyProgress.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.MyProgress.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.MyProgress.ProgressColorLeft = System.Drawing.Color.LightGoldenrodYellow;
            this.MyProgress.ProgressColorRight = System.Drawing.Color.LightGoldenrodYellow;
            this.MyProgress.Size = new System.Drawing.Size(416, 39);
            this.MyProgress.TabIndex = 2;
            this.MyProgress.Value = 50;
            this.MyProgress.ValueByTransition = 50;
            // 
            // PercentLbl
            // 
            this.PercentLbl.AutoSize = true;
            this.PercentLbl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PercentLbl.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.PercentLbl.Location = new System.Drawing.Point(272, 145);
            this.PercentLbl.Name = "PercentLbl";
            this.PercentLbl.Size = new System.Drawing.Size(44, 23);
            this.PercentLbl.TabIndex = 3;
            this.PercentLbl.Text = "%%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label3.Location = new System.Drawing.Point(146, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modüller Yükleniyor";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(591, 345);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PercentLbl);
            this.Controls.Add(this.MyProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PercentLbl;
        private Bunifu.UI.WinForms.BunifuProgressBar MyProgress;
        private System.Windows.Forms.Timer timer1;
    }
}

