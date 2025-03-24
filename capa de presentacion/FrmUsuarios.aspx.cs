using System;
using System.Web.UI;
using proyecto_proga.CapaNegocio;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            GridView1.DataSource = UsuarioBLL.Listar(); // ✅ Método corregido
            GridView1.DataBind();
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            UsuarioBLL.InsertarUsuario(Tnombre.Text, Tcorreo.Text, Ttelefono.Text, Tclave.Text);
            LlenarGrid();
            Limpiar();
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Tcodigo.Text);
            UsuarioBLL.ModificarUsuario(id, Tnombre.Text, Tcorreo.Text, Ttelefono.Text, Tclave.Text);
            LlenarGrid();
            Limpiar();
        }

        protected void Bborrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Tcodigo.Text);

                //  Clase y método corregidos
                EquipoBLL.EliminarEquiposPorUsuario(id);

                UsuarioBLL.EliminarUsuario(id);
                LlenarGrid();
                Limpiar();

                MostrarMensaje("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            Tcodigo.Text = "";
            Tnombre.Text = "";
            Tcorreo.Text = "";
            Ttelefono.Text = "";
            Tclave.Text = "";
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", $"alert('{mensaje}');", true);
        }
    }
}


