using System.Data;
using proyecto_proga.CapaDatos;

namespace proyecto_proga.CapaNegocio
{
    public class EquipoBLL // <--- Nombre corregido (antes EquiposBLL)
    {
        static EquipoDAL equipoDAL = new EquipoDAL();

        public static DataTable Listar() // <--- Método agregado
        {
            return equipoDAL.ObtenerEquipos();
        }

        public static void InsertarEquipo(string tipoEquipo, string modelo, int usuarioID)
        {
            equipoDAL.InsertarEquipo(tipoEquipo, modelo, usuarioID);
        }

        public static void ModificarEquipo(int id, string tipoEquipo, string modelo, int usuarioID)
        {
            equipoDAL.ModificarEquipo(id, tipoEquipo, modelo, usuarioID);
        }

        public static void EliminarEquipo(int id)
        {
            equipoDAL.EliminarEquipo(id);
        }


        // 🔧 Método adicional: Eliminar todos los equipos de un usuario
        public static void EliminarEquiposPorUsuario(int usuarioID)
        {
            DataTable equipos = equipoDAL.ObtenerEquipos();

            foreach (DataRow fila in equipos.Rows)
            {
                if (fila["UsuarioID"].ToString() == usuarioID.ToString())
                {
                    int equipoID = int.Parse(fila["EquiposID"].ToString());
                    equipoDAL.EliminarEquipo(equipoID);
                }
            }
        }
    }
}



