using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto_proga.CapaNegocio;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("FrmLogin.aspx");

            if (!IsPostBack)
            {
                LlenarGridTecnicos();
                LlenarGridEquipos();
            }
        }

        // ========== TÉCNICOS ==========

        protected void LlenarGridTecnicos()
        {
            GridView1.DataSource = TecnicoBLL.Listar();
            GridView1.DataBind();
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            TecnicoBLL.InsertarTecnico(Tnombre.Text, Tespecialidad.Text, Ttelefono.Text);
            LlenarGridTecnicos();
            LimpiarCamposTecnicos();
            MostrarMensaje("Técnico agregado correctamente.");
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Tcodigo.Text, out int tecnicoID))
            {
                MostrarMensaje("Seleccione un técnico válido antes de modificar.");
                return;
            }

            TecnicoBLL.ModificarTecnico(tecnicoID, Tnombre.Text, Tespecialidad.Text, Ttelefono.Text);
            LlenarGridTecnicos();
            LimpiarCamposTecnicos();
            MostrarMensaje("Técnico modificado correctamente.");
        }

        protected void Bborrar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(Tcodigo.Text, out int tecnicoID))
            {
                MostrarMensaje("Seleccione un técnico válido antes de eliminar.");
                return;
            }

            TecnicoBLL.EliminarTecnico(tecnicoID);
            LlenarGridTecnicos();
            LimpiarCamposTecnicos();
            MostrarMensaje("Técnico eliminado correctamente.");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = GridView1.SelectedRow;
            Tcodigo.Text = fila.Cells[1].Text.Trim();
            Tnombre.Text = fila.Cells[2].Text.Trim();
            Tespecialidad.Text = fila.Cells[3].Text.Trim();
            Ttelefono.Text = fila.Cells[4].Text.Trim();
        }

        private void LimpiarCamposTecnicos()
        {
            Tcodigo.Text = "";
            Tnombre.Text = "";
            Tespecialidad.Text = "";
            Ttelefono.Text = "";
        }

        // ========== EQUIPOS ==========

        protected void LlenarGridEquipos()
        {
            GridViewEquipos.DataSource = EquipoBLL.Listar();
            GridViewEquipos.DataBind();
        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TUsuarioID.Text, out int usuarioID))
            {
                MostrarMensaje("Ingrese un Usuario ID válido.");
                return;
            }

            EquipoBLL.InsertarEquipo(TTipoEquipo.Text, TModelo.Text, usuarioID);
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo agregado correctamente.");
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TEquiposID.Text, out int equipoID) ||
                !int.TryParse(TUsuarioID.Text, out int usuarioID))
            {
                MostrarMensaje("Ingrese datos válidos antes de modificar.");
                return;
            }

            EquipoBLL.ModificarEquipo(equipoID, TTipoEquipo.Text, TModelo.Text, usuarioID);
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo modificado correctamente.");
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TEquiposID.Text, out int equipoID))
            {
                MostrarMensaje("Seleccione un equipo válido antes de eliminar.");
                return;
            }

            EquipoBLL.EliminarEquipo(equipoID);
            LlenarGridEquipos();
            LimpiarCamposEquipos();
            MostrarMensaje("Equipo eliminado correctamente.");
        }

        protected void GridViewEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GridViewEquipos.SelectedRow;

            //  Más seguro con SelectedDataKey
            if (GridViewEquipos.SelectedDataKey != null)
            {
                TEquiposID.Text = GridViewEquipos.SelectedDataKey.Value.ToString();
            }
            else
            {
                TEquiposID.Text = fila.Cells[1].Text.Trim();
            }

            TTipoEquipo.Text = fila.Cells[2].Text.Trim();
            TModelo.Text = fila.Cells[3].Text.Trim();
            TUsuarioID.Text = fila.Cells[4].Text.Trim();
        }

        private void LimpiarCamposEquipos()
        {
            TEquiposID.Text = "";
            TTipoEquipo.Text = "";
            TModelo.Text = "";
            TUsuarioID.Text = "";
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", $"alert('{mensaje}');", true);
        }
    }
}

