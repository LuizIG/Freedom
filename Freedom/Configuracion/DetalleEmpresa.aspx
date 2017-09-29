<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DetalleEmpresa.aspx.vb" Inherits="Freedom.DetalleEmpresa" %>
<%--<%@ MasterType VirtualPath="~/Site.Master" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul class="breadcrumb">
    <li>
        <a href='<%= ResolveUrl("~/Configuracion/Empresas.aspx")%>'>Empresas</a>
    </li>
    <li><a href="#" class="active"><asp:Label runat="server" ID="lblTitulo" ClientIDMode="Static"></asp:Label></a>
    </li>
</ul>
<%--<asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>--%>
	    <div id="rootwizard">
            <ul class="nav nav-tabs nav-tabs-linetriangle nav-tabs-separator nav-stack-sm" id="tabsEmpresa" role="tablist" data-init-reponsive-tabs="dropdownfx">
			    <li class="nav-item" id="tabInfo">
				    <a class="active" data-toggle="tab" href="#tab1" role="tab"><i class="fa fa-folder-open tab-icon"></i> <span>Información General</span></a>
			    </li>
			    <li class="nav-item" id="tabDomicilio">
				    <a class data-toggle="tab" id="refDomicilio" href="javascript:void(0);" role="tab"><i class="fa fa-home tab-icon"></i> <span>Domicilio Fiscal</span></a>
			    </li>
                <li class="nav-item" id="tabPersonalizacion" data-id="tabPersonalizacion">
				    <a class data-toggle="tab" id="refPersonalizacion" href="javascript:void(0);" role="tab"><i class="fa fa-cogs tab-icon"></i> <span>Personalización</span></a>
			    </li>
                <li class="nav-item" id="tabCertificados" data-id="tabCertificados">
				    <a class data-toggle="tab" id="refCertificados" href="javascript:void(0);" role="tab"><i class="fa fa-certificate tab-icon"></i> <span>Certificados</span></a>
			    </li>
                <li class="nav-item" id="tabContactos" data-id="tabContactos">
				    <a class data-toggle="tab" id="refContactos" href="javascript:void(0);" role="tab"><i class="fa fa-users tab-icon"></i> <span>Contactos</span></a>
			    </li>
                <%--<li class="nav-item" id="tabImpuestos" data-id="tabImpuestos">
				    <a class data-toggle="tab" id="refImpuestos" href="javascript:void(0);" role="tab"><i class="fa fa-line-chart tab-icon"></i> <span>Impuestos</span></a>
			    </li>--%>
			    <li class="nav-item" id="tabCheck">
				    <a class data-toggle="tab" id="refCheck" href="javascript:void(0);" role="tab"><i class="fa fa-check tab-icon"></i> <span>Resúmen</span></a>
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
                                    <asp:TextBox ID="txtEditarEmpresa" runat="server" ClientIDMode="Static" style="visibility:hidden; display: none"></asp:TextBox>
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
								        </div>
								        <div class="form-group form-group-default">
									        <label>CURP</label>
									        <asp:TextBox ID="txtCURP" runat="server" class="form-control" ClientIDMode="Static" MaxLength="18">
									        </asp:TextBox>
								        </div><br />
                                        <div class="row">
										    <div class="col-sm-6">
											    <div class="checkbox check-primary">
									                <input type="checkbox" value="1" id="cbx_active" data-id="cbx_active" checked="checked"/>
									                <label for="cbx_active">Empresa activa</label>
								                </div>
										    </div>
										    <div class="col-sm-6">
											    <div class="checkbox check-primary">
									                <input type="checkbox" value="1" id="cbx_default" data-id="cbx_default"/>
									                <label for="cbx_default">Empresa predeterminada</label>
								                </div>
										    </div>
									    </div>
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
                    <div data-rol="row">
                        <div class="col-md-6" id="domicilioFiscalPart">
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
									<div class="checkbox check-primary">
										<input type="checkbox" id="cbxEmision" value="1" data-id="cbxEmision" checked="checked"/>
										<label for="cbxEmision">¿Usar como lugar de emisión?</label>
									</div>
                                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                        <ul class="pager wizard no-style">
					                        <li class="next">
						                        <button class="btn btn-primary btn-cons btn-animated from-left fa fa-home pull-right" id="btnGuardarDomicilio" type="button">
							                        <span>Guardar</span>
						                        </button>
					                        </li>
                                            <li class="previous">
						                            <button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab2A">
						                            <span>Anterior</span>
					                            </button>
                                            </li>
				                        </ul>
			                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6" id="lugarEmisionPart">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        Lugar de Emisión
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group form-group-default required">
										<label>Calle</label>
										<asp:TextBox ID="txtCalleEmision" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
									<div class="row">
										<div class="col-sm-6">
											<div class="form-group form-group-default required">
												<label>No. ext</label>
												<asp:TextBox ID="txtNumExtEmision" runat="server" class="form-control" ClientIDMode="Static">
												</asp:TextBox>
											</div>
										</div>
										<div class="col-sm-6">
											<div class="form-group form-group-default">
												<label>No. int</label>
												<asp:TextBox ID="txtNumIntEmision" runat="server" class="form-control" ClientIDMode="Static">
												</asp:TextBox>
											</div>
										</div>
									</div>
									<div class="form-group form-group-default required">
										<label>Entre calles</label>
										<asp:TextBox ID="txtCallesEmision" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
                                    <div class="row">
										<div class="col-sm-6">
											<div class="form-group form-group-default required">
												<label>Colonia</label>
										        <asp:TextBox ID="txtColoniaEmision" runat="server" class="form-control" ClientIDMode="Static">
										        </asp:TextBox>
											</div>
										</div>
										<div class="col-sm-6">
											<div class="form-group form-group-default">
												<label>C.P.</label>
										        <asp:TextBox ID="txtCPEmision" runat="server" class="form-control" ClientIDMode="Static">
										        </asp:TextBox>
											</div>
										</div>
									</div>
                                    <div class="row">
										<div class="col-sm-6">
											<div class="form-group form-group-default">
												<label>País</label>
										            <select class="full-width full-height select2-hidden-accessible" name="pais" data-init-plugin="select2" onchange="cargarEstadosEmision(this.value);"
											        runat="server" id="cbxPaisEmision" data-id="cbxPaisEmision" tabindex="-1" aria-hidden="true">
										        </select>
											</div>
										</div>
										<div class="col-sm-6">
											<div class="form-group form-group-default">
												<label>Estado</label>
										        <select class="full-width full-height select2-hidden-accessible" name="estado" data-init-plugin="select2" 
											        runat="server" id="cbxEstadoEmision" data-id="cbxEstadoEmision" tabindex="-1" aria-hidden="true" >
										        </select>
											</div>
										</div>
									</div>
									<div class="form-group form-group-default">
										<label>Municipio</label>
										<asp:TextBox ID="txtMunicipioEmision" runat="server" class="form-control" ClientIDMode="Static">
										</asp:TextBox>
									</div>
                                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                        <ul class="pager wizard no-style">
					                        <li class="next">
						                        <button class="btn btn-primary btn-cons btn-animated from-left fa fa-home pull-right" id="btnGuardarLugarEmision" type="button">
							                        <span>Guardar</span>
						                        </button>
					                        </li>
                                            <li class="previous">
						                            <button class="btn btn-default btn-cons pull-right" type="button" id="btnAnteriorTab2B">
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
									        <label>Nombre</label>
									        <asp:TextBox ID="txtNombreComercial" runat="server" class="form-control"
											        name="usuario" ClientIDMode="Static" placeholder="Nombre Comercial">
									        </asp:TextBox>
								        </div>
                                        <div class="row">
										    <div class="col-sm-8" style="height:150px; display: flex; align-items: center;">
                                                <div class="form-group form-group-default input-group" style="padding-left:10px">
                                                    <div class="form-input-group">
                                                        <label style="color:#626262;">Logotipo</label>
										                <asp:TextBox ID="txtLogo" ForeColor="Black" BackColor="Window" ReadOnly="true" runat="server" placeholder="Logotipo de su empresa (150 x 150)" class="form-control" ClientIDMode="Static">
									                    </asp:TextBox>
                                                        <asp:TextBox ID="binaryLogo" runat="server" ClientIDMode="Static" style="visibility:hidden; display: none"></asp:TextBox>
                                                    </div>
                                                    <asp:FileUpload ID="fuLogo" accept=".jpg" onchange='selectLogo(event)' style="visibility:hidden; display: none" runat="server" class="btn btn-primary" ClientIDMode="Static"/>
                                                    <div class="input-group-addon btn btn-primary" onclick="showLogoFileDialog()">
                                                        <i class="fa fa-search"></i>
                                                    </div>
										        </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div style="height:150px; width:150px; border: 0.2px solid #626262; display: flex; align-items: center;">
                                                    <img src="" style="max-height:100%; max-width:100%;" id='output' data-id="output" runat="server" title="Tamaño sugerido de 150x150">
                                                </div>
                                            </div>
                                        </div><br />
								        <div class="form-group form-group-default required">
									        <label>Mensaje adicional en factura</label>
									        <asp:TextBox ID="txtMensaje" runat="server" placeholder="Mensaje adicional que requiera incluir en su factura" class="form-control" TextMode="MultiLine" ClientIDMode="Static" Height="70px">
									        </asp:TextBox>
								        </div>
                                        <div class="row">
										    <div class="col-sm-6">
											    <div class="form-group form-group-default">
												    <label>Telefonos</label>
										            <asp:TextBox ID="txtTelefonos" TextMode="Number" MaxLength="15" placeholder="Aparecerá en las facturas emitidas" runat="server" class="form-control" ClientIDMode="Static">
									                </asp:TextBox>
											    </div>
										    </div>
										    <div class="col-sm-6">
											    <div class="form-group form-group-default">
												    <label>Correo Electrónico</label>
										            <asp:TextBox ID="txtCorreo" TextMode="Email" placeholder="Aparecerá en la facturas emitidas" runat="server" class="form-control" ClientIDMode="Static">
									                </asp:TextBox>
											    </div>
										    </div>
									    </div>
                                        <div class="form-group form-group-default required">
									        <label>Titulo Correo</label>
									        <asp:TextBox ID="txtTitulo" runat="server" class="form-control"
											        name="usuario" ClientIDMode="Static" Text="Factura Electrónica: [@SerieFolio]">
									        </asp:TextBox>
								        </div>
                                        <div class="form-group form-group-default required">
									        <label>Contenido Correo</label>
									        <asp:TextBox ID="txtContenido" runat="server" class="form-control" TextMode="MultiLine" ClientIDMode="Static" Height="160px"
                                                Text="Buen día,
Agradecemos confirmar la recepción de los archivos PDF y XML al mismo correo electrónico que remite el presente, para cumplir con las políticas corporativas de la empresa.
En caso de no ser el contacto adecuado para el seguimiento de cobranza agradeceremos su comunicación. 

*** Confirme la validez de sus comprobantes fiscales digitales en: http://www.endorse.com.mx">
									        </asp:TextBox>
								        </div>
                                        <%--<div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                            <ul class="pager wizard no-style">
					                            <li class="next">
                                                        <button class="btn btn-success btn-cons btn-animated from-left fa fa-envelope pull-right" id="btnPersonalizarCorreo" type="button">
							                            <span>Personalizar Correo</span>
						                            </button>
					                            </li>
				                            </ul>
			                            </div>--%><br />
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
				    <div class="row row-same-height">
					    <div class="col-md-6 col-md-offset-3">
						    <div class="panel panel-default">
							    <div class="panel-heading">
								    <div class="panel-title">
									    Certificados Digitales
								    </div>
                                    <p>Por seguridad, los datos almancenados no se mostrarán en esta ventana</p>
                                    <p>La empresa tiene configurado el certificado de sello digital o las llaves privadas, no son desplegados por razones de seguridad</p>
							    </div>
							    <div class="panel-body">
                                    <div class="form-group form-group-default input-group" style="padding-left:10px">
                                        <div class="form-input-group">
                                            <label style="color:#626262;">Clave Privada (.key)</label>
										    <asp:TextBox ID="txtClavePrivada" ForeColor="Black" BackColor="Window" ReadOnly="true" runat="server" placeholder="Archivo con la clave privada de su empresa" class="form-control" ClientIDMode="Static">
									        </asp:TextBox>
                                            <asp:TextBox ID="binaryKey" runat="server" ClientIDMode="Static" style="visibility:hidden; display: none"></asp:TextBox>
                                        </div>
                                        <asp:FileUpload ID="fuClavePrivada" accept=".key" onchange='selectKey(event)' style="visibility:hidden; display: none" runat="server" class="btn btn-primary" ClientIDMode="Static"/>
                                        <div class="input-group-addon btn btn-primary" onclick="showFileDialog()">
                                            <i class="fa fa-search"></i>
                                        </div>
									</div>
                                    <div class="form-group form-group-default required">
									    <label>Contraseña de Clave Privada</label>
									    <asp:TextBox ID="txtPassClavePrivada" runat="server" class="form-control"
											    ClientIDMode="Static" TextMode="Password" placeholder="Contraseña relacionada con la Clave Privada">
									    </asp:TextBox>
								    </div>
                                    <div class="form-group form-group-default input-group" style="padding-left:10px">
                                        <div class="form-input-group">
                                            <label style="color:#626262;">Certificado de Sello Digital (.cer)</label>
										    <asp:TextBox ID="txtSelloDigital" runat="server" ForeColor="Black" BackColor="Window" ReadOnly="true" placeholder="Archivo que contiene el Certificado de Sello Digital" class="form-control" ClientIDMode="Static">
									        </asp:TextBox>
                                            <asp:TextBox ID="binaryCert" runat="server" ClientIDMode="Static" style="visibility:hidden; display: none"></asp:TextBox>
                                        </div>
                                        <asp:FileUpload ID="fuSelloDigital" accept=".cer" style="visibility:hidden; display: none" runat="server" ClientIDMode="Static" onchange="selectCert(event)" />
                                        <div class="input-group-addon btn btn-primary" onclick="showBrowseDialog()">
                                            <i class="fa fa-search"></i>
                                        </div>
									</div>
                                    <br />
                                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                        <ul class="pager wizard no-style">
					                        <li class="next">
						                        <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardarCertificados" type="button">
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
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
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
                                                            <asp:Repeater ID="repContactos" runat="server" OnItemCommand="repContactos_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr role="row">
                                                                        <td class="v-align-middle">
                                                                            <input name="lblContactoId" type="hidden" value='<%# Eval("ContactoId") %>'>
                                                                            <asp:TextBox ID="txtContactoId" ClientIDMode="Static" style="visibility:hidden; display: none" Text='<%# Eval("ContactoId") %>'></asp:TextBox>
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
                                                                             <span><i id="editaContacto" data-id="editaContacto" style="cursor: pointer;" class="fa fa-pencil fa-lg"></i></span>
                                                                             <asp:CheckBox runat="server" ID="chkEditContacto" style="visibility:hidden; display: none;" CssClass="editChecked" data-id="chkEditContacto" ClientIDMode="Static"/>
                                                                            <asp:LinkButton ID="btnEditarContacto" runat="server" onclick="btnEditarContacto_Click" style="visibility:hidden; display: none;" CommandName="Edit"></asp:LinkButton>
                                                                        </td>
                                                                        <td class="v-align-middle" style="text-align:center;">
                                                                             <span><i id="eliminaContacto" data-id="eliminaContacto" style="cursor: pointer;" class="fa fa-trash fa-lg"></i></span>
                                                                            <asp:CheckBox runat="server" ID="chkDeleteContacto" style="visibility:hidden; display: none" CssClass="deleteChecked" data-id="chkDeleteContacto" ClientIDMode="Static"/>
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
                                            <asp:AsyncPostBackTrigger ControlID="btnAgregarContacto" EventName="Click" />
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
                <%--<div class="tab-pane slide-left padding-20 sm-no-padding" id="tab6">
				    <div class="row row-same-height">
					    <div class="col-md-6 col-md-offset-3">
						    <div class="panel panel-default">
							    <div class="panel-heading">
								    <div class="panel-title">
									    Impuestos
								    </div>
							    </div>
							    <div class="panel-body">
                                    <div class="form-group form-group-default required">
									    <label>Comprobante</label>
									    <select class="full-width full-height select2-hidden-accessible" name="Comprobante" data-init-plugin="select2" 
											runat="server" id="cbxComprobante" data-id="cbxComprobante" tabindex="-1" aria-hidden="true" >
										</select>
								    </div>
                                    <div class="table-responsive">
                                        <div id="condensedTableImpuesto_wrapper" class="dataTables_wrapper form-inline no-footer">
                                            <table class="table table-hover dataTable no-footer" style="padding: 0px !important;" id="tblImpuestos" role="grid">
                                                <thead>
                                                    <tr role="row">
                                                        <th style="width: 1px; text-align:center; visibility:hidden;" class="sorting" Visible="false" tabindex="0" aria-controls="tblImpuestos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                                                        <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblImpuestos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Seleccionar</th>
                                                        <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblImpuestos" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Clasificación</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblImpuestos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Familia</th>
                                                        <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblImpuestos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Impuesto</th>
                                                    </tr>
                                                </thead>
                                                <tbody style="padding: 0px !important;">
                                                    <asp:Repeater ID="repImpuestos" runat="server">
                                                        <ItemTemplate>
                                                            <tr role="row" style="padding: 0px !important;">
                                                                <td class="v-align-middle" Visible="false" style="text-align:center; padding: 0px !important;">
                                                                    <input name="lblTipoImpuestoId" type="hidden" value='<%# Eval("TipoImpuestoId") %>'>
                                                                </td>
                                                                <td class="v-align-middle semi-bold sorting_1" style="text-align:center; padding: 0px !important;">
                                                                    <asp:CheckBox runat="server" ID="chkImpuestos" Checked='<%# IIf(Eval("Seleccionada") = 1, True, False) %>'/>
                                                                </td>
                                                                <td class="v-align-middle" style="text-align:center; padding: 0px !important;">
                                                                    <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("Clasificacion") %>' />
                                                                </td>
                                                                <td class="v-align-middle semi-bold" style="text-align:center; padding: 0px !important;">
                                                                    <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("Familia") %>' />
                                                                </td>
                                                                <td class="v-align-middle" style="text-align:center; padding: 0px !important;">
                                                                    <input name="lblTipoImpuesto" type="hidden" value='<%# Eval("TipoImpuesto") %>'>
                                                                </td>
                                                            </tr>  
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>     
                                            </table>
                                        </div>
                                    </div>
                                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				                        <ul class="pager wizard no-style">
					                        <li class="next">
						                        <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnGuardarImpuestos" type="button">
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
				    </div>
			    </div>--%>
                <div class="tab-pane slide-left padding-20 sm-no-padding" id="tab6">
                    <div class="row">
                        <div class="col-md-12" style="text-align:center;">
                            <h1>Resúmen de registro</h1>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Información General</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p id="fname" class="hint-text small">Nombre:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNombreEmpresa" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoNombre" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">RFC:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblRFC" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoRFC" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Régimen Fiscal: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblRegimen" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoRegimen" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <p class="hint-text small">CURP: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCURP" runat="server"></p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Domicilio Fiscal</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Calle:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCalle" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoCalle" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Num Exterior:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNoExt" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoNumExt" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <p class="hint-text small">Num Interior:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNoInt" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Entre calles:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCalles" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Colonia:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblColonia" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoColonia" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">CP:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCP" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Pais:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblPais" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Estado:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblEstado" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Municipio:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblMunicipio" runat="server"></p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row" id="resumenLugarEmision">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label for="fname1" class="control-label">Lugar de Emisión</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Calle:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCalleEmision" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoCalleEmision" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Num Exterior:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNumExtEmision" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoNumExtEmision" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <p class="hint-text small">Num Interior:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNumIntEmision" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Entre calles:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCallesEmision" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Colonia:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblColoniaEmision" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoColoniaEmision" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">CP:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCPEmision" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Pais:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblPaisEmision" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Estado:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblEstadoEmision" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Municipio:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblMunicipioEmision" runat="server"></p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Personalización</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Nombre:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblNombreComercial" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoNombreComercial" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Logotipo:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblLogotipo" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Mensaje Adicional: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblMensaje" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoMensaje" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <p class="hint-text small">Telefonos: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblTelefonos" runat="server"></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                       <p class="hint-text small">Correo: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblCorreoFactura" runat="server"></p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Certificados</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Clave Privada:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblClavePrivada" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoClavePrivada" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Contraseña:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblContraseñaLlavePrivada" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoContraseñaLlavePrivada" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Sello Digital: </p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblSelloDigital" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoSelloDigital" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Contactos</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Contactos:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblContactos" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoContactos" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--<div class="form-group row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <label class="control-label">Impuestos</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Comprobante:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblComprobante" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoComprobante" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <p class="hint-text small">Impuestos:</p>
                                    </div>
                                    <div class="col-md-8">
                                         <p data-id="lblImpuestos" runat="server"></p>
                                    </div>
                                    <div class="col-md-1">
                                         <span class="pull-left" runat="server"><i id="requeridoImpuestos" class="fa fa-exclamation"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                    </div>
                    


                    <div class="padding-20 sm-padding-5 sm-m-b-20 sm-m-t-20 bg-white clearfix">
				        <ul class="pager wizard no-style">
					        <li class="next">
						        <button class="btn btn-primary btn-cons btn-animated from-left fa fa-save pull-right" id="btnFinalizar" type="button">
							        <span>Finalizar</span>
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
<script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/DetalleEmpresa.js")) %>' type="text/javascript"></script>
</asp:Content>
