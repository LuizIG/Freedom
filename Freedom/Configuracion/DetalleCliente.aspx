<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleCliente.aspx.vb" Inherits="Freedom.DetalleCliente" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul class="breadcrumb">
    <li>
        <a href='<%= ResolveUrl("~/Configuracion/Cliente.aspx")%>'>Clientes</a>
    </li>
    <li>
        <a href="#" class="active">Nuevo Cliente</a>
    </li>
</ul>

<div id="rootwizard">
    <ul class="nav nav-tabs nav-tabs-linetriangle nav-tabs-separator nav-stack-sm" id="tabsCliente" role="tablist" data-init-reponsive-tabs="dropdownfx">
		<li class="nav-item" id="tabInfo">
			<a class="active" data-toggle="tab" href="#tab1" role="tab"><i class="fa fa-folder-open tab-icon"></i> <span>Información General</span></a>
		</li>
		<li class="nav-item" id="tabDomicilio">
			<a class data-toggle="tab" id="refDomicilio" href="javascript:void(0);" role="tab"><i class="fa fa-home tab-icon"></i> <span>Domicilio Fiscal</span></a>
		</li>
		<li class="nav-item" id="tabFormasPago" data-id="tabFormasPago">
			<a class data-toggle="tab" id="refFormasPago" href="javascript:void(0);" role="tab"><i class="fa fa-home tab-icon"></i> <span>Formas de Pago</span></a>
		</li>
		<li class="nav-item" id="tabCheck">
			<a class data-toggle="tab" id="refCheck" href="javascript:void(0);" role="tab"><i class="fa fa-check tab-icon"></i> <span>Registrar Cliente</span></a>
		</li>
	</ul>
	<div class="tab-content">
		<div class="tab-pane padding-20 sm-no-padding active slide-left" id="tab1">
			<div class="row row-same-height">
				<div class="col-md-6 col-md-offset-3">
					<div class="panel panel-default">
						<div class="panel-heading">
							<div class="panel-title">
								General
							</div>
						</div>
						<div class="panel-body">
							<div class="form-group form-group-default required">
								<label>Nombre</label>
								<asp:TextBox ID="txtNombre" runat="server" class="form-control"
										name="usuario" ClientIDMode="Static">
								</asp:TextBox>
							</div>
							<div class="form-group form-group-default required">
								<label>RFC</label>
									<asp:TextBox ID="txtRFC" runat="server" class="form-control" ClientIDMode="Static" MaxLength="13">
								</asp:TextBox>
							</div>
							<div class="form-group form-group-default required">
								<label>Régimen fiscal</label>
								<select class="full-width full-height select2-hidden-accessible" name="regimen" data-init-plugin="select2" runat="server" id="cbxRegimenFiscal" data-id="cbxRegimenFiscal" tabindex="-1" aria-hidden="true">
								</select>
							</div><br />
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-home pull-right" id="btnSiguienteTab1" type="button">
							                <span>Siguiente</span>
						                </button>
					                </li>
				                </ul>
			                </div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab2">
			<div class="row row-same-height">
				<div class="col-md-6 col-md-offset-3">
					<div class="panel panel-default">
						<div class="panel-heading">
							<div class="panel-title">
								Domicilio fiscal
							</div>
						</div>
						<div class="panel-body">
							<div class="form-group form-group-default required">
								<label>Calle</label>
								<asp:TextBox ID="txtCalle" runat="server" class="form-control" ClientIDMode="Static">
								</asp:TextBox>
							</div>
							<div class="row">
								<div class="col-sm-6">
									<div class="form-group form-group-default required">
										<label>No. ext</label>
										<asp:TextBox ID="txtNumExt" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
								<div class="col-sm-6">
									<div class="form-group form-group-default">
										<label>No. int</label>
										<asp:TextBox ID="txtNumInt" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
							</div>
							<div class="form-group form-group-default required">
								<label>Entre calles</label>
								<asp:TextBox ID="txtCalles" runat="server" class="form-control" ClientIDMode="Static">
								</asp:TextBox>
							</div>
                            <div class="row">
								<div class="col-sm-6">
									<div class="form-group form-group-default required">
										<label>Colonia</label>
										<asp:TextBox ID="txtColonia" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
								<div class="col-sm-6">
									<div class="form-group form-group-default">
										<label>C.P.</label>
										<asp:TextBox ID="txtCP" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
							</div>
                            <div class="row">
								<div class="col-sm-6">
									<div class="form-group form-group-default">
										<label>País</label>
										    <select class="full-width full-height select2-hidden-accessible" name="pais" data-init-plugin="select2" onchange="cargarEstados(this.value);"
											runat="server" id="cbxPais" data-id="cbxPais" tabindex="-1" aria-hidden="true">
										</select>
									</div>
								</div>
								<div class="col-sm-6">
									<div class="form-group form-group-default">
										<label>Estado</label>
										<select class="full-width full-height select2-hidden-accessible" name="estado" data-init-plugin="select2" 
											runat="server" id="cbxEstado" data-id="cbxEstado" tabindex="-1" aria-hidden="true" >
										</select>
									</div>
								</div>
							</div>
							<div class="form-group form-group-default">
								<label>Municipio</label>
								<asp:TextBox ID="txtMunicipio" runat="server" class="form-control" ClientIDMode="Static">
								</asp:TextBox>
							</div>
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-check pull-right" id="btnSiguienteTab2" type="button">
							                <span>Siguiente</span>
						                </button>
					                </li>
					                <li class="previous">
						                <button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab2">
						                <span>Anterior</span>
					                </button>
					                </li>
				                </ul>
			                </div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab3">
			<div class="row row-same-height">
				<div class="col-md-6 col-md-offset-3">
					<div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="panel-title">
                                Formas de pago
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="form-group form-group-default required">
								<label>Cuenta Contable</label>
								<asp:TextBox ID="txtCuentaContable" runat="server" class="form-control" ClientIDMode="Static">
								</asp:TextBox>
							</div>
							<div class="row">
								<div class="col-sm-6">
									<div class="form-group form-group-default required">
										<label>Método de Pago</label>
										<asp:TextBox ID="txtMetodoPago" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
								<div class="col-sm-6">
									<div class="form-group form-group-default">
										<label>Número de Cuenta</label>
										<asp:TextBox ID="txtNumCuenta" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
								</div>
							</div>
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-check pull-right" id="btnSiguienteTab3" type="button">
							                <span>Siguiente</span>
						                </button>
					                </li>
					                <li class="previous">
						                <button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab3">
						                <span>Anterior</span>
					                </button>
					                </li>
				                </ul>
			                </div>
                        </div>
                    </div>
				</div>
			</div>
		</div>
		<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab4">
			<h1>Registrar cliente</h1>
            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				<ul class="pager wizard no-style">
					<li class="next">
						<button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardar" type="button" onclick="GuardarEmpresa();">
							<span>Guardar</span>
						</button>
					</li>
					<li class="previous">
						<button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab4">
						<span>Anterior</span>
					</button>
					</li>
				</ul>
			</div>
		</div>
	</div>
</div>
 <script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/DetalleCliente.js")) %>' type="text/javascript"></script>
</asp:Content>
