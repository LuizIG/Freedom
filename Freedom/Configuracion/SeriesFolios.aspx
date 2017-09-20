<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SeriesFolios.aspx.vb" Inherits="Freedom.SeriesFolios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <ul class="breadcrumb">
    <li><a href="#" class="active">Series y Folios</a></li>
</ul>

<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Series y Folios
        </div>
         <div class="btn-group pull-right m-b-10">
             <a id="btnNuevaSerie" class="btn btn-primary btn-cons"><i class="fa fa-plus"></i> Nueva
            </a>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover demo-table-dynamic table-responsive-block dataTable no-footer" id="tblFolios">
            <thead>
                <tr role="row">
                    <th style="width: 1px; visibility:hidden;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                    <th style="width: 250px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Empresa</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Serie</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Folio Inicial</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Folio Final</th>
                    <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Tipo Comprobante</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Fecha Registro </th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Activo</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repFolios" runat="server">
                    <ItemTemplate>
                        <tr role="row">
                            <td class="v-align-middle">
                            <input name="lblFolioId" type="hidden" value='<%# Eval("Id") %>'>
                        </td>
                        <td class="v-align-middle semi-bold sorting_1" style="text-align:center;">
                            <asp:Label ID="txtName" runat="server" Text='<%# Eval("Empresa") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                            <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("Serie") %>' />
                        </td>
                        <td class="v-align-middle semi-bold" style="text-align:center;">
                            <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("FolioInicial") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("FolioFinal") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TipoComprobante") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("FechaRegistro") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Activa") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <span><i id="eliminaFolio" data-id="eliminaFolio" style="cursor: pointer;" class="fa fa-trash"></i></span>
                            <asp:CheckBox runat="server" ID="chkDeleteFolio" style="visibility:hidden; display: none" CssClass="deleteChecked" data-id="chkDeleteFolio" ClientIDMode="Static"/>
                        </td>
                    </tr>  
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>     
        </table>
    </div>
</div>

<div class="modal fade stick-up" id="addNewAppModal" tabindex="-1" role="dialog" aria-labelledby="addNewAppModal" aria-hidden="true">
	<div class="modal-dialog">
		<div class="modal-content">
			<div class="modal-header clearfix ">
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true"><i class="pg-close fs-14"></i>
				</button>
				<h4 class="p-b-5">Folios y Series</h4>
			</div>
			<div class="modal-body">
				<div class="row">
					<div class="col-sm-6">
						<div class="form-group form-group-default" style="z-index:5000; position:relative;">
							<label>Comprobante</label>
							<select class="full-width full-height select2-hidden-accessible" name="comprobante" data-init-plugin="select2" runat="server" 
                                id="cbxComprobante" data-id="cbxComprobante" tabindex="-1" aria-hidden="true">
							</select>
						</div>
					</div>
					<div class="col-sm-6">
                        <div class="col-sm-2">
                            <div class="checkbox check-primary">
								<input type="checkbox" value="1" id="cbx_active" data-id="cbx_active" checked="checked"/>
                                <label for="cbx_active"></label>
							</div>
					    </div>
                        <div class="col-sm-10">
						    <div class="form-group form-group-default">
							    <label>Serie</label>
							    <asp:TextBox ID="txtSerie" runat="server" class="form-control"
									    name="serie" ClientIDMode="Static">
							    </asp:TextBox>
						    </div>
					    </div>
					</div>
				</div>
                <div class="row">
					<div class="col-sm-6">
						<div class="form-group form-group-default">
							<label>Folio Inicial</label>
							<asp:TextBox ID="txtFolioInicial" runat="server" class="form-control"
									name="serie" ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
					<div class="col-sm-6">
						<div class="form-group form-group-default">
							<label>Folio Final</label>
							<asp:TextBox ID="txtFolioFinal" runat="server" class="form-control"
									name="serie" ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button id="btnAgregarFolio" type="button" style="visibility:hidden; display: none" runat="server" onserverclick="btnAgregarFolio_ServerClick" data-dismiss="modal" class="btn btn-primary btn-cons"></button>
                <button id="btnTrigger" type="button" class="btn btn-primary btn-cons">Agregar</button>
				<button type="button" class="btn btn-cons" data-dismiss="modal">Cancelar</button>
			</div>
		</div>
	</div>
</div>


<script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/SeriesFolios.js")) %>' type="text/javascript"></script>
</asp:Content>
