<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmTecnico.aspx.cs" Inherits="proyecto_proga.CapaPresentacion.FrmTecnico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Técnicos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px; max-width: 800px; margin: auto;">
            <h2>Gestión de Técnicos</h2>

            <asp:Label runat="server" Text="ID Técnico:" />
            <asp:TextBox ID="Tcodigo" runat="server" Enabled="false" /><br /><br />

            <asp:Label runat="server" Text="Nombre:" />
            <asp:TextBox ID="Tnombre" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Especialidad:" />
            <asp:TextBox ID="Tespecialidad" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Teléfono:" />
            <asp:TextBox ID="Ttelefono" runat="server" /><br /><br />

            <asp:Button ID="Bagregar" runat="server" Text="Agregar Técnico" OnClick="Bagregar_Click" />
            <asp:Button ID="Bmodificar" runat="server" Text="Modificar Técnico" OnClick="Bmodificar_Click" />
            <asp:Button ID="Bborrar" runat="server" Text="Eliminar Técnico" OnClick="Bborrar_Click" /><br /><br />

            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateSelectButton="True"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AutoGenerateColumns="False" BorderWidth="1" BorderStyle="Solid">
                <Columns>
                    <asp:BoundField DataField="TecnicoID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                </Columns>
            </asp:GridView>

            <hr />
            <h3>Gestión de Equipos</h3>

            <asp:Label runat="server" Text="ID Equipo:" />
            <asp:TextBox ID="TEquiposID" runat="server" Enabled="false" /><br /><br />

            <asp:Label runat="server" Text="Tipo de Equipo:" />
            <asp:TextBox ID="TTipoEquipo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Modelo:" />
            <asp:TextBox ID="TModelo" runat="server" /><br /><br />

            <asp:Label runat="server" Text="Usuario ID:" />
            <asp:TextBox ID="TUsuarioID" runat="server" /><br /><br />

            <asp:Button ID="BAgregarEquipo" runat="server" Text="Agregar Equipo" OnClick="BAgregar_Click" />
            <asp:Button ID="BModificarEquipo" runat="server" Text="Modificar Equipo" OnClick="BModificar_Click" />
            <asp:Button ID="BBorrarEquipo" runat="server" Text="Eliminar Equipo" OnClick="BBorrar_Click" /><br /><br />

            <!--  Grid de Equipos con botón seleccionar -->
            <asp:GridView ID="GridViewEquipos" runat="server"
                      AutoGenerateSelectButton="True"
                     OnSelectedIndexChanged="GridViewEquipos_SelectedIndexChanged"
                    AutoGenerateColumns="False"
                    BorderWidth="1" BorderStyle="Solid"
                   DataKeyNames="EquiposID">


                <Columns>
                    <asp:BoundField DataField="EquiposID" HeaderText="ID" />
                    <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="UsuarioID" HeaderText="Usuario ID" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>




