<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmUsuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px; max-width: 600px; margin: auto;">
            <h2>Gestión de Usuarios</h2>

            <asp:Label runat="server" Text="Código de Usuario:" />
            <asp:TextBox ID="Tcodigo" runat="server" Enabled="false" /><br /><br />

            <asp:Label runat="server" Text="Nombre:" />
            <asp:TextBox ID="Tnombre" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Correo:" />
            <asp:TextBox ID="Tcorreo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Teléfono:" />
            <asp:TextBox ID="Ttelefono" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Clave:" />
            <asp:TextBox ID="Tclave" runat="server" TextMode="Password" /><br /><br />

            <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
            <asp:Button ID="Bmodificar" runat="server" Text="Modificar" OnClick="Bmodificar_Click" />
            <asp:Button ID="Bborrar" runat="server" Text="Eliminar" OnClick="Bborrar_Click" /><br /><br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AutoGenerateColumns="False" BorderWidth="1" BorderStyle="Solid">
                <Columns>
                    <asp:BoundField DataField="UsuarioID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Clave" HeaderText="Clave" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

