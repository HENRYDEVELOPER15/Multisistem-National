using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSystem
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity= 0;
            Animation.Start();
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity<1)
            {
                this.Opacity += 0.05;
            }
            bar.Value += 1;
            lblbar.Text=$"{bar.Value.ToString()}%";
            if (bar.Value==100)
            {
                Animation.Stop();
                hideAnimation.Start();
            }
        }

        private void hideAnimation_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 1;
            if (this.Opacity==0)
            {
                hideAnimation.Stop();
                Index index = new Index();
                index.Show();
                this.Hide();
            }
        }
    }
}
