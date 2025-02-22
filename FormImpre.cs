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
    public partial class FormImpre : Form
    {
        modelo_impresora modelo;
        FormEmpresa padre;
        public FormImpre(FormEmpresa padre)
        {
            InitializeComponent();
            this.modelo = new modelo_impresora();
            this.padre = padre;
        }

        private void FormImpre_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            modelo.InsertarImpresora(txtmarca.Text,txtmodelo.Text, txtserial.Text, textBox1.Text);
            MessageBox.Show("Impresora Almacenada");
            padre.modelo.LoadData(padre.dataGridView1);
            this.Close();
        }
    }
}
