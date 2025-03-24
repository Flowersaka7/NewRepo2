<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Inicio de Sesión</h2>
            <label>Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br /><br />

            <label>Clave:</label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btLogin" runat="server" Text="Iniciar Sesión" OnClick="btLogin_Click" />
            <asp:Button ID="btRegistrar" runat="server" Text="Registrarse" OnClick="btRegistrar_Click" />
        </div>
    </form>
</body>
</html>


