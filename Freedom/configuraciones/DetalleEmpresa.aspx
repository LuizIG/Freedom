<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="DetalleEmpresa.aspx.vb" Inherits="Freedom.DetalleEmpresa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumb">
        <li>
            <a href='<%= ResolveUrl("~/configuraciones/Empresa.aspx")%>'>Empresas</a>
        </li>
        <li><a href="#" class="active">Nueva empresa</a>
        </li>
    </ul>

    <div data-rol="row">
        <div class="col-md-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        General
                    </div>
                </div>
                <div class="panel-body">
                        <div class="form-group form-group-default required">
                            <label>Nombre</label>
                            <input type="text" class="form-control" required="" />
                        </div>
                        <div class="form-group form-group-default required">
                            <label>RFC</label>
                            <input type="text" maxlength="13" class="form-control" required="" />
                        </div>
                        <div class="form-group form-group-default form-group-default-select2 required" style="height: 150px">
                            <label>Régimen fiscal</label>
                            <select class="full-width full-height select2-hidden-accessible" data-init-plugin="select2" multiple="" tabindex="-1" aria-hidden="true">
                                <option value="Jim">Persona física - Personas Físicas con Actividades Empresariales y Profesionales</option>
                                <option value="John">Persona física - De los régimenes fiscales preferentes y de las empresas multinacionales</option>
                                <option value="Lucy">Persona moral - Coordinados</option>
                            </select>
                        </div>
                        <div class="form-group form-group-default required">
                            <label>CURP</label>
                            <input type="text" maxlength="18" class="form-control" required="" />
                        </div>
                        <div class="checkbox check-primary">
                            <input type="checkbox" value="1" id="cbx_active" />
                            <label for="cbx_active">Empresa activa</label>
                        </div>
                        <div class="checkbox check-primary">
                            <input type="checkbox" value="1" id="cbx_default" />
                            <label for="cbx_default">Empresa predeterminada</label>
                        </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        Domicilio fiscal
                    </div>
                </div>
                <div class="panel-body">

                        <div class="form-group form-group-default required">
                            <label>Calle</label>
                            <input type="email" class="form-control" required="" />
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group form-group-default required">
                                    <label>No. ext</label>
                                    <input type="text" class="form-control" required="" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group form-group-default">
                                    <label>No. int</label>
                                    <input type="text" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group form-group-default required">
                            <label>Entre calles</label>
                            <input type="text" class="form-control" required="" />
                        </div>
                        <div class="form-group  form-group-default required">
                            <label>Colonia</label>
                            <input type="text" class="form-control"  required="" />
                        </div>
                        <div class="form-group form-group-default">
                            <label>C.P.</label>
                            <input type="text" maxlength="5"  class="form-control" value="" />
                        </div>
                        <div class="form-group form-group-default">
                            <label>Municipio</label>
                            <input type="text" class="form-control" value="" />
                        </div>
                        <div class="form-group form-group-default">
                            <label>Estado</label>
                            <input type="text" class="form-control" value="" />
                        </div>
                        <div class="form-group form-group-default">
                            <label>País</label>
                            <input type="text" class="form-control" value="" />
                        </div>
                        <div class="checkbox check-primary">
                            <input type="checkbox" value="1" id="cbx_same_address" />
                            <label for="cbx_same_address">¿Usar como lugar de emisión?</label>
                        </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
