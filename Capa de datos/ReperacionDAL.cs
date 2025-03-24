using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace proyecto_proga.CapaDatos
{
    public class ReparacionDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public DataTable Obtener()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_ObtenerReparaciones", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Insertar(Cls_Reparacion rep)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarReparacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", rep.UsuarioID);
                cmd.Parameters.AddWithValue("@EquipoID", rep.EquipoID);
                cmd.Parameters.AddWithValue("@TecnicoID", rep.TecnicoID);
                cmd.Parameters.AddWithValue("@Fecha", rep.Fecha);
                cmd.Parameters.AddWithValue("@Estado", rep.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Cls_Reparacion rep)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarReparacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", rep.ReparacionID);
                cmd.Parameters.AddWithValue("@UsuarioID", rep.UsuarioID);
                cmd.Parameters.AddWithValue("@EquipoID", rep.EquipoID);
                cmd.Parameters.AddWithValue("@TecnicoID", rep.TecnicoID);
                cmd.Parameters.AddWithValue("@Fecha", rep.Fecha);
                cmd.Parameters.AddWithValue("@Estado", rep.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarReparacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReparacionID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
