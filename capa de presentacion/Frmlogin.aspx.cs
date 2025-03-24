using System;
using System.Web.UI;
using proyecto_proga.CapaNegocio;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        protected void btLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MostrarMensaje("Por favor, ingrese el correo y la clave.");
                return;
            }

            bool esValido = UsuarioBLL.VerificarUsuario(txtCorreo.Text, txtClave.Text);

            if (esValido)
            {
                Session["Usuario"] = txtCorreo.Text;
                Response.Redirect("FrmTecnico.aspx");
            }
            else
            {
                MostrarMensaje("Correo o contraseña incorrectos.");
            }
        }

        protected void btRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRegistro.aspx");
        }

        private void MostrarMensaje(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "');</script>");
        }
    }
}


