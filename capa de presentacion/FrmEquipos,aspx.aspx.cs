using System;
using System.Web.UI;
using proyecto_proga.CapaNegocio;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarUsuarios();
                LlenarGridEquipos();
            }
        }

        // Llenar el DropDownList con usuarios
        private void LlenarUsuarios()
        {
            ddlUsuario.DataSource = UsuarioBLL.Listar(); // ✅ Corregido
            ddlUsuario.DataTextField = "Nombre";
            ddlUsuario.DataValueField = "UsuarioID";
            ddlUsuario.DataBind();
        }

        // Llenar el GridView con equipos
        protected void LlenarGridEquipos()
        {
            GridView1.DataSource = EquipoBLL.Listar(); // ✅ Corregido
            GridView1.DataBind();
        }

        protected void BAgregarEquipo_Click(object sender, EventArgs e)
        {
            int usuarioID = Convert.ToInt32(ddlUsuario.SelectedValue);
            EquipoBLL.InsertarEquipo(TTipoEquipo.Text, TModelo.Text, usuarioID); // ✅
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo agregado correctamente.");
        }

        protected void BModificarEquipo_Click(object sender, EventArgs e)
        {
            int equipoID = Convert.ToInt32(Tcodigo.Text);
            int usuarioID = Convert.ToInt32(ddlUsuario.SelectedValue);
            EquipoBLL.ModificarEquipo(equipoID, TTipoEquipo.Text, TModelo.Text, usuarioID); // ✅
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo modificado correctamente.");
        }

        protected void BBorrarEquipo_Click(object sender, EventArgs e)
        {
            int equipoID = Convert.ToInt32(Tcodigo.Text);
            EquipoBLL.EliminarEquipo(equipoID); // ✅
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo eliminado correctamente.");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = GridView1.SelectedRow;
            Tcodigo.Text = fila.Cells[1].Text;
            TTipoEquipo.Text = fila.Cells[2].Text;
            TModelo.Text = fila.Cells[3].Text;
            ddlUsuario.SelectedValue = fila.Cells[4].Text;
        }

        private void LimpiarCamposEquipos()
        {
            Tcodigo.Text = "";
            TTipoEquipo.Text = "";
            TModelo.Text = "";
            ddlUsuario.SelectedIndex = 0;
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", $"alert('{mensaje}');", true);
        }
    }
}
