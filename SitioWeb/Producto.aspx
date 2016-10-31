<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Producto.aspx.cs" Inherits="Producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Productos</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <style type="text/css">
        .table-nonfluid {
            width: auto !important;
            text-align: center;
        }

        body {
            padding-top: 70px;
        }

        th, td {
            padding: 2px;
        }

        th {
            background-color: lightblue;
        }

        .grid td, .grid th {
            text-align: center;
        }
    </style>

</head>
<body>

    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="~/">Nombre de la aplicación</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a runat="server" href="~/">Inicio</a></li>
                    <li><a runat="server" href="~/About">Acerca de</a></li>
                    <li><a runat="server" href="~/Contact">Contacto</a></li>
                    <li><a runat="server" href="~/Cliente">Cliente</a></li>
                    <li><a runat="server" href="~/Producto">Producto</a></li>
                </ul>
                <asp:LoginView runat="server" ViewStateMode="Disabled">
                    <AnonymousTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Account/Register">Registrarse</a></li>
                            <li><a runat="server" href="~/Account/Login">Iniciar sesión</a></li>
                        </ul>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Account/Manage" title="Manage your account">Hello, <%: Context.User.Identity.GetUserName()  %>!</a></li>
                            <li></li>
                        </ul>
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
        </div>
    </nav>
    <form id="formulario" runat="server">
        <div class="container body-content">


            <h1 style="text-align: center">Productos</h1>
            <asp:Panel ID="pnlListado" runat="server">
                <div style="margin-left: auto; margin-right: auto; text-align: center;">
                    <asp:Label ID="lblNombre" runat="server" Text="Producto: "></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="butBuscar" runat="server" OnClick="butBuscar_Click" Text="Buscar" />

                    <br />

                    <br />

                    <asp:GridView ID="gridProductos" runat="server" class="table table-striped table-condensed table-nonfluid grid" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idProducto" HorizontalAlign="Center" OnPageIndexChanging="gridProductos_PageIndexChanging" OnSelectedIndexChanged="gridProductos_SelectedIndexChanged" OnSorting="gridProductos_Sorting" PageSize="5" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre">
                                <HeaderStyle VerticalAlign="Middle" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="codigo" HeaderText="Codigo de Barra" SortExpression="codigo_barras">
                                <HeaderStyle VerticalAlign="Middle" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="esCompuesto" HeaderText="Compuesto" ReadOnly="True">
                                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                            <asp:BoundField DataField="fechaAlta" DataFormatString="{0:d}" HeaderText="Fecha Alta" SortExpression="fecha_alta">
                                <HeaderStyle VerticalAlign="Middle" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fechaBaja" DataFormatString="{0:d}" HeaderText="Fecha Baja" SortExpression="fecha_baja">
                                <HeaderStyle VerticalAlign="Middle" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="precioVenta" DataFormatString="$ {0:N}" HeaderText="Precio Venta" SortExpression="precio_vta">
                                <HeaderStyle VerticalAlign="Middle" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <br />

                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-success" OnClick="btnAgregar_Click" />
                    &nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" class="btn btn-info" OnClick="btnConsultar_Click" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-warning" OnClick="btnModificar_Click" />
                    &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminar_Click" />

                    <br />
                    <br />
                    <asp:Label ID="lblPrimero" runat="server" Text=""></asp:Label>

                </div>

            </asp:Panel>

            <asp:Panel ID="pnlSeleccion" runat="server">
                <div class="row">

                    <div class="col-xs-11 col-xs-offset-1">

                        <br />
                        <asp:Label ID="accion" runat="server" Font-Size="X-Large" ForeColor="#000099"></asp:Label>
                        <table>

                            <tr>
                                <td>
                                    <asp:Label ID="lblId" runat="server" Text="Id: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtId" runat="server" Width="128px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProducto" runat="server" Text="Producto: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtProducto" runat="server" Width="128px"></asp:TextBox>

                                </td>
                                <td colspan="3">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProducto"
                                        SetFocusOnError="true" ErrorMessage="Debe ingresar un nombre!" Display="Dynamic"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCodigo" runat="server" Text="Código: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtCodigo" runat="server" Width="128px"></asp:TextBox></td>
                                <td colspan="3">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo"
                                        SetFocusOnError="true" ErrorMessage="Debe ingresar un código!" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator
                                        ID="codigoNumerico"
                                        ControlToValidate="txtCodigo"
                                        ValueToCompare="0"
                                        Operator="GreaterThan"
                                        Type="Integer"
                                        ErrorMessage="Debe ingresar un numero mayor a 0"
                                        Display="Dynamic"
                                        runat="server"> </asp:CompareValidator>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" Rows="2" TextMode="MultiLine" Width="128px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaAlta" runat="server" Text="Fecha Alta: "></asp:Label></td>
                                <td>
                                    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
                                    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
                                    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
                                    <asp:TextBox ID="txtFechaAlta" runat="server" minlength="10" MaxLength="10" Width="128px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" colspan="3">
                                    <script type="text/javascript">
                                        $(function () {
                                            $("[id$=txtFechaAlta]").datepicker({
                                                showOn: 'button',
                                                buttonImageOnly: true,
                                                dateFormat: "dd/mm/yy",
                                                buttonImage: 'http://jqueryui.com/resources/demos/datepicker/images/calendar.gif'
                                            });
                                        });
                                    </script>


                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaAlta"
                                        SetFocusOnError="true" ErrorMessage="Debe ingresar un fecha!" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator
                                        ID="dateValidator" runat="server"
                                        Type="Date"
                                        Operator="DataTypeCheck"
                                        ControlToValidate="txtFechaAlta"
                                        ErrorMessage="Ingrese una fecha valida!" Display="Dynamic"> </asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFechaBaja" runat="server" Text="Fecha Baja: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtFechaBaja" runat="server" minlength="10" MaxLength="10" Width="128px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" colspan="3">
                                    <%--<script type="text/javascript">
                                        $(function () {
                                            $("[id$=txtFechaBaja]").datepicker({
                                                showOn: 'button',
                                                buttonImageOnly: true,
                                                dateFormat: "dd/mm/yy",
                                                buttonImage: 'http://jqueryui.com/resources/demos/datepicker/images/calendar.gif'
                                            });
                                        });
                                    </script>
                                    <script>
                                        $('#btnAgregar').click(function(){
                            
                                            $("[id$=txtFechaAlta]").datepicker( "option", "disabled", false );
                                            $("[id$=txtFechaBaja]").datepicker( "option", "disabled", false );
                            
                                        });
                                    </script>
                                    <script>
                                        $('#btnConsultar').click(function () {
                                            $("[id$=txtFechaAlta]").datepicker( "option", "disabled", true );
                                            $("[id$=txtFechaBaja]").datepicker( "option", "disabled", true );
                                        }
                                        });
                                    </script>
                                    <script>
                                        $('#btnModificar').click(function () {
                                            $("[id$=txtFechaAlta]").datepicker( "option", "disabled", true );
                                            $("[id$=txtFechaBaja]").datepicker( "option", "disabled", false );
                                        }
                                        });
                                    </script>--%>
                                    <asp:CompareValidator
                                        ID="CompareValidator1" runat="server"
                                        Type="Date"
                                        Operator="DataTypeCheck"
                                        ControlToValidate="txtFechaBaja"
                                        ErrorMessage="Ingrese una fecha valida!" Display="Dynamic"> </asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPrecio" runat="server" Text="Precio Venta: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtPrecio" runat="server" Width="128px"></asp:TextBox>

                                </td>
                                <td colspan="3">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrecio"
                                        SetFocusOnError="true" ErrorMessage="Debe ingresar un precio!" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator
                                        ID="precioNumerico"
                                        ControlToValidate="txtPrecio"
                                        ValueToCompare="0"
                                        Operator="GreaterThan"
                                        Type="Integer"
                                        ErrorMessage="Debe ingresar un precio mayor a 0"
                                        Display="Dynamic"
                                        runat="server"> </asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFruto1" runat="server" Text="Fruto: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlFrutos1" runat="server" Width="128px"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="lblPorcentaje1" runat="server" Text="Porcentaje: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje1" runat="server" Width="128px"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="lblErrorPorc1" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFruto2" runat="server" Text="Fruto: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlFrutos2" runat="server" Width="128px"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="lblPorcentaje2" runat="server" Text="Porcentaje: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje2" runat="server" Width="128px"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="lblErrorPorc2" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFruto13" runat="server" Text="Fruto: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlFrutos3" runat="server" Width="128px"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="lblPorcentaje3" runat="server" Text="Porcentaje: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje3" runat="server" Width="128px"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="lblErrorPorc3" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFruto14" runat="server" Text="Fruto: "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlFrutos4" runat="server" Width="128px"></asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="lblPorcentaje4" runat="server" Text="Porcentaje: "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtPorcentaje4" runat="server" Width="128px"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="lblErrorPorc4" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>

</body>
</html>

