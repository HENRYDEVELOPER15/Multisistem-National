using ja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSystem
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            Form2 form = new Form2();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            //Abrirhijo(new Inicio());
            modelo.Contarpendientes();
         //   btnPendientes.Text = "Pendientes: " + modelo.Contarpendi;
        }
        private Form activarFormulario=null;
        
        public void Abrirhijo(Form hijo)
        {
            
               
                activarFormulario = hijo;
                hijo.TopLevel= false;
                hijo.FormBorderStyle= FormBorderStyle.None;
                hijo.Dock= DockStyle.Fill;
                panelhijo.Controls.Add(hijo);
                panelhijo.Tag = hijo;
                hijo.BringToFront();
                hijo.Show();
            
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelhijo.Controls.Add(childForm);
            panelhijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       

      

      
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIforme_Click(object sender, EventArgs e)
        {
            Abrirhijo(new Form2());
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            openChildForm(new Clientes());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmpresa(this));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getConexion getConexion = new getConexion();
            getConexion.Show();
        }

        private void panelhijo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
