using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSystem
{
    public partial class FormEmpresa : Form
    {
        public modelo_impresora modelo;
        private int selectedRowId;
        Index Index;
        public FormEmpresa(Index index)
        {
            InitializeComponent();
            this.modelo = new modelo_impresora();
            ConfigureDataGridView();
            modelo.LoadData(dataGridView1);
            ApplyRowColor();
            this.Index = index;
        }

        private void FormEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormImpre form = new FormImpre(this);
            form.ShowDialog();
        }
        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Clear();

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "";
            imageColumn.Name = "ImageColumn";
            imageColumn.Image = Properties.Resources.Impresora; // Usa la imagen desde los recursos
            imageColumn.Width = 100;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imageColumn);

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("Nombre", "Impresora");
            dataGridView1.Columns.Add("Marca", "Marca");
            dataGridView1.Columns.Add("Modelo", "Modelo");
            dataGridView1.Columns.Add("Serial", "Serial");
            dataGridView1.Columns.Add("id_Empresa", "Empresa");

            dataGridView1.Columns["id_Empresa"].Visible = false;
            // Configura la columna de botón
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Acciones";
            buttonColumn.Name = "ButtonColumn";
            buttonColumn.Text = "Acción";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Width = 100;
            dataGridView1.Columns.Add(buttonColumn);

            dataGridView1.AllowUserToAddRows = false; // Evita que se agregue una fila adicional vacía
        }
        private void ApplyRowColor()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["id_Empresa"].Value == DBNull.Value || string.IsNullOrWhiteSpace(row.Cells["id_Empresa"].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen; 
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["ButtonColumn"].Index && e.RowIndex >= 0)
            {
                selectedRowId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value); // Cambia "Nombre" al nombre de la columna que contiene el ID
                var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);
                contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
                contextMenuStrip1.Tag = e.RowIndex;
            }
        }

        private void registradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes(selectedRowId);
            int currentIndex = form.tabControl1.SelectedIndex;
            form.tabControl1.SelectedIndex = currentIndex + 1;
            form.ShowDialog();
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Detalles detalles = new Form_Detalles(selectedRowId);
            Index.Abrirhijo(detalles);
          
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes(selectedRowId);
            form.ShowDialog();
        }
    }
}
