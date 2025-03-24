<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegistro.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmRegistro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registro de Usuario</h2>

            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br /><br />

            <label>Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br /><br />

            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br /><br />

            <label>Clave:</label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
            <br /><br />

        </div>
        <p>

            <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="FrmLogin.aspx">¿Ya tienes cuenta? Inicia sesión</asp:HyperLink>
        </p>
    </form>
</body>
</html>
