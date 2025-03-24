using System.Data;
using proyecto_proga.CapaDatos;

namespace proyecto_proga.CapaNegocio
{
    public class TecnicoBLL
    {
        static TecnicoDAL tecnicoDAL = new TecnicoDAL();

        //  Método para llenar GridView
        public static DataTable Listar()
        {
            return tecnicoDAL.ObtenerTecnicos();
        }

        //  Insertar técnico
        public static void InsertarTecnico(string nombre, string especialidad, string telefono)
        {
            tecnicoDAL.InsertarTecnico(nombre, especialidad, telefono);
        }

        //  Modificar técnico
        public static void ModificarTecnico(int id, string nombre, string especialidad, string telefono)
        {
            tecnicoDAL.ModificarTecnico(id, nombre, especialidad, telefono);
        }

        //  Eliminar técnico
        public static void EliminarTecnico(int id)
        {
            tecnicoDAL.EliminarTecnico(id);
        }
    }
}

