using ja;
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
    public partial class FormClientes : Form
    {
        modelo_impresora modelo;
        int idImpresora;
        public FormClientes(int idimpresora)
        {
            InitializeComponent();
            modelo = new modelo_impresora();
            this.idImpresora = idimpresora;
            LlenarComboBoxTipos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idresponsable = modelo.InsertarResponsable(txtRespons.Text, txtOfici.Text, long.Parse(txtTelefono.Text));
            int idempresa = modelo.InsertarEmpresa(txtEmpresa.Text, txtEmpresa.Text, idresponsable);
            modelo.ActualizarImpresora(idImpresora, idempresa);
            MessageBox.Show("Datos Actualizados");
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número, cancelar la entrada de teclado
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LlenarComboBoxTipos()
        {
            List<datos_empresa> tipos = modelo.CargarTipos();

            comboBox1.DataSource = tipos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int idempresa = (int)comboBox1.SelectedValue;
            modelo.ActualizarImpresora(idImpresora, idempresa);
            MessageBox.Show("Datos Actualizados");
        }
    }
}
