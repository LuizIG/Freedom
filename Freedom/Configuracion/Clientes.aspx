<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Freedom.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul class="breadcrumb">
        <li><a href="#" class="active">Clientes</a></li>
    </ul>

    <div class="panel panel-transparent">
        <div class="panel-heading">
            <div class="panel-title">
                Listado de clientes
            </div>
            <div class="btn-group pull-right m-b-10">
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Nuevo" ID="btnNuevoCliente" OnClick="btnNuevoCliente_Click"/>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <table class="table table-hover demo-table-dynamic table-responsive-block" id="tblClientes" role="grid">
                <thead>
                    <tr role="row">
                        <th style="width: 10px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Num. Cliente</th>
                        <th style="width: 150px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Cliente</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Regímen Fiscal</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">RFC</th>
                        <%--<th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Num. Externo</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Num. Interno</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Colonia</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">C.P.</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Municipio</th>
                        <th style="width: 80px;  text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Estado</th>--%>
                        <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Editar</th>
                        <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblClientes" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>
                    </tr>
                </thead>
                <asp:Repeater ID="repClientes" runat="server">
                    <ItemTemplate>
                        <tbody>
                            <tr role="row">
                                <td class="v-align-middle">
                                    <input name="lblClienteId" type="hidden" value='<%# Eval("ClienteId") %>'>
                                </td>
                                <td class="v-align-middle semi-bold sorting_1">
                                    <asp:Label ID="txtName" runat="server" Text='<%# Eval("NombreCliente") %>' />
                                </td>
                                <td class="v-align-middle">
                                    <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("RegimenFiscal") %>' />
                                </td>
                                <td class="v-align-middle semi-bold">
                                    <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("RFC") %>' />
                                </td>
                                <%--<td class="v-align-middle">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NumeroExterno") %>' />
                                </td>
                                <td class="v-align-middle">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("NumeroInterno") %>' />
                                </td>
                                <td class="v-align-middle">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Colonia") %>' />
                                </td>
                                <td class="v-align-middle">
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("CP") %>' />
                                </td>
                                <td class="v-align-middle">
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Municipio") %>' />
                                </td>
                                <td class="v-align-middle">
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Estado") %>' />
                                </td>--%>
                                <td class="v-align-middle editarEmpresa" style="text-align:center;">
                                    <asp:LinkButton runat="server" ID="btnEditarCliente" ForeColor="Black" ClientIDMode="Static" OnCommand="btnEditarCliente_Click" CssClass="fa fa-pencil fa-lg" CommandArgument='<%# Eval("ClienteId") %>'></asp:LinkButton>
                                </td>
                                <td class="v-align-middle" style="text-align:center;">
                                    <span><i id="eliminaCliente" data-id="eliminaCliente" style="cursor: pointer;" class="fa fa-trash fa-lg"></i></span>
                                    <asp:CheckBox runat="server" ID="chkDeleteCliente" style="visibility:hidden; display: none" CssClass="deleteChecked" data-id="chkDeleteCliente" ClientIDMode="Static"/>
                                </td>
                            </tr>  
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
     <script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Cliente.js")) %>' type="text/javascript"></script>
</asp:Content>
