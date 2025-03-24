<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEquipos.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmEquipos" %>

<!DOCTYPE html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEquipos.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmEquipos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Equipos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px; max-width: 700px; margin: auto;">

            <h2>Gestión de Equipos</h2>

            <asp:Label runat="server" Text="ID del Equipo:" />
            <asp:TextBox ID="Tcodigo" runat="server" Enabled="false" /><br /><br />

            <asp:Label runat="server" Text="Tipo de Equipo:" />
            <asp:TextBox ID="TTipoEquipo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Modelo:" />
            <asp:TextBox ID="TModelo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Usuario Asignado:" />
            <asp:DropDownList ID="ddlUsuario" runat="server" /><br /><br />

            <asp:Button ID="BAgregarEquipo" runat="server" Text="Agregar" OnClick="BAgregarEquipo_Click" />
            <asp:Button ID="BModificarEquipo" runat="server" Text="Modificar" OnClick="BModificarEquipo_Click" />
            <asp:Button ID="BBorrarEquipo" runat="server" Text="Eliminar" OnClick="BBorrarEquipo_Click" /><br /><br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1">
                <Columns>
                    <asp:BoundField DataField="EquiposID" HeaderText="ID" />
                    <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="UsuarioID" HeaderText="UsuarioID" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>





