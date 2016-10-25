<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cliente.aspx.cs"
    Inherits="Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Registar un cliente </h4>
        <asp:Panel ID="pnlBuscar" runat="server">
            <p>
                &nbsp;Nombre a Buscar&nbsp; : &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="162px"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Buscar" Width="170px" />

            </p>
            <p>
                &nbsp;
            </p>
            <p><strong>Listado De Clientes </strong></p>
            <div class="table-responsive">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="grvCliente" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                            GridLines="None" Width="728px" HorizontalAlign="Center" DataKeyNames="id_Cliente" CaptionAlign="Top">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="Id_Cliente" HeaderText="idCliente" ReadOnly="True" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="documento" HeaderText="documento" />
                                <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha_Nacimiento" />
                                <asp:BoundField DataField="Email" HeaderText="email" />
                                <asp:BoundField DataField="Localidad" HeaderText="localidad" />
                                <asp:BoundField DataField="primera_vez" HeaderText="primera_vez" />
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
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <asp:Panel ID="pnlBotones" runat="server">
                <table class="nav-justified">
                    <tr>
                        <td>
                            <asp:Button ID="btnAgregarArtGrv" class="btn-success" runat="server" Text="Agregar"
                                OnClick="btnAgregarArtGrv_Click1" /></td>
                        <td>
                            <asp:Button ID="btnEditarArtGrv" class="btn-warning" runat="server" Text="  Editar  " /></td>
                        <td>
                            <asp:Button ID="btnConsultarArtGrv" class="btn-primary" runat="server" Text="Consultar"
                                Width="79px" /></td>
                        <td>
                            <asp:Button ID="btnELiminarArtGrv" class="btn-danger" runat="server" Text="Eliminar" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <p>&nbsp;</p>
        <p></p>
        <asp:Panel ID="Panel_agregar" runat="server" Height="272px">
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
                        <li style="font-size: medium">&nbsp;ID_Cliente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&
nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox3" runat="server" Width="183px"></asp:TextBox>
                        </li>
                    </ul>
                    <ul>
                        <li style="font-size: medium">Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox4" runat="server" Width="183px"></asp:TextBox>
                        </li>
                        <li style="font-size: medium">Documento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&n
bsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox5" runat="server" Width="186px"></asp:TextBox>
                        </li>
                        <li style="font-size: medium">email 
:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&
nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
        <p>&nbsp;</p>
    </div>



</asp:Content>
