<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmReparaciones.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmReparaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Reparaciones</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px; max-width: 900px; margin: auto;">
            <h2>Gestión de Reparaciones</h2>

            <asp:Label runat="server" Text="ID Reparación:" />
            <asp:TextBox ID="txtID" runat="server" Enabled="false" /><br /><br />

            <asp:Label runat="server" Text="Usuario:" />
            <asp:DropDownList ID="ddlUsuario" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Equipo:" />
            <asp:DropDownList ID="ddlEquipo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Técnico:" />
            <asp:DropDownList ID="ddlTecnico" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Fecha:" />
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" /><br /><br />

            <asp:Label runat="server" Text="Estado:" />
            <asp:TextBox ID="txtEstado" runat="server" /><br /><br />

            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br /><br />

            <asp:GridView ID="gvReparaciones" runat="server" 
                AutoGenerateSelectButton="True" 
                AutoGenerateColumns="False" 
                OnSelectedIndexChanged="gvReparaciones_SelectedIndexChanged"
                BorderWidth="1" BorderStyle="Solid">
                <Columns>
                    <asp:BoundField DataField="ReparacionID" HeaderText="ID" />
                    <asp:BoundField DataField="UsuarioID" HeaderText="Usuario" />
                    <asp:BoundField DataField="EquipoID" HeaderText="Equipo" />
                    <asp:BoundField DataField="TecnicoID" HeaderText="Técnico" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>




