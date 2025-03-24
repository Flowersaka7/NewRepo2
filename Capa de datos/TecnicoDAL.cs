using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace proyecto_proga.CapaDatos
{
    public class TecnicoDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        // ✅ Ahora incluye Telefono en el SELECT
        public DataTable ObtenerTecnicos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TecnicoID, Nombre, Especialidad, Telefono FROM Tecnicos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void InsertarTecnico(string nombre, string especialidad, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("InsertarTecnico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarTecnico(int id, string nombre, string especialidad, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("ModificarTecnico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TecnicoID", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Especialidad", especialidad);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarTecnico(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("EliminarTecnico", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TecnicoID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
