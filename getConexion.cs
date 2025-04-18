using iTextSharp.text.xml;
using Org.BouncyCastle.Crypto.Tls;
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
    public partial class getConexion : Form
    {
        public getConexion()
        {
            InitializeComponent();
        }
      
        private void getConexion_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Servers;
            textBox2.Text = Properties.Settings.Default.Usernames;
            textBox3.Text = Properties.Settings.Default.Passwords;
            textBox4.Text = Properties.Settings.Default.Databases;
            textBox5.Text = Properties.Settings.Default.Directorio;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Guardar la configuración en algún lugar, por ejemplo, en el archivo de configuración
            string server = textBox1.Text;
            string database = textBox4.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;

            // Ejemplo de cómo podrías guardar esto en un archivo de configuración
            Properties.Settings.Default.Servers = server;
            Properties.Settings.Default.Databases = database;
            Properties.Settings.Default.Usernames = username;
            Properties.Settings.Default.Passwords = password;
            Properties.Settings.Default.Save();

            MessageBox.Show("Configuración guardada correctamente.");
            loading loading = new loading();
            loading.Show();
            this.Hide();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox5.Text = folderDialog.SelectedPath;
                }
            }

        }

        private void getConexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(string.IsNullOrEmpty(Properties.Settings.Default.Directorio))
            {
                MessageBox.Show("Falta Selecionar el Directorio");
                Application.Exit();
            }

            if(string.IsNullOrEmpty(Properties.Settings.Default.Servers) && string.IsNullOrEmpty(Properties.Settings.Default.Databases))
            {
                MessageBox.Show("No ha digitado el servidor y su Base de datos");
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string direc = textBox5.Text;
            Properties.Settings.Default.Directorio = direc;
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuración guardada correctamente.");
        }
    }
}
