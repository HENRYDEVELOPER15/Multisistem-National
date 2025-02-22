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
    public partial class Clientes : Form
    {
        Modelo modelo = new Modelo();
        Cache cache = new Cache();
        public Clientes()
        {
            InitializeComponent();
            dataGridView1.DataSource = modelo.GetClient();
        }
        int ID;

        public int ID1 { get => ID; set => ID = value; }

        private void Clientes_Load(object sender, EventArgs e)
        {
            button1.Visible= false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
   
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string valorPrimeraColumna = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dataGridView1.DataSource = modelo.GetDataCliente(int.Parse(valorPrimeraColumna));
                btnSalir.Visible = false;
                button1.Visible = true;
                btnAdd.Enabled= false;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
                cache.DatosEmpresa(ID1);
                cache.DatosResponsable();
                Form1 form = new Form1(this);
            form.txtEmpresa.Text = cache.NombreEm1;
            form.txtEmpresa.Enabled = false;
            form.txtRespons.Text = cache.NombreRespo1;
            form.txtRespons.Enabled = false;
            form.txtTelefono.Text = cache.Telefono.ToString();
            form.txtTelefono.Enabled = false;
            form.txtDirec.Text = cache.Direccion;
            form.txtDirec.Enabled = false;
            form.txtOfici.Text = cache.Oficina1;
            form.txtOfici.Enabled = false;
            form.txtContra.Text = cache.Contrato;
            form.txtContra.Enabled = false;
            form.IdEmpresa = ID1;
            form.InsertarDatosC();
            form.ShowDialog();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                string valorPrimeraColumna = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ID1=int.Parse(valorPrimeraColumna);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = modelo.GetClient();
            btnAdd.Enabled = true;
            button1.Visible = false;
            btnSalir.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
