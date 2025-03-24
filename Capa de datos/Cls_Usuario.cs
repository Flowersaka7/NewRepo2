using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace proyecto_proga.CapaDatos
{
    public class UsuarioDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        //  Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //  Método para insertar un usuario
        public void InsertarUsuario(string nombre, string correo, string telefono, string clave)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarUsuario",con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //  Método para modificar un usuario
        public void ModificarUsuario(int id, string nombre, string correo, string telefono, string clave)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET nombre=@Nombre, correo=@Correo, telefono=@Telefono, clave=@Clave WHERE UsuarioID=@ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //  Método para eliminar un usuario
        public void EliminarUsuario(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE UsuarioID=@ID", con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerUsuariosSinEquipo()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuariosSinEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }



        // Método para verificar si un usuario existe en la base de datos
        public bool VerificarUsuario(string correo, string clave)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_VerificarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Si devuelve 1, el usuario existe; si devuelve 0, no existe.
                }
            }
        }
    }
}
