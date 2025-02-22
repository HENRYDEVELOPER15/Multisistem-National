using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
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
using System.Net.NetworkInformation;
using Org.BouncyCastle.Ocsp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using MultiSystem.Properties;
using MultiSystem;

namespace ja
{
    public partial class Form1 : Form
    {
        Form2 padre;
        Clientes clientes;
      //  SqlConnection connection;
        Cache cache=new Cache();
        bool InfoCLI;

        bool Actuali=false;
        int idInforme;
        int idEmpresa;
        int UltimaFila;
        public int UltimaFila1 { get => UltimaFila; set => UltimaFila = value; }
        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }

        public int IdInforme(int id)
        {
            return idInforme=id;
        }

        public bool ActulalizarDatos()
        {
            return Actuali= true;
        }
        public bool InsertarDatosC()
        {
            return InfoCLI = true;
        }
        public Form1(Form2 padre)
        {
            InitializeComponent();
            this.padre = padre;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            if (Actuali)
            {
                dataGridView1.DataSource = cache.DatosCambios();
            }
           
            this.padre = padre;
        }
        public Form1(Clientes padre)
        {
            InitializeComponent();
            this.clientes = padre;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            InsertarDatosC();
            dataGridView1.Columns.Add("Column1", "Tipo de Repuesto");
            dataGridView1.Columns.Add("Column2", "Serial Defectuoso");
            dataGridView1.Columns.Add("Column3", "Serial Nuevo");

        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns.Add("Column1", "Tipo de Repuesto");
            dataGridView1.Columns.Add("Column2", "Serial Defectuoso");
            dataGridView1.Columns.Add("Column3", "Serial Nuevo");


            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            this.padre = padre;
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 form2= new Form2();
            //form2.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y avanzar una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y avanzar una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y avanzar una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            // Obtener el índice de la página actual y avanzar una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }

            if (Actuali)
            {
                cache.DatosInforme(idInforme);
                cache.DatosEmpresa();
                cache.DatosResponsable();
                cache.DatosEquipo();
                if (dataGridView1.Rows.Count > UltimaFila)
                {
                    DialogResult resultado = MessageBox.Show("¿Desea agregar estos nuevos datos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        for (int i = UltimaFila;i < dataGridView1.Rows.Count; i++)
                        {
                            modelo.InsertarCambios(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), cache.IdEquipo);
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y retroceder una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y retroceder una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y retroceder una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Obtener el índice de la página actual y retroceder una página
            int currentIndex = tabControl1.SelectedIndex;
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número, cancelar la entrada de teclado
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            string tipo = txtTipo.Text;
         
            string def = txtseridef.Text;
            string nue = txtserinu.Text;
            //if (dataGridView1.Rows.Count > UltimaFila1)
            //{

            //    dataGridView1.Rows.Add(tipo, def, nue);
            //}

            dataGridView1.Rows.Add(tipo, def, nue);

            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtTipo.Text = "";
            txtseridef.Text = "";
            txtserinu.Text = "";
        }
        private void LimpiarCampos2()
        {
            txtTipo.Text = "";
            txtseridef.Text = "";
            txtserinu.Text = "";
            txtEmpresa.Text="";
            txtDirec.Text = "";
            txtRespons.Text = "";
            txtOfici.Text = "";
            txtContra.Text = "";
            txtIng.Text = "";
            txtEquipo.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtserial.Text = "";
            txtFallas.Text = "";
            txtTelefono.Text = "";
            txtAcciones.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Eliminar la fila seleccionada
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo();
            string NomEm, direcc, nomRes, ofic, contra, servi="", pendi="", fact="", ing, equi, merc, mode, seri, falla, acci;

            NomEm = txtEmpresa.Text;
            direcc= txtDirec.Text;
            nomRes = txtRespons.Text;
            ofic = txtOfici.Text;
            contra = txtContra.Text;
            ing = txtIng.Text;
            equi = txtEquipo.Text;
            merc = txtMarca.Text;
            mode = txtModelo.Text;
            seri = txtserial.Text;
            falla = txtFallas.Text;
            acci = txtAcciones.Text;

            if (Actuali) button10.Text = "Actualizar";

            string ser1 = "", ser2 = "", ser3 = "", ser4 = "", ser5 = "";

            if (checkBox1.Checked == true)
            {
                ser1 = "X";
                servi += checkBox1.Text + " ";
            }
            if (checkBox2.Checked == true)
            {
                ser4 = "X";
                servi += checkBox2.Text + " ";
            }
            if (checkBox3.Checked == true)
            {
                ser5 = "X";
                servi += checkBox3.Text + " ";
            }
            if (checkBox4.Checked == true)
            {
                ser3 = "X";
                servi += checkBox4.Text + " ";
            }

            if (checkBox5.Checked == true)
            {
                ser2 = "X";
                servi += checkBox5.Text + " ";
            }
            string sip = "", nop = "", sif = "", nof = "";
            if (Sip.Checked==true)
            {
                pendi += "SI";
                sip = "X";
            }
            else
            {
                pendi += "NO";
                nop += "X";
            }

            if (Sif.Checked==true)
            {
                fact += "SI";
                sif = "X";
            }
            else
            {
                nof += "X";
                fact += "NO";
            }

            long tel = long.Parse(txtTelefono.Text);



            string cade = "";
            if (modelo.Id_Informe < 100)
            {
                cade = "00";
            }

            //Crear PDF

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss") +"_"+ txtEmpresa.Text+txtRespons.Text);


            string PaginaHTML_Texto = Resources.plantilla.ToString();





            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            if (Actuali)
            {
               
                cache.ActualizarInforme(idInforme, fecha, ing, cache.Servicio, fact, pendi, dateTimePicker4.Value.ToString(), dateTimePicker3.Value.ToString());
                modelo.Id_Informe= idInforme;
                cache.ActualizarEmpresa(cache.IdEmpresa, direcc, contra);
                cache.ActualizarResponsable(cache.IdResponsable, ofic, tel);
                cache.ActualizarEquipo(cache.IdEquipo, acci,falla);
            }
            else
            {
                modelo.InsertarEquipo(equi, mode, merc, seri, falla, acci);
                modelo.InsertarResponsable(nomRes, ofic, tel);
                if (InfoCLI.Equals(false)) {
                    modelo.InsertarEmpresa(NomEm, direcc, contra);
                    modelo.InsertarInforme(DateTime.Parse(fecha), ing, servi, fact, pendi, dateTimePicker4.Value.ToString(), dateTimePicker3.Value.ToString());
                }else
                {
                    modelo.InsertarInforme(DateTime.Parse(fecha), ing, servi, fact, pendi, dateTimePicker4.Value.ToString(), dateTimePicker3.Value.ToString(), IdEmpresa);
                }
               
            }
           


            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID_Informe", cade + modelo.Id_Informe.ToString());

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMPRESA", NomEm);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Direccion", direcc);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@RESPONSABLE", nomRes);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TELEFONO", tel.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@OFICINA", ofic);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ING", ing);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CONTRATO", contra);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER1", ser1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER2", ser2);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER3", ser3);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER4", ser4);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER5", ser5);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SIP", sip);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOP", nop);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SIF", sif);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOF", nof);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EQUIPO", equi);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MARCA", merc);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODELO", mode);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SERIAL", seri);

     

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FALLAS", falla);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ACCIONES", acci);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", fecha);

            string filas = string.Empty;
            string respu="", seridef="", serinu="";
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[1].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells[2].Value.ToString() + "</td>";
                filas += "</tr>";
                respu = row.Cells[0].Value.ToString();
                seridef = row.Cells[1].Value.ToString();
                serinu = row.Cells[2].Value.ToString();
                if (Actuali.Equals(false)) { modelo.InsertarCambios(respu, seridef, serinu); }
                
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECA", dateTimePicker4.Value.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECS", dateTimePicker3.Value.ToString());

            string filePath = "";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LETTER, 25, 25, 10, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Resources.logoMultisys, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(50, 50);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(50, 50);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin+50, pdfDoc.Top - 40);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }

            }
            modelo.GetData();
            LimpiarCampos2();
            if (Actuali) { this.Hide();
                MessageBox.Show("Datos actualizados");
                padre.darDatos();
            }

            if (InfoCLI)
            {
                MessageBox.Show("Informe Guardado");
                this.Hide();
            }
            int currentIndex = tabControl1.SelectedIndex;
            tabControl1.SelectedIndex = currentIndex - 4;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void cbmEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbmEmpresa.SelectedValue != null && cbmEmpresa.SelectedValue != DBNull.Value)
            //{
            //    if (int.TryParse(cbmEmpresa.SelectedValue.ToString(), out int idSeleccionado))
            //    {
            //        MessageBox.Show("Id seleccionado: " + idSeleccionado);
            //    }
            //    else
            //    {
            //        Console.WriteLine("No se pudo convertir el valor seleccionado a un entero.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No se ha seleccionado ningún valor.");
            //}
        }

        //private void CargarDatosComboBox()
        //{
        //    try
        //    {
        //        connection.Open();

        //        string query = "SELECT id_Empresa, Nombre FROM Empresa";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        DataTable dataTable = new DataTable();
        //        adapter.Fill(dataTable);
        //        cbmEmpresa.DataSource = dataTable;
        //        cbmEmpresa.DisplayMember = "Nombre"; 
        //        cbmEmpresa.ValueMember = "id_Empresa"; 
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar los datos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtRespons.Focus(); 
            }
        }

        private void txtRespons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtDirec.Focus(); 
            }
        }

        private void txtDirec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDirec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtTelefono.Focus();
            }
        }


        private void txtOfici_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtContra.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                txtOfici.Focus(); 
            }
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                int currentIndex = tabControl1.SelectedIndex;
                if (currentIndex < tabControl1.TabCount - 1)
                {
                    tabControl1.SelectedIndex = currentIndex + 1;
                }
                e.SuppressKeyPress = true;
                txtEquipo.Focus();
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
