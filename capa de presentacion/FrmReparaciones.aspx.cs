using System;
using System.Web.UI.WebControls;
using proyecto_proga.CapaNegocio;
using proyecto_proga.CapaDatos;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmReparaciones : System.Web.UI.Page
    {
        ReparacionBLL reparacionBLL = new ReparacionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                CargarReparaciones();
            }
        }

        private void CargarCombos()
        {
            ddlUsuario.DataSource = UsuarioBLL.Listar();
            ddlUsuario.DataTextField = "Nombre";
            ddlUsuario.DataValueField = "UsuarioID";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("-- Seleccione usuario --", "0"));

            ddlEquipo.DataSource = EquipoBLL.Listar();
            ddlEquipo.DataTextField = "TipoEquipo"; // Usa una propiedad válida de tu entidad Equipo
            ddlEquipo.DataValueField = "EquiposID";
            ddlEquipo.DataBind();
            ddlEquipo.Items.Insert(0, new ListItem("-- Seleccione equipo --", "0"));

            ddlTecnico.DataSource = TecnicoBLL.Listar();
            ddlTecnico.DataTextField = "Nombre";
            ddlTecnico.DataValueField = "TecnicoID";
            ddlTecnico.DataBind();
            ddlTecnico.Items.Insert(0, new ListItem("-- Seleccione técnico --", "0"));
        }

        private void CargarReparaciones()
        {
            gvReparaciones.DataSource = reparacionBLL.Listar();
            gvReparaciones.DataBind();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Cls_Reparacion rep = new Cls_Reparacion
            {
                UsuarioID = int.Parse(ddlUsuario.SelectedValue),
                EquipoID = int.Parse(ddlEquipo.SelectedValue),
                TecnicoID = int.Parse(ddlTecnico.SelectedValue),
                Fecha = DateTime.Parse(txtFecha.Text),
                Estado = txtEstado.Text
            };

            reparacionBLL.Insertar(rep);
            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Cls_Reparacion rep = new Cls_Reparacion
            {
                ReparacionID = int.Parse(txtID.Text),
                UsuarioID = int.Parse(ddlUsuario.SelectedValue),
                EquipoID = int.Parse(ddlEquipo.SelectedValue),
                TecnicoID = int.Parse(ddlTecnico.SelectedValue),
                Fecha = DateTime.Parse(txtFecha.Text),
                Estado = txtEstado.Text
            };

            reparacionBLL.Modificar(rep);
            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            reparacionBLL.Eliminar(id);
            LimpiarCampos();
            CargarReparaciones();
        }

        protected void gvReparaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = gvReparaciones.SelectedRow;

            txtID.Text = fila.Cells[1].Text;
            ddlUsuario.SelectedValue = fila.Cells[2].Text;
            ddlEquipo.SelectedValue = fila.Cells[3].Text;
            ddlTecnico.SelectedValue = fila.Cells[4].Text;
            txtFecha.Text = Convert.ToDateTime(fila.Cells[5].Text).ToString("yyyy-MM-dd");
            txtEstado.Text = fila.Cells[6].Text;
        }

        private void LimpiarCampos()
        {
            txtID.Text = "";
            ddlUsuario.SelectedIndex = 0;
            ddlEquipo.SelectedIndex = 0;
            ddlTecnico.SelectedIndex = 0;
            txtFecha.Text = "";
            txtEstado.Text = "";
        }
    }
}
