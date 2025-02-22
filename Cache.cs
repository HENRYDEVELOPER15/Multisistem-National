using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using Org.BouncyCastle.Utilities.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ja
{
    public class Cache:Conexion
    {

        int idInforme, idEmpresa, idEquipo, idResponsable, idservicio, idServicioEquipo;

        public int IdInforme { get => idInforme; set => idInforme = value; }
        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public int IdEquipo { get => idEquipo; set => idEquipo = value; }
        public int IdResponsable { get => idResponsable; set => idResponsable = value; }
        public int Idservicio { get => idservicio; set => idservicio = value; }
        public int IdServicioEquipo { get => idServicioEquipo; set => idServicioEquipo = value; }

        decimal telefono;
        public decimal Telefono { get => telefono; set => telefono = value; }

        string NombreEm, NombreRespo, Ing, Equipo, Modelo, Marca, Serial, Pendiente, Facturar;

        string direccion, contrato, Oficina;
        
        public string NombreEm1 { get => NombreEm; set => NombreEm = value; }
        public string NombreRespo1 { get => NombreRespo; set => NombreRespo = value; }
        public string Ing1 { get => Ing; set => Ing = value; }
        public string Equipo1 { get => Equipo; set => Equipo = value; }
        public string Modelo1 { get => Modelo; set => Modelo = value; }
        public string Marca1 { get => Marca; set => Marca = value; }
        public string Serial1 { get => Serial; set => Serial = value; }
        public string Pendiente1 { get => Pendiente; set => Pendiente = value; }
        public string Facturar1 { get => Facturar; set => Facturar = value; }
        string servicio;

        DateTime fecha, fechaIni, fechaFinal;
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime FechaIni { get => fechaIni; set => fechaIni = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        public string Servicio { get => servicio; set => servicio = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Contrato { get => contrato; set => contrato = value; }
        public string Oficina1 { get => Oficina; set => Oficina = value; }

        string falla, accion;
        public string Falla { get => falla; set => falla = value; }
        public string Accion { get => accion; set => accion = value; }


    

        public void ActualizarInforme(int id, string fecha, string ing, string ser, string fac, string pen, string fa, string fs)
        {
            string consulta = "UPDATE Informe SET fecha = @fecha, IngMantenimiento = @ing, Servicio = @ser, Facturar = @fac, Pendiente = @pen, fa = @fa, fs = @fs, actualizar = 1 WHERE Id_Informe = @id";

            using (var connection = GetConnection())
            {
                using (SqlCommand comando = new SqlCommand(consulta, connection))
                {
                    comando.Parameters.AddWithValue("@fecha", fecha);
                    comando.Parameters.AddWithValue("@ing", ing);
                    comando.Parameters.AddWithValue("@ser", ser);
                    comando.Parameters.AddWithValue("@fac", fac);
                    comando.Parameters.AddWithValue("@pen", pen);
                    comando.Parameters.AddWithValue("@fa", fa);
                    comando.Parameters.AddWithValue("@fs", fs);
                    comando.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

      
        public void ActualizarEmpresa(int id, string dire, string contra)
        {
            string consulta = "UPDATE Empresa SET Dirección = @dire, Contrato = @contra WHERE id_Empresa = @id";

            using (var connection = GetConnection())
            {
                using (SqlCommand comando = new SqlCommand(consulta, connection))
                {
                    comando.Parameters.AddWithValue("@dire", dire);
                    comando.Parameters.AddWithValue("@contra", contra);
                    comando.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarResponsable(int id, string of, long tel)
        {
          
        }

 
       

        public void ActualizarEquipo(int id, string acc, string fa)
        {

            string consulta = "UPDATE Equipo SET Fallas_Observación = @fa, Acciones = @acc WHERE id_Equipo = @id;";

            using (var connection = GetConnection())
            {
                using (SqlCommand comando = new SqlCommand(consulta, connection))
                {
                    comando.Parameters.AddWithValue("@fa", fa);
                    comando.Parameters.AddWithValue("@acc", acc);
                    comando.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    comando.ExecuteNonQuery();
                }
            }
            
        }
        public bool DatosInforme(int id)
        {
         
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT  * FROM Informe WHERE Id_Informe = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.CommandType = CommandType.Text;
                    
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IdInforme = reader.GetInt32(0);
                            Fecha = reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1); 
                            Ing1 = reader.GetString(2);
                            IdEmpresa = reader.GetInt32(3);
                            Servicio = reader.GetString(4);
                            Facturar1 = reader.GetString(5);
                            Pendiente1= reader.GetString(6); 
                            FechaIni = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7); 
                            FechaFinal = reader.IsDBNull(8) ? DateTime.MinValue : reader.GetDateTime(8); 
                        }

                        return true;
                    }
                    else
                        return false;

                    

                }

            }
        }

    

        public bool DatosEmpresa(int id)
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "SELECT  * FROM Empresa WHERE id_Empresa = @id;";
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NombreEm1 = reader.GetString(1);
                            Direccion = reader.GetString(2);
                            Contrato = reader.GetString(3);
                            IdEquipo = reader.GetInt32(4);
                            IdResponsable = reader.GetInt32(5);

                        }

                        return true;
                    }
                    else
                        return false;

                }
            }
        }


        public bool DatosEmpresa()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = "SELECT  * FROM Empresa WHERE id_Empresa = @id;";
                    command.Parameters.AddWithValue("@id", IdEmpresa);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NombreEm1 = reader.GetString(1);
                            Direccion = reader.GetString(2);
                            Contrato = reader.GetString(3);
                            IdEquipo = reader.GetInt32(4);
                            IdResponsable = reader.GetInt32(5);

                        }

                        return true;
                    }
                    else
                        return false;

                }
            }
        }


        public bool DatosResponsable()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT  * FROM Responsable WHERE id = @id;";
                    command.Parameters.AddWithValue("@id", IdResponsable);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NombreRespo1 = reader.GetString(1);
                            Oficina1 = reader.GetString(2);
                            Telefono = reader.GetDecimal(3);

                        }

                        return true;
                    }
                    else
                        return false;

                }
            }
        }


        public bool DatosEquipo()
        {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT  * FROM Equipo WHERE id_Equipo = @id;";
                    command.Parameters.AddWithValue("@id", IdEquipo);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Equipo1 = reader.GetString(1);
                            Marca1 = reader.GetString(2);
                            Modelo1 = reader.GetString(3);
                            Serial1 = reader.GetString(4);
                            Falla = reader.GetString(5);
                            Accion = reader.GetString(6);
                        }

                        return true;
                    }
                    else
                        return false;

                }
            }
        }

        public DataTable DatosCambios()
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Tipo_Repuesto, Serial_Defectuoso, Serial_Nuevo FROM Cambios WHERE id_Equipo = @id;";
                    command.Parameters.AddWithValue("@id", IdEquipo);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                }
                return dataTable;
            }
        }
    }
}
