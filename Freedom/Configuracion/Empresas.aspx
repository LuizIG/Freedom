﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresas.aspx.vb" Inherits="Freedom.Empresa" %>

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
                <a href='<%= ResolveUrl("~/Configuracion/DetalleEmpresa.aspx")%>' type="button" class="btn btn-primary">Nueva</a>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <div id="condensedTable_wrapper" class="dataTables_wrapper form-inline no-footer">
                    <table class="table table-hover dataTable no-footer" id="tblEmpresas" role="grid">
                        <thead>
                            <tr role="row">
                                <th style="width: 250px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Nombre de Empresa</th>
                                <th style="width: 150px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Alias</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">RFC</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Estatus</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Default</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Certificados</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repEmpresas" runat="server">
                                <ItemTemplate>
                                  <tr role="row">
                                    <td class="v-align-middle semi-bold sorting_1">
                                        <asp:Label ID="txtName" runat="server" Text='<%# Eval("NombreEmpresa") %>' />
                                    </td>
                                    <td class="v-align-middle">
                                        <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("NombreComercial") %>' />
                                    </td>
                                    <td class="v-align-middle semi-bold">
                                        <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("RFC") %>' />
                                    </td>
                                    <td class="v-align-middle">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("EstatusEmpresa") %>' />
                                    </td>
                                    <td class="v-align-middle">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpresaDefault") %>' />
                                    </td>
                                    <td class="v-align-middle">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("CertificadoDigital") %>' />
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
