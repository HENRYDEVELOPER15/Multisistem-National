using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSystem
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Verificar si la configuración está guardada
            //if (string.IsNullOrEmpty(Properties.Settings.Default.Servers) ||
            //    string.IsNullOrEmpty(Properties.Settings.Default.Databases) ||
            //    string.IsNullOrEmpty(Properties.Settings.Default.Usernames) ||
            //    string.IsNullOrEmpty(Properties.Settings.Default.Passwords))
            //{
            //    // Mostrar el formulario de conexión
            //    getConexion connectionForm = new getConexion();
            //    Application.Run(connectionForm);
            //}
            //Application.Run(new loading());
            getConexion connectionForm = new getConexion();
            Application.Run(connectionForm);
        }

    }
}
