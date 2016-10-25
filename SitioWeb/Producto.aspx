<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
</head>
<body>
    <h1 style="text-align:center">Productos</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlListado" runat="server">
            
            Nombre:
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="butBuscar" runat="server" OnClick="butBuscar_Click" Text="Buscar" />
            <br />
            <asp:GridView ID="gridProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id_Producto" GridLines="Vertical" PageSize="5" OnPageIndexChanging="gridProductos_PageIndexChanging" OnSelectedIndexChanged="gridProductos_SelectedIndexChanged" OnSorting="gridProductos_Sorting">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
                    <asp:CheckBoxField DataField="es_compuesto" HeaderText="Compuesto" ReadOnly="True">
                    <HeaderStyle Font-Underline="True" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:BoundField DataField="fecha_alta" DataFormatString="{0:d}" HeaderText="Fecha Alta" SortExpression="fecha_alta" />
                    <asp:BoundField DataField="fecha_baja" DataFormatString="{0:d}" HeaderText="Fecha Baja" SortExpression="fecha_baja" />
                    <asp:BoundField DataField="precio_vta" DataFormatString="$ {0:N}" HeaderText="Precio Venta" SortExpression="precio_vta" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            &nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
            &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" />
            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />



        </asp:Panel>
        
        <asp:Panel ID="pnlSeleccion" runat="server">

            <asp:Label ID="accion" runat="server" Font-Size="Larger" ForeColor="#000099"></asp:Label>
            <br />

            <asp:DropDownList ID="ddlFrutos" runat="server"></asp:DropDownList>
        </asp:Panel>


    </form>
</body>
</html>

