using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSystem
{
    public partial class new_scanner : Form
    {
        modelo_impresora mod = new modelo_impresora();
        Form_Detalles detalles;
        int id, idE;
        public new_scanner(int id, int idE, Form_Detalles de)
        {
            InitializeComponent();
            this.id = id;
            this.idE = idE;
            this.detalles= de;
        }

        private void new_scanner_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccione un archivo PDF";
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            openFileDialog.InitialDirectory = @"C:\";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBox1.Text = filePath;
            }
        }
        private string CopiarArchivo(string rutaArchivo)
        {
            try
            {

                if (!Directory.Exists(Properties.Settings.Default.Directorio))
                {
                    Directory.CreateDirectory(@Properties.Settings.Default.Directorio);
                }

                string nombreArchivo = Path.GetFileName(rutaArchivo);
                string rutaDestino = Path.Combine(Properties.Settings.Default.Directorio, nombreArchivo);

                File.Copy(rutaArchivo, rutaDestino, overwrite: true);
                //MessageBox.Show("Archivo copiado a: " + rutaDestino, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return rutaDestino;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                string rutacopy = CopiarArchivo(textBox1.Text);
                mod.InsertarScanner(rutacopy, dateTimePicker1.Value, id, idE);
                MessageBox.Show("Datos Guardados");
                detalles.dataGridView1.DataSource = mod.getTabla(id);
                this.Close();
            }
           
        }
    }
}
