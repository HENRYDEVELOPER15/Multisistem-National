using ja;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;
using System.Data.OleDb;
using System.Data;

namespace MultiSystem
{
    public class modelo_impresora:Conexion
    {
        public void InsertarImpresora(string marca, string modelo, string serial, string nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Impresoras (Marca, Modelo, Serial, Nombre)" + "VALUES (@marca, @modelo, @serial, @nombre)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@marca", marca);
                    command.Parameters.AddWithValue("@modelo", modelo);
                    command.Parameters.AddWithValue("@serial",serial);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void LoadData(DataGridView dataGridView)
        {
            string query = "SELECT id, Nombre, Marca, Modelo, Serial, id_Empresa FROM Impresoras";

            using (var connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                dataGridView.Rows.Clear();
                while (reader.Read())
                {
                    
                    dataGridView.Rows.Add(
                        Properties.Resources.Impresora,
                        reader["id"].ToString(),
                        reader["Nombre"].ToString(),
                        reader["Marca"].ToString(),
                        reader["Modelo"].ToString(),
                        reader["Serial"].ToString(),
                        reader["id_Empresa"].ToString(),
                        "Acción");
                }

                reader.Close();
            }
        }

        public datos_Impresora CargarDatos(int idImpresora)
        {
            string query = "SELECT i.id, i.Nombre, i.Marca, i.Modelo, i.Serial, e.Nombre, i.id_empresa FROM Impresoras i JOIN Empresa e ON i.id_Empresa = e.id_Empresa WHERE i.id = @id;";
            datos_Impresora datos = new datos_Impresora();
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", idImpresora);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        datos.Id = reader.GetInt32(0);
                        datos.Nombre = reader.GetString(1);
                        datos.Marca = reader.GetString(2);
                        datos.Modelo = reader.GetString(3);
                        datos.Serial = reader.GetString(4);
                        datos.Nombre_em = reader.GetString(5);
                        datos.Id_em= reader.GetInt32(6);
                    }
                }
            }
            return datos;
        }

        public int InsertarEmpresa(string nombre, string direccion ,int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Empresa (Nombre, Dirección, id_Responsable)  OUTPUT INSERTED.id_Empresa VALUES (@nombre, @direccion, @id); ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@id", id);
                return (int)command.ExecuteScalar();
            }
        }

        public int InsertarResponsable(string Nombre, string oficina, long telefono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Responsable (Nombre, Oficina, Telefono) OUTPUT INSERTED.id VALUES (@Nombre, @Oficina, @Telefono); ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Oficina", oficina);
                command.Parameters.AddWithValue("@Telefono", telefono);
                return (int)command.ExecuteScalar();
            }
        }

        public void InsertarScanner(string ruta, DateTime fecha, int id, int id_em)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                DateTime soloFecha = fecha.Date;
                string query = "INSERT INTO Escaner (Ruta, Fecha, id_impresora, id_Empresa) VALUES (@ruta, @fecha, @id, @idE)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ruta",ruta);
                command.Parameters.AddWithValue("@fecha",soloFecha);
                command.Parameters.AddWithValue("@id",id);
                command.Parameters.AddWithValue("@idE",id_em);
                command.ExecuteNonQuery();
            }
        }

        public void InsertEmpresaImpresora(int idEmpresa, int idImpresora)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Empresa_Impresora (id_empresa, id_impresora) VALUES (@id_empresa, @id_impresora)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id_empresa", idEmpresa);
                    cmd.Parameters.AddWithValue("@id_impresora", idImpresora);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarImpresora(int id, int idEmpr)
        {
            string consulta = "UPDATE Impresoras SET id_Empresa = @id_em WHERE id = @id";

            using (var connection = GetConnection())
            {
                using (SqlCommand comando = new SqlCommand(consulta, connection))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@id_em", idEmpr);
                    connection.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<datos_empresa> CargarTipos()
        {
            List<datos_empresa> tipos = new List<datos_empresa>();
            using (var conection = GetConnection())
            {
                conection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText = "SELECT * FROM Empresa WHERE Nombre != ''";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tipos.Add(new datos_empresa
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        });
                    }

                    reader.Close();
                }
                return tipos;
            }
        }

        public DataTable getTabla(int id)
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "SELECT Titulo As Titulo, Ubicacion AS Caja, Fecha_origen AS Año FROM Documentos ORDER BY Id DESC;";
                    command.CommandText = "SELECT id, Ruta, Fecha FROM Escaner WHERE id_impresora = @id ORDER BY Fecha DESC;";
                    command.Parameters.AddWithValue("@id",id);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                return dataTable;
            }
        }
    }
}
