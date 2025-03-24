using System.Data;
using proyecto_proga.CapaDatos;

namespace proyecto_proga.CapaNegocio
{
    public class UsuarioBLL
    {
        private static UsuarioDAL usuarioDAL = new UsuarioDAL();

        // Método para llenar el DropDownList desde el formulario
        public static DataTable Listar()
        {
            return usuarioDAL.ObtenerUsuarios();
        }

        public static bool VerificarUsuario(string correo, string clave)
        {
            return usuarioDAL.VerificarUsuario(correo, clave);
        }

        public static DataTable ObtenerUsuariosSinEquipo()
        {
            return usuarioDAL.ObtenerUsuariosSinEquipo();
        }

        public static void InsertarUsuario(string nombre, string correo, string telefono, string clave)
        {
            usuarioDAL.InsertarUsuario(nombre, correo, telefono, clave);
        }

        public static void ModificarUsuario(int id, string nombre, string correo, string telefono, string clave)
        {
            usuarioDAL.ModificarUsuario(id, nombre, correo, telefono, clave);
        }

        public static void EliminarUsuario(int id)
        {
            usuarioDAL.EliminarUsuario(id);
        }
    }
}






