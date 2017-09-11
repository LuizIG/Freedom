<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresas.aspx.vb" Inherits="Freedom.Empresa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <ul class="breadcrumb">
        <li><a href="#" class="active">Empresas</a></li>
    </ul>

    <div class="panel panel-transparent">
        <div class="panel-heading">
            <div class="panel-title">
                Listado de empresas
            </div>
            <div class="btn-group pull-right m-b-10">
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Nueva" ID="btnNuevaEmpresa" OnClick="btnNuevaEmpresa_Click"/>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <div id="condensedTable_wrapper" class="dataTables_wrapper no-footer">
                    <%--<table class="table table-hover dataTable no-footer" id="tblEmpresas" role="grid">--%>
                    <table class="table table-hover demo-table-dynamic table-responsive-block" id="tblEmpresas">
                        <thead>
                            <tr role="row">
                                <th style="width: 1px; text-align:center; visibility:hidden;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                                <th style="width: 250px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Nombre de Empresa</th>
                                <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Alias</th>
                                <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">RFC</th>
                                <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Estatus</th>
                                <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Default</th>
                                <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Certificados</th>
                                <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Editar</th>
                                <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repEmpresas" runat="server">
                                <ItemTemplate>
                                  <tr role="row">
                                     <td class="v-align-middle">
                                        <input name="lblEmpresaId" type="hidden" value='<%# Eval("EmpresaId") %>'>
                                    </td>
                                    <td class="v-align-middle semi-bold sorting_1" style="text-align:center;">
                                        <asp:Label ID="txtName" runat="server" Text='<%# Eval("NombreEmpresa") %>' />
                                    </td>
                                    <td class="v-align-middle" style="text-align:center;">
                                        <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("NombreComercial") %>' />
                                    </td>
                                    <td class="v-align-middle semi-bold" style="text-align:center;">
                                        <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("RFC") %>' />
                                    </td>
                                    <td class="v-align-middle" style="text-align:center;">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("EstatusEmpresa") %>' />
                                    </td>
                                    <td class="v-align-middle" style="text-align:center;">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpresaDefault") %>' />
                                    </td>
                                    <td class="v-align-middle" style="text-align:center;">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CertificadoDigital") %>' />
                                    </td>
                                      <td class="v-align-middle" style="text-align:center;">
                                         <span><i id="editaEmpresa" data-id="editaEmpresa" style="cursor: pointer;" class="fa fa-pencil"></i></span>
                                         <asp:CheckBox runat="server" ID="chkImpuestos" CssClass="editChecked" data-id="chkImpuestos" ClientIDMode="Static" style="visibility:hidden; display: none"/>
                                    </td>
                                    <td class="v-align-middle" style="text-align:center;">
                                         <span><i id="eliminaEmpresa" data-id="eliminaEmpresa" style="cursor: pointer;" class="fa fa-trash"></i></span>
                                    </td>
                                </tr>  
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>     
                    </table>
                </div>
            </div>
        </div>
    </div>


     <script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Empresa.js")) %>' type="text/javascript"></script>
</asp:Content>
