<%@ Page Title="Empresas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Empresa.aspx.vb" Inherits="Freedom.Empresa" %>

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
                <a href='<%= ResolveUrl("~/configuraciones/DetalleEmpresa.aspx")%>' type="button" class="btn btn-primary">Nueva</a>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <div id="condensedTable_wrapper" class="dataTables_wrapper form-inline no-footer">
                    <table class="table table-hover dataTable no-footer" id="basicTable" role="grid">
                        <thead>
                            <tr role="row">
                                <th style="width: 250px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Nombre de Empresa</th>
                                <th style="width: 150px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Alias</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">RFC</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Estatus</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Default</th>
                                <th style="width: 120px;" class="sorting" tabindex="0" aria-controls="basicTable" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Certificados</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr role="row" class="odd">
                                <td class="v-align-middle semi-bold sorting_1">Empresa 1 S.A. de C.V. rtg erg saetrg erg etrghreg  re ga rgarg</td>
                                <td class="v-align-middle">EMPRESA 1</td>
                                <td class="v-align-middle semi-bold">AAAA0000005GE</td>
                                <td class="v-align-middle">
                                    <div class="checkbox ">
                                        <input type="checkbox" value="1" id="cb_estatus_1">
                                        <label for="cb_estatus_1"></label>
                                    </div>
                                    <td class="v-align-middle">
                                        <div class="checkbox ">
                                            <input type="checkbox" value="1" id="cb_default_1">
                                            <label for="cb_default_1"></label>
                                        </div>
                                    </td>
                                    <td class="v-align-middle">
                                        <div class="checkbox ">
                                            <input type="checkbox" value="1" id="checkbox1">
                                            <label for="checkbox1"></label>
                                        </div>
                                    </td>
                            </tr>
                            <tr role="row" class="even">
                                <td class="v-align-middle semi-bold sorting_1">Empresa 2 S.A. de C.V.</td>
                                <td class="v-align-middle">EMPRESA 2</td>
                                <td class="v-align-middle semi-bold">BBBB0000005GE</td>
                                <td class="v-align-middle">
                                    <div class="checkbox ">
                                        <input type="checkbox" value="1" id="cb_estatus_2">
                                        <label for="cb_estatus_2"></label>
                                    </div>
                                    <td class="v-align-middle">
                                        <div class="checkbox ">
                                            <input type="checkbox" value="1" id="cb_default_2">
                                            <label for="cb_default_2"></label>
                                        </div>
                                    </td>
                                    <td class="v-align-middle">
                                        <div class="checkbox ">
                                            <input type="checkbox" value="2" id="checkbox2">
                                            <label for="checkbox2"></label>
                                        </div>
                                    </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
