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
    public partial class Form_Detalles : Form
    {
        int id;
        modelo_impresora impresora= new modelo_impresora();
        datos_Impresora Dimpresora;
        public Form_Detalles(int id)
        {
            InitializeComponent();
            this.id = id;
            Dimpresora = impresora.CargarDatos(this.id);
            label1.Text = $" Impresora: {Dimpresora.Nombre} \n\n Marca: {Dimpresora.Marca} \n\n Modelo: {Dimpresora.Modelo} \n\n Serial: {Dimpresora.Serial} \n\n Ocupada por: {Dimpresora.Nombre_em}";
            dataGridView1.DataSource = impresora.getTabla(id);
            cargarDatos();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_Detalles_Load(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            //dataGridView1.DataSource = modelo.getTabla();
            dataGridView1.Columns[1].Visible = false;


            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
            viewButtonColumn.Name = "VerArchivo";
            viewButtonColumn.HeaderText = "Ver Archivo";
            viewButtonColumn.Text = "Ver";
            viewButtonColumn.UseColumnTextForButtonValue = true;

            viewButtonColumn.DefaultCellStyle.BackColor = Color.White;
            viewButtonColumn.DefaultCellStyle.ForeColor = Color.DarkGreen;
            viewButtonColumn.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
            viewButtonColumn.DefaultCellStyle.SelectionForeColor = Color.White;
            viewButtonColumn.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(viewButtonColumn);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_scanner scanner = new new_scanner(id, Dimpresora.Id_em, this);
            scanner.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ((DataGridView)sender).Columns["VerArchivo"].Index && e.RowIndex >= 0)
            {
                // Captura la ruta del archivo desde la columna "Ruta_doc" correspondiente a la fila seleccionada
                string rutaDoc = ObtenerRutaDoc(e.RowIndex);

                // Llama a la función para abrir el archivo en Google Chrome
                AbrirArchivoEnChrome(rutaDoc);
            }
        }

        private string ObtenerRutaDoc(int rowIndex)
        {
            // Asumiendo que la columna Ruta_doc está en el DataTable original que llenó el DataGridView
            DataRowView rowView = (DataRowView)dataGridView1.Rows[rowIndex].DataBoundItem;
            return rowView["Ruta"].ToString();
        }

        private void AbrirArchivoEnChrome(string rutaDoc)
        {
            try
            {
                // Usa Google Chrome para abrir el archivo
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "chrome.exe",
                    Arguments = rutaDoc,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el documento: " + ex.Message);
            }
        }
    }
}
