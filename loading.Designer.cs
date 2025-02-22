namespace MultiSystem
{
    partial class loading
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loading));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Animation = new System.Windows.Forms.Timer(this.components);
            this.hideAnimation = new System.Windows.Forms.Timer(this.components);
            this.bar = new System.Windows.Forms.ProgressBar();
            this.lblbar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(606, 363);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Animation
            // 
            this.Animation.Interval = 30;
            this.Animation.Tick += new System.EventHandler(this.Animation_Tick);
            // 
            // hideAnimation
            // 
            this.hideAnimation.Interval = 30;
            this.hideAnimation.Tick += new System.EventHandler(this.hideAnimation_Tick);
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(113, 309);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(378, 23);
            this.bar.TabIndex = 1;
            // 
            // lblbar
            // 
            this.lblbar.AutoSize = true;
            this.lblbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbar.Location = new System.Drawing.Point(497, 309);
            this.lblbar.Name = "lblbar";
            this.lblbar.Size = new System.Drawing.Size(41, 25);
            this.lblbar.TabIndex = 2;
            this.lblbar.Text = "0%";
            // 
            // loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 363);
            this.Controls.Add(this.lblbar);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Animation;
        private System.Windows.Forms.Timer hideAnimation;
        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.Label lblbar;
    }
}

