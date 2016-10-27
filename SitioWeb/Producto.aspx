<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
</head>
<body>
    <form id="formulario" runat="server">

        <h1 style="text-align: center">Productos</h1>
        <asp:Panel ID="pnlListado" runat="server">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="lblNombre" runat="server" Text="Producto: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="butBuscar" runat="server" OnClick="butBuscar_Click" Text="Buscar" />

                <br />

                <asp:GridView ID="gridProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id_Producto" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridProductos_PageIndexChanging" OnSelectedIndexChanged="gridProductos_SelectedIndexChanged" OnSorting="gridProductos_Sorting" PageSize="5" ShowHeaderWhenEmpty="True">
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
                <br />

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                &nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                <asp:RequiredFieldValidator runat="server" ErrorMessage="ingrese un nombre" 
                ControlToValidate="txtNombre"
                Display="Dynamic"
                SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>

        </asp:Panel>

        <asp:Panel ID="pnlSeleccion" runat="server">

            <asp:Label ID="accion" runat="server" Font-Size="Larger" ForeColor="#000099"></asp:Label>
            <br />
            <asp:Label ID="lblId" runat="server" Text="Id: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProducto" runat="server" Text="Producto: "></asp:Label>
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCodigo" runat="server" Text="Código: "></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFechaAlta" runat="server" Text="Fecha Alta: "></asp:Label>
            <asp:TextBox ID="txtFechaAlta" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFechaBaja" runat="server" Text="Fecha Baja: "></asp:Label>
            <asp:TextBox ID="txtFechaBaja" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrecio" runat="server" Text="Precio Venta: "></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFruto1" runat="server" Text="Fruto: "></asp:Label>
            <asp:DropDownList ID="ddlFrutos1" runat="server" ></asp:DropDownList>
            <asp:Label ID="lblPorcentaje1" runat="server" Text="Porcentaje: "></asp:Label>
            <asp:TextBox ID="txtPorcentaje1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFruto2" runat="server" Text="Fruto: "></asp:Label>
            <asp:DropDownList ID="ddlFrutos2" runat="server"></asp:DropDownList>
            <asp:Label ID="lblPorcentaje2" runat="server" Text="Porcentaje: "></asp:Label>
            <asp:TextBox ID="txtPorcentaje2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFruto13" runat="server" Text="Fruto: "></asp:Label>
            <asp:DropDownList ID="ddlFrutos3" runat="server" ></asp:DropDownList>
            <asp:Label ID="lblPorcentaje3" runat="server" Text="Porcentaje: "></asp:Label>
            <asp:TextBox ID="txtPorcentaje3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFruto14" runat="server" Text="Fruto: "></asp:Label>
            <asp:DropDownList ID="ddlFrutos4" runat="server"></asp:DropDownList>
            <asp:Label ID="lblPorcentaje4" runat="server" Text="Porcentaje: "></asp:Label>
            <asp:TextBox ID="txtPorcentaje4" runat="server"></asp:TextBox>
            <br />
            
            
        </asp:Panel>
    </form>
</body>
</html>

