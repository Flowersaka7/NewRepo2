using System;
using System.Web.UI;
using proyecto_proga.CapaNegocio;

namespace proyecto_proga.CapaPresentacion
{
    public partial class FrmRegistro : System.Web.UI.Page
    {
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    MostrarMensaje("Debe completar todos los campos.");
                    return;
                }

                UsuarioBLL.InsertarUsuario(txtNombre.Text, txtCorreo.Text, txtTelefono.Text, txtClave.Text);

                // Mensaje y redirección con JavaScript
                string script = "alert('Usuario registrado correctamente.'); window.location='FrmLogin.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "RegistroExitoso", script, true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al registrar usuario: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", $"alert('{mensaje}');", true);
        }
    }
}
