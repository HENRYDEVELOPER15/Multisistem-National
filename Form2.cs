using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiSystem.Properties;



namespace ja
{
    public partial class Form2 : Form 
    {
        public Form2()
        {
            InitializeComponent();
            darDatos();
            dataGridView1.Refresh();
        }
        public event EventHandler<string> DatosModificados;
        private void ModificarDatosEnPadre()
        {
            string etiventa = "Inicio";
            DatosModificados?.Invoke(this, etiventa);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Modelo modelo = new Modelo();
        private void Form2_Load(object sender, EventArgs e)
        {
            
            button1.Enabled= false;
            button2.Enabled= false;
        }
        public void darDatos()
        {
            ConfigurarDataGridView(dataGridView1);
           
        }
        public void ConfigurarDataGridView(DataGridView dgv)
        {
            
            dgv.DataSource = modelo.GetData();

            dgv.Columns["actualizar"].Visible = false;

            
            foreach (DataGridViewRow row in dgv.Rows)
            {
           
                if (row.Cells["actualizar"].Value == DBNull.Value || Convert.ToInt32(row.Cells["actualizar"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            dgv.Refresh();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = modelo.Consultar(textBox1.Text);
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["actualizar"].Value == DBNull.Value || Convert.ToInt32(row.Cells["actualizar"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        Cache cache = new Cache();
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Capturar el valor de la primera celda de la fila seleccionada
                string valorPrimeraColumna = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                

                cache.DatosInforme(Convert.ToInt32(valorPrimeraColumna));
                cache.DatosEmpresa();
                cache.DatosResponsable();
                cache.DatosEquipo();
                label12.Text = "Ing. Mantenimiento: "+cache.Ing1;
                label2.Text = "Empresa: " + cache.NombreEm1;
                label3.Text = "Responsable: " + cache.NombreRespo1;
                label4.Text = "Dirección: " + cache.Direccion;
                label5.Text = "Telefono: "+ cache.Telefono;
                label6.Text = "Oficina: " + cache.Oficina1;
                label7.Text = "Contrato: " + cache.Contrato;
                label8.Text = "Equipo: " + cache.Equipo1;
                label9.Text = "Marca: " + cache.Marca1;
                label10.Text = "Modelo: " + cache.Modelo1;
                label11.Text = "Serial: " + cache.Serial1;
                label13.Text = "Fecha y hora de Atención: " + cache.FechaIni;
                label14.Text = "Fecha y hora de Solución: " + cache.FechaFinal;
                dataGridView2.DataSource= cache.DatosCambios();

                button1.Enabled = true;
                button2.Enabled = true;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", cache.Fecha.ToString("ddMMyyyyHHmmss") + "_" + cache.NombreEm1);
            string PaginaHTML_Texto = Resources.plantilla.ToString();


            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ID_Informe", cache.IdInforme.ToString());

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMPRESA", cache.NombreEm1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@Direccion", cache.Direccion);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@RESPONSABLE", cache.NombreRespo1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", cache.Fecha.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TELEFONO", cache.Telefono.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@OFICINA", cache.Oficina1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ING", cache.Ing1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CONTRATO", cache.Contrato);

            string[] palabras = cache.Servicio.Split(' ');
            string ser1 = "", ser2 = "", ser3 = "", ser4 = "", ser5 = "";

            Console.WriteLine("Palabras separadas:");
            foreach (string palabra in palabras)
            {
                if (palabra.Equals("Garantia"))
                {
                    ser1 = "X";
                }
                if (palabra.Equals("Instalación"))
                {
                    ser4 = "X";
                }
                if (palabra.Equals("Revisión"))
                {
                    ser5 = "X";
                }
                if (palabra.Equals("Correctivo"))
                {
                    ser3 = "X";
                }
                if (palabra.Equals("Preventivo"))
                {
                    ser2 = "X";
                }
            }


            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER1", ser1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER2", ser2);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER3", ser3);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER4", ser4);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SER5", ser5);

            string sip = "", nop = "", sif = "", nof = "";

            if (cache.Pendiente1.Equals("SI"))
            {
                sip = "X";
            }
            else
            {
                nop= "X";
            }

            if (cache.Facturar1.Equals("SI"))
            {
                sif = "X";
            }
            else
            {
                nof = "X";
            }

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SIP", sip);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOP", nop);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SIF", sif);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NOF", nof);

            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EQUIPO", cache.Equipo1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MARCA", cache.Marca1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@MODELO", cache.Modelo1);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@SERIAL", cache.Serial1);



            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FALLAS", cache.Falla);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@ACCIONES", cache.Accion);


            string filas = string.Empty;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells[0].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells[1].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells[2].Value.ToString() + "</td>";
                    filas += "</tr>";
                   
                }
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            string filePath = "";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.EXECUTIVE, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Resources.logoMultisys, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(50, 50);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    img.SetAbsolutePosition(20, 50);
                    img.SetAbsolutePosition(pdfDoc.Left+40, pdfDoc.Top - 40);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }

            }

            MessageBox.Show("Se ha Guardado el Documento");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.ActulalizarDatos();
            form1.IdInforme(cache.IdInforme);
            form1.txtEmpresa.Text = cache.NombreEm1;
            form1.txtEmpresa.Enabled= false;
            form1.txtRespons.Text = cache.NombreRespo1;
            form1.txtRespons.Enabled= false;
            form1.txtTelefono.Text = cache.Telefono.ToString();
            form1.txtDirec.Text = cache.Direccion;
            form1.txtOfici.Text = cache.Oficina1;
            form1.txtContra.Text = cache.Contrato;
            form1.txtIng.Text = cache.Ing1;
            form1.button10.Text = "Actualizar";
            string[] palabras = cache.Servicio.Split(' ');
          
            foreach (string palabra in palabras)
            {
                if (palabra.Equals("Garantia"))
                {
                   form1.checkBox1.Checked = true;
                }
                if (palabra.Equals("Instalación"))
                {
                    form1.checkBox2.Checked = true;
                }
                if (palabra.Equals("Revisión"))
                {
                    form1.checkBox3.Checked = true;
                }
                if (palabra.Equals("Correctivo"))
                {
                    form1.checkBox4.Checked = true;
                }
                if (palabra.Equals("Preventivo"))
                {
                    form1.checkBox5.Checked = true;
                }
            }
            form1.UltimaFila1 = dataGridView2.Rows.Count;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                form1.dataGridView1.Columns.Add(column.Clone() as DataGridViewColumn);
            }
            foreach(DataGridViewRow row in dataGridView2.Rows)
            {
                if(!row.IsNewRow && row.Cells.Count > 0)
                {
                    int rowIndex = form1.dataGridView1.Rows.Add();
                    for(int i = 0; i< row.Cells.Count; i++)
                    {
                        form1.dataGridView1.Rows[rowIndex].Cells[i].Value= row.Cells[i].Value;
                    }
                }
            }


            form1.txtEquipo.Text = cache.Equipo1;
            form1.txtEquipo.Enabled= false;
            form1.txtModelo.Text = cache.Modelo1;
            form1.txtModelo.Enabled= false;
            form1.txtMarca.Text = cache.Marca1;
            form1.txtMarca.Enabled= false;
            form1.txtserial.Text = cache.Serial1;
            form1.txtserial.Enabled= false;
         
            form1.txtFallas.Text = cache.Falla;
            form1.txtAcciones.Text = cache.Accion;
            form1.dateTimePicker4.Value = cache.FechaIni;
            form1.dateTimePicker3.Value = cache.FechaFinal;

            form1.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
