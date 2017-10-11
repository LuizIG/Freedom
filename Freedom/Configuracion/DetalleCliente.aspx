<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleCliente.aspx.vb" Inherits="Freedom.DetalleCliente" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul class="breadcrumb">
    <li>
        <a href='<%= ResolveUrl("~/Configuracion/Cliente.aspx")%>'>Clientes</a>
    </li>
    <li><a href="#" class="active"><asp:Label runat="server" ID="lblTitulo" ClientIDMode="Static"></asp:Label></a>
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
        <li class="nav-item" id="tabPersonalizacion" data-id="tabPersonalizacion">
			<a class data-toggle="tab" id="refPersonalizacion" href="javascript:void(0);" role="tab"><i class="fa fa-cogs tab-icon"></i> <span>Personalización</span></a>
		</li>
        <li class="nav-item" id="tabContactos" data-id="tabContactos">
			<a class data-toggle="tab" id="refContactos" href="javascript:void(0);" role="tab"><i class="fa fa-users tab-icon"></i> <span>Contactos</span></a>
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
                            <asp:TextBox ID="txtEditarCliente" runat="server" ClientIDMode="Static" style="visibility:hidden; display: none"></asp:TextBox>
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
						                <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-home pull-right" id="btnGuardarInfo" type="button">
							                        <span>Guardar</span>
						                        </button>
                                                <asp:Button runat="server" ID="btnTriggerUpdate" style="visibility:hidden; display: none" ClientIDMode="Static" OnClick="btnTriggerUpdate_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-home pull-right" id="btnGuardarDomicilio" type="button">
							                <span>Guardar</span>
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
								Personalizar
							</div>
						</div>
						<div class="panel-body">
							<div class="form-group form-group-default required">
								<label>Telefono</label>
								<asp:TextBox ID="txtTelefonoPer" runat="server" class="form-control"
										ClientIDMode="Static" placeholder="Telefono">
								</asp:TextBox>
							</div>
							<div class="form-group form-group-default required">
								<label>Correo</label>
								<asp:TextBox ID="txtCorreoPer" runat="server" placeholder="Correo" class="form-control" ClientIDMode="Static">
								</asp:TextBox>
							</div>
                            <div class="form-group form-group-default required">
								<label>Días de Créditp</label>
								<asp:TextBox ID="txtDiasCredito" runat="server" class="form-control"
										ClientIDMode="Static" placeholder="Dias de Credito">
								</asp:TextBox>
							</div>
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardarPersonalizar" type="button">
							                <span>Guardar</span>
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
            <br />
		    <div class="row row-same-height">
			    <div class="col-md-10 col-md-offset-1">
				    <div class="panel panel-default">
					    <div class="panel-heading">
						    <div class="panel-title">
							    Contactos
						    </div>
					    </div>
					    <div class="panel-body">
                            <asp:UpdatePanel runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="table-responsive">
                                        <div id="condensedTable_wrapper" class="dataTables_wrapper form-inline no-footer">
                                            <table class="table table-hover dataTable no-footer" id="tblContactos" role="grid">
                                                <thead>
                                                    <tr role="row">
                                                        <th style="width: 1px; visibility:hidden;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                                                        <th style="width: 250px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Nombre</th>
                                                        <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Teléfono Fijo</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Teléfono Móvil</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Correo Electrónico</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Puesto</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Tipo Contacto</th>
                                                        <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Editar</th>
                                                        <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblContactos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="repContactos" runat="server" OnItemCreated="repContactos_ItemCreated">
                                                        <ItemTemplate>
                                                            <tr role="row">
                                                                <td class="v-align-middle">
                                                                    <input name="lblContactoId" type="hidden" value='<%# Eval("ContactoId") %>'>
                                                                </td>
                                                                <td class="v-align-middle semi-bold sorting_1">
                                                                    <asp:Label ID="txtName" runat="server" Text='<%# Eval("NombreContacto") %>' />
                                                                </td>
                                                                <td class="v-align-middle">
                                                                    <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("TelefonoFijo") %>' />
                                                                </td>
                                                                <td class="v-align-middle semi-bold">
                                                                    <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("TelefonoMovil") %>' />
                                                                </td>
                                                                <td class="v-align-middle">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Correo") %>' />
                                                                </td>
                                                                <td class="v-align-middle">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Puesto") %>' />
                                                                </td>
                                                                <td class="v-align-middle">
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("TipoContacto") %>' />
                                                                </td>
                                                                <td class="v-align-middle editarEmpresa" style="text-align:center;">
                                                                    <asp:LinkButton runat="server" ID="btnEditarContacto" ForeColor="Black" ClientIDMode="Static" OnCommand="btnEditarContacto_Click" CssClass="fa fa-pencil fa-lg" CommandArgument='<%# Eval("ContactoId") %>'></asp:LinkButton>
                                                                </td>
                                                                <td class="v-align-middle" style="text-align:center;">
                                                                    <asp:LinkButton runat="server" ID="btnEliminarContacto" ForeColor="Black" ClientIDMode="Static" OnCommand="btnEliminarContacto_Click" CssClass="fa fa-trash fa-lg" CommandArgument='<%# Eval("ContactoId") %>'></asp:LinkButton>
                                                                </td>
                                                            </tr>  
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>     
                                            </table>
                                        </div>
                                    </div><br />
                                    <div class="row">
                                        <h5>Agregar Nuevo Contacto</h5>
									    <div class="col-sm-6">
										    <div class="form-group form-group-default required">
											    <label>Nombre</label>
										        <asp:TextBox ID="txtNombreContacto" placeholder="Nombre del Contacto" runat="server" class="form-control" ClientIDMode="Static">
									            </asp:TextBox>
										    </div>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
									    </div>
									    <div class="col-sm-6">
										    <div class="form-group form-group-default">
											    <label>Tipo de Contacto</label>
                                                <select class="full-width full-height select2-hidden-accessible" name="tipoContacto" data-init-plugin="select2" runat="server" id="cbxTipoContacto" data-id="cbxTipoContacto" tabindex="-1" aria-hidden="true">
									            </select>
										    </div>
									    </div>
								    </div>
                                    <div class="row">
									    <div class="col-sm-6">
										    <div class="form-group form-group-default">
											    <label>Teléfono Fijo</label>
										        <asp:TextBox ID="txtTelefonoFijo" placeholder="Teléfono Fijo" TextMode="Number" runat="server" MaxLength="15" class="form-control" ClientIDMode="Static">
									            </asp:TextBox>
										    </div>
									    </div>
									    <div class="col-sm-6">
										    <div class="form-group form-group-default">
											    <label>Teléfono Móvil</label>
										        <asp:TextBox ID="txtMovil" placeholder="Teléfono Móvil" TextMode="Number" runat="server" MaxLength="15" class="form-control" ClientIDMode="Static">
									            </asp:TextBox>
										    </div>
									    </div>
								    </div>
                                    <div class="row">
									    <div class="col-sm-6">
										    <div class="form-group form-group-default">
											    <label>Correo</label>
										        <asp:TextBox ID="txtCorreoContacto" placeholder="Correo del Contacto" runat="server" class="form-control" MaxLength="40" ClientIDMode="Static">
									            </asp:TextBox>
										    </div>
									    </div>
									    <div class="col-sm-6">
										    <div class="form-group form-group-default">
										            <label>Puesto</label>
										        <asp:TextBox ID="txtPuesto" placeholder="Puesto del Contacto" runat="server" class="form-control" MaxLength="40" ClientIDMode="Static">
									            </asp:TextBox>
										    </div>
									    </div>
								    </div>
                                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix" style="visibility: hidden; display: none;">
				                        <ul class="pager wizard no-style">
					                        <li class="next">
                                                <asp:Button runat="server" style="visibility: hidden; display: none;" ClientIDMode="Static" Text="Agregar Contacto" OnClick="btnAgregarContacto_Click" CssClass="btn btn-success btn-cons btn-animated from-left fa fa-users pull-right" ID="btnAgregarContacto" />
					                        </li>
				                        </ul>
			                        </div>
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="repContactos"/>
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
                                        <button class="btn btn-success btn-cons btn-animated from-left fa fa-users pull-right" id="btnTriggerAgregaContacto" type="button">
							                <span>Agregar Contacto</span>
						                </button>
					                </li>
				                </ul>
			                </div><br />
                            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                <ul class="pager wizard no-style">
					                <li class="next">
						                <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardarContactos" type="button">
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
		    </div>
	    </div>
		<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab5">
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
						                 <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardarFormasPago" type="button">
							                <span>Guardar</span>
						                </button>
					                </li>
					                <li class="previous">
						                <button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab5">
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
		<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab6">
			<h1>Registrar cliente</h1>
            <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				<ul class="pager wizard no-style">
					<li class="next">
						<button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardar" type="button" onclick="GuardarEmpresa();">
							<span>Guardar</span>
						</button>
					</li>
					<li class="previous">
						<button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab6">
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
