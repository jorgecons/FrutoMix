<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cliente.aspx.cs"
    Inherits="Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

  


    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>ABMC CLIENTE </h4>
        <asp:Panel ID="pnlBuscar" runat="server">
            <p>
                &nbsp;Nombre a Buscar&nbsp; : &nbsp;<asp:TextBox ID="TextBox1"  CssClass="form-control" runat="server" Width="326px"></asp:TextBox>

            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" class="btn-success" OnClick="Button1_Click" Text="Buscar" Width="205px" />
            </p>
            <p>
                &nbsp;
            </p>
            <asp:Panel ID="panel_grilla" runat="server" Height="284px">
                <strong>Listado De Clientes
                <br />
                <br />
                <br />
                <asp:GridView ID="grvCliente" runat="server" AutoGenerateColumns="False" CaptionAlign="Top" CellPadding="4" DataKeyNames="id_Cliente" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="728px" AllowPaging="True" PageSize="5" OnPageIndexChanging="grvCliente_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Id_cliente" HeaderText="idCliente" ReadOnly="True" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="documento" HeaderText="documento" />
                        <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha_Nacimiento" />
                        <asp:BoundField DataField="email" HeaderText="email" />
                        <asp:BoundField DataField="nom_localidad" HeaderText="localidad" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
        
                <br />
                <br />
                <br />
                <br />
        
                </strong>
            </asp:Panel>
            <asp:Panel ID="pnlBotones" runat="server" Height="150px" Width="600px" style="margin-top: 10px">
                <table class="nav-justified">
                    <tr>
                        <td style="width: 101px">
                            <asp:Button ID="btnAgregarArtGrv" class="btn-success" runat="server" Text="Agregar"
                                OnClick="btnAgregarArtGrv_Click1" /></td>
                        <td>
                            <asp:Button ID="btnEditarArtGrv" class="btn-warning" runat="server" Text="  Editar  " OnClick="btnEditarArtGrv_Click" /></td>
                        <td>
                            <asp:Button ID="btnConsultarArtGrv" class="btn-primary" runat="server" Text="Consultar"
                                Width="79px" OnClick="btnConsultarArtGrv_Click" /></td>
                        <td>
                          
                            <asp:Button ID="btnELiminarArtGrv" runat="server" class="btn-danger" Height="27px" OnClick="btnELiminarArtGrv_Click" Text="Eliminar" />
                        
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <p>




            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Text="Debe Seleccionar una fila"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:Panel ID="Panel_agregar" runat="server" Height="818px">
            <div style="height: 37px; background-color: #3333CC" id="panel_agregar">
                <asp:Label ID="Label2" runat="server" Text="Agregar" Style="color: #FFFFCC; font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label_editar" runat="server" Style="color: #FFFFCC; font-weight: 700; font-size: large"
                    Text="Editar"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label_eliminar" runat="server" Style="color: #FFFFCC; font-weight: 700; font-size: large"
                    Text="Eliminar"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label_consultar" runat="server" Style="color: #FFFFCC; font-weight: 700; font-size: large"
                    Text="Consultar"></asp:Label>
                <br />
                <br />
                <div style="height: 187px">
                    <ul>
                        <li style="font-size: medium">&nbsp;ID_Cliente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" CssClass="form-control"  runat="server" Width="183px"></asp:TextBox>
                            &nbsp;</li>
                    </ul>
                    <ul>
                        <li style="font-size: medium">Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txt_nombre"  CssClass="form-control"   runat="server" Width="183px" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <ul>
                        <li style="font-size: medium">Fecha de Nacimiento

                            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_nac]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                dateFormat: "dd/mm/yy",
                buttonImage: 'http://jqueryui.com/resources/demos/datepicker/images/calendar.gif'
            });
        });
    </script>
                            <asp:TextBox ID="txt_nac" runat="server" CssClass="form-control" TextMode="DateTime" Width="185px"></asp:TextBox>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <ul>
                        <li style="font-size: medium">Documento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txt_doc" runat="server" CssClass="form-control" Width="186px" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" BorderColor="White" ControlToValidate="txt_doc" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_doc" ErrorMessage="numero invalido" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <ul>
                        <li style="font-size: medium">email :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" Width="184px" MaxLength="20"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Formato invalido" ForeColor="#FF5050" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </li>
                        <li style="font-size: medium">Calle<asp:TextBox ID="txt_calle" runat="server" CssClass="form-control" style="margin-left: 0px" Width="320px" MaxLength="20"></asp:TextBox>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <ul>
                        <li style="font-size: medium">Localidad&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddl_loc" runat="server" CssClass="form-control" Width="276px">
                            </asp:DropDownList>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <ul>
                        <li style="font-size: medium">numero de calle
                            <asp:TextBox ID="txt_numCalle" runat="server" CssClass="form-control" style="margin-left: 0px" MaxLength="20"></asp:TextBox>
                        </li>
                        <li style="font-size: medium">Codigo postal
                            <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control" style="margin-left: 2px" MaxLength="20"></asp:TextBox>
                        </li>
                        <li style="font-size: medium"></li>
                        <li style="font-size: medium"></li>
                        <li style="font-size: medium">
                            <label>
                            <asp:CheckBox ID="cbPrimeraCompra" runat="server" Text="¿Es la primera vez que compra?" />
                            </label>
                        </li>
                    </ul>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                </div>
            </div>
        </asp:Panel>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
        <asp:Panel ID="panelaccion" runat="server" Height="83px" style="margin-bottom: 1px">
            &nbsp;&nbsp;
            <asp:Button ID="btnVolver" runat="server" Cssclass="btn btn-default" OnClick="btnVolver_Click" style="margin-left: 39px" Text="volver" Width="75px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEdita" runat="server" Cssclass="btn btn-success" OnClick="btnEdita_Click" style="margin-left: 0px" Text="Editar" Width="99px" />
            <asp:Button ID="btnAgregar"    Cssclass="btn btn-success" runat="server" Text="Agregar" OnClick="brnAgregar_Click" />
            <asp:Button ID="btnEliminar" CssClass="btn btn-danger"  runat="server" style="margin-left: 2px" Text="Eliminar" Width="76px" OnClick="btnEliminar_Click" />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </asp:Panel>
        <p>
            <span lang="ES">
            <br style="mso-special-character:line-break" />
<![if !supportLineBreakNewLine]>
            <br style="mso-special-character:line-break" />
<![endif]></span><span lang="ES" style="font-size:16.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:Arial"><o:p></o:p></span>
        </p>
        <p>&nbsp;</p>
    </div>



</asp:Content>
