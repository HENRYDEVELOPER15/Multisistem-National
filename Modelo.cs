using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ja
{
    public class Modelo:Conexion
    {
        int id_Equipo, id_Responsable, id_Empresa, id_Informe;
        int contarpendi;
        public int Id_Equipo { get => id_Equipo; set => id_Equipo = value; }
        public int Id_Responsable { get => id_Responsable; set => id_Responsable = value; }
        public int Id_Empresa { get => id_Empresa; set => id_Empresa = value; }
        public int Id_Informe { get => id_Informe; set => id_Informe = value; }
        public int Contarpendi { get => contarpendi; set => contarpendi = value; }

        public void InsertarEmpresa(string Nombre, string direccion, string contrato)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Empresa (Nombre, Dirección, Contrato, id_Equipo, id_Responsable)" + "VALUES (@Nombre, @Direccion, @Contrato, @id_Equipo, @id_Responsable)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Contrato", contrato);
                    command.Parameters.AddWithValue("@id_Equipo", Id_Equipo);
                    command.Parameters.AddWithValue("@id_Responsable", Id_Responsable);
                    command.ExecuteNonQuery();
                    connection.Close();
                    IdEmpresa();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void InsertarResponsable(string Nombre, string oficina, long telefono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Responsable (Nombre, Oficina, Telefono)" + "VALUES (@Nombre, @Oficina, @Telefono)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Oficina", oficina);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.ExecuteNonQuery();
                    connection.Close();
                    IdResponsable();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void InsertarEquipo(string equipo, string modelo, string marca, string serial,string fallas, string acciones)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = " INSERT INTO Equipo (Equipo, Marca, Modelo, Serial, Fallas_Observación, Acciones)" + "VALUES (@Equipo, @Marca, @Modelo, @Serial, @Fallas_Observación, @Acciones);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Equipo", equipo);
                    command.Parameters.AddWithValue("@Marca", marca);
                    command.Parameters.AddWithValue("@Modelo", modelo);
                    command.Parameters.AddWithValue("@Serial", serial);
                    command.Parameters.AddWithValue("@Fallas_Observación", fallas);
                    command.Parameters.AddWithValue("@Acciones", acciones);
                    command.ExecuteNonQuery();
                    connection.Close();
                    IdEquipo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }
            }

        }
        public void InsertarCambios(string tipo, string seridef, string serinue)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Cambios(Tipo_Repuesto, Serial_Defectuoso,Serial_Nuevo,id_Equipo) VALUES (@Tipo_Repuesto, @Serial_Defectuoso, @Serial_Nuevo, @id_Equipo);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tipo_Repuesto",tipo);
                    command.Parameters.AddWithValue("@Serial_Defectuoso", seridef);
                    command.Parameters.AddWithValue("@Serial_Nuevo", serinue);
                    command.Parameters.AddWithValue("@id_Equipo", Id_Equipo);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void InsertarCambios(string tipo, string seridef, string serinue,int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Cambios(Tipo_Repuesto, Serial_Defectuoso,Serial_Nuevo,id_Equipo) VALUES (@Tipo_Repuesto, @Serial_Defectuoso, @Serial_Nuevo, @id_Equipo);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Tipo_Repuesto", tipo);
                    command.Parameters.AddWithValue("@Serial_Defectuoso", seridef);
                    command.Parameters.AddWithValue("@Serial_Nuevo", serinue);
                    command.Parameters.AddWithValue("@id_Equipo", id);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public void InsertarInforme(DateTime fecha, string ing, string servicio, string facturar, string pendiente, string fe, string fs)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Informe(fecha, IngMantenimiento, Id_Empresa, Servicio, Facturar, Pendiente, fa, fs) VALUES (@fecha, @IngMantenimiento, @Id_Empresa, @Servicio, @Facturar, @Pendiente, @fa, @fs);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@IngMantenimiento", ing);
                    command.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
                    command.Parameters.AddWithValue("@Servicio", servicio);
                    command.Parameters.AddWithValue("@Facturar", facturar);
                    command.Parameters.AddWithValue("@Pendiente", pendiente);
                    command.Parameters.AddWithValue("@fa", fe);
                    command.Parameters.AddWithValue("@fs", fs);
                    command.ExecuteNonQuery();
                    connection.Close();
                    IdInforme();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    
                }
       

            }
        }
        public void InsertarInforme(DateTime fecha, string ing, string servicio, string facturar, string pendiente, string fe, string fs, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO Informe(fecha, IngMantenimiento, Id_Empresa, Servicio, Facturar, Pendiente, fa, fs) VALUES (@fecha, @IngMantenimiento, @Id_Empresa, @Servicio, @Facturar, @Pendiente, @fa, @fs);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@IngMantenimiento", ing);
                    command.Parameters.AddWithValue("@Id_Empresa", id);
                    command.Parameters.AddWithValue("@Servicio", servicio);
                    command.Parameters.AddWithValue("@Facturar", facturar);
                    command.Parameters.AddWithValue("@Pendiente", pendiente);
                    command.Parameters.AddWithValue("@fa", fe);
                    command.Parameters.AddWithValue("@fs", fs);
                    command.ExecuteNonQuery();
                    connection.Close();
                    IdInforme();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }


            }
        }

        public void IdResponsable()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT IDENT_CURRENT('Responsable') AS id";
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Id_Responsable = Convert.ToInt32(result);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
        }
        public void IdEquipo()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT IDENT_CURRENT('Equipo') AS id_Equipo";
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        id_Equipo = Convert.ToInt32(result);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
        }
        public void Contarpendientes()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT COUNT(*) FROM Informe WHERE Pendiente = 'SI';";
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Contarpendi = Convert.ToInt32(result);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
        }
        public void IdEmpresa()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT IDENT_CURRENT('Empresa') AS id_Empresa";
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Id_Empresa = Convert.ToInt32(result);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
        }

        public int IdInforme()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT IDENT_CURRENT('Informe') AS id_Informe";
                    SqlCommand command = new SqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Id_Informe = Convert.ToInt32(result);
                    }
                 

                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.ToString());
                    
                }
                return -1;

            }
        }

        public DataTable Consultar(string consulta)
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT I.Id_Informe As 'Numero de Ficha', I.Fecha, E.Nombre As 'Empresa', I.IngMantenimiento As 'Ing. de Mantenimiento', I.actualizar FROM Informe I JOIN Empresa E ON I.Id_Empresa = E.id_Empresa JOIN Equipo Eq ON E.id_Equipo = Eq.id_Equipo WHERE I.Id_Informe LIKE '%{consulta}%' OR I.Fecha LIKE '%{consulta}%' OR E.Nombre LIKE '%{consulta}%' OR I.IngMantenimiento LIKE '%{consulta}%' OR Eq.Serial LIKE '%{consulta}%' ORDER BY I.Id_Informe DESC;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                }
                return dataTable;

            }
        }

        public DataTable GetData()
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT I.Id_Informe As 'Numero de Ficha', I.Fecha, E.Nombre As 'Empresa', I.IngMantenimiento As 'Ing. de Mantenimiento', I.actualizar FROM Informe I JOIN Empresa E ON I.Id_Empresa = E.id_Empresa ORDER BY I.Id_Informe DESC;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                }
                return dataTable;
            }
        }
        public DataTable GetDataCliente(int id)
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT I.Id_Informe As 'Numero de Ficha', I.Fecha, E.Nombre As 'Empresa', I.IngMantenimiento As 'Ing. de Mantenimiento' FROM Informe I JOIN Empresa E ON I.Id_Empresa = E.id_Empresa WHERE I.Id_Empresa = {id} ORDER BY I.Id_Informe DESC;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                }
                return dataTable;
            }
        }
        public DataTable GetClient()
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT  E. id_Empresa As 'No.', E.Nombre AS 'Empresa', E.Dirección AS 'Direccion', R.Nombre AS 'Responsable', R.Telefono AS 'Telefono`', R.Oficina AS 'Oficina' FROM  Empresa E JOIN Responsable R ON E.id_Responsable = R.id ORDER BY E.id_Empresa DESC;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                }
                return dataTable;
            }
        }
    }
}
