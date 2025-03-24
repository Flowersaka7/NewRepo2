using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace proyecto_proga.CapaDatos
{
    public class EquipoDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public DataTable ObtenerEquipos()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void InsertarEquipo(string tipoEquipo, string modelo, int usuarioID)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarEquipo(int id, string tipoEquipo, string modelo, int usuarioID)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ModificarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // ✅ CORREGIDO: Nombre correcto del parámetro
                    cmd.Parameters.AddWithValue("@EquiposID", id);
                    cmd.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEquipo(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ya estaba bien
                    cmd.Parameters.AddWithValue("@EquiposID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}




