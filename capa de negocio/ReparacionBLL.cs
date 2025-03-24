using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using proyecto_proga.CapaDatos;

namespace proyecto_proga.CapaNegocio
{
    public class ReparacionBLL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public List<Cls_Reparacion> Listar()
        {
            List<Cls_Reparacion> lista = new List<Cls_Reparacion>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("ListarReparaciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Cls_Reparacion
                    {
                        ReparacionID = Convert.ToInt32(reader["ReparacionID"]),
                        UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                        EquipoID = Convert.ToInt32(reader["EquipoID"]),
                        TecnicoID = Convert.ToInt32(reader["TecnicoID"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Estado = reader["Estado"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Insertar(Cls_Reparacion r)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("InsertarReparacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UsuarioID", r.UsuarioID);
                cmd.Parameters.AddWithValue("@EquipoID", r.EquipoID);
                cmd.Parameters.AddWithValue("@TecnicoID", r.TecnicoID);
                cmd.Parameters.AddWithValue("@Fecha", r.Fecha);
                cmd.Parameters.AddWithValue("@Estado", r.Estado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Cls_Reparacion r)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("ModificarReparacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReparacionID", r.ReparacionID);
                cmd.Parameters.AddWithValue("@UsuarioID", r.UsuarioID);
                cmd.Parameters.AddWithValue("@EquipoID", r.EquipoID);
                cmd.Parameters.AddWithValue("@TecnicoID", r.TecnicoID);
                cmd.Parameters.AddWithValue("@Fecha", r.Fecha);
                cmd.Parameters.AddWithValue("@Estado", r.Estado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("EliminarReparacion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReparacionID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}



