using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MultiSystem;
using System.Data.Common;

namespace ja
{
    public abstract class Conexion
    {
        string server = MultiSystem.Properties.Settings.Default.Servers;
        string Database = MultiSystem.Properties.Settings.Default.Databases;
        string Username = MultiSystem.Properties.Settings.Default.Usernames;
        string Password = MultiSystem.Properties.Settings.Default.Passwords;

        private readonly string connectionString = "";
        public Conexion()
        {
            connectionString = "";
            if (string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password))
            {
                connectionString = $"Server={server};Database={Database};integrated security= true";
            }
            else
            {
                Console.WriteLine(server);
                Console.WriteLine(Username);
                Console.WriteLine(Database);
                Console.WriteLine(Password);
                connectionString = $"Server={server};Database={Database};User Id={Username};Password={Password};";
            }

            // connectionString = $"Server={server};Database={Database};integrated security= true";
        }
        protected SqlConnection GetConnection()
        {

                return new SqlConnection(connectionString);
                 

        }

       
    }
}
