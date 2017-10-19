<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Productos.aspx.vb" Inherits="Freedom.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul class="breadcrumb">
    <li><a href="#" class="active">Productos</a></li>
</ul>

<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Productos
        </div>
         <div class="btn-group pull-right m-b-10">
             <a id="btnNuevoProducto" class="btn btn-primary btn-cons"><i class="fa fa-plus"></i> Nuevo
            </a>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover demo-table-dynamic table-responsive-block dataTable no-footer" id="tblProductos">
            <thead>
                <tr role="row">
                    <th style="width: 1px; visibility:hidden;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                    <th style="width: 100px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Concepto</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Precio</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Unidad</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Código Interno</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Código SAT</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Moneda</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Categoria</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Sub-Categoria</th>
                    <th style="width: 60px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Editar</th>
                    <th style="width: 60px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblProductos" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repProductos" runat="server">
                    <ItemTemplate>
                        <tr role="row">
                            <td class="v-align-middle">
                            <input name="lblProductoId" type="hidden" value='<%# Eval("ProductoId") %>'>
                        </td>
                        <td class="v-align-middle semi-bold sorting_1" style="text-align:center;">
                            <asp:Label ID="txtName" runat="server" Text='<%# Eval("Concepto") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                            <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("Precio") %>' />
                        </td>
                        <td class="v-align-middle semi-bold" style="text-align:center;">
                            <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("Unidad") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CodigoInterno") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("CodigoSAT") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Moneda") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Categoria") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Subcategoria") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                            <asp:LinkButton runat="server" ID="btnEditarProducto" ForeColor="Black" ClientIDMode="Static" OnCommand="btnEditarProducto_Click" CssClass="fa fa-pencil fa-lg" CommandArgument='<%# Eval("ProductoId") %>'></asp:LinkButton>
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                            <asp:LinkButton runat="server" ID="btnEliminarProducto" ForeColor="Black" ClientIDMode="Static" OnCommand="btnEliminarProducto_Click" CssClass="fa fa-trash fa-lg" CommandArgument='<%# Eval("ProductoId") %>'></asp:LinkButton>
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
				<h4 class="p-b-5">Productos</h4>
			</div>
			<div class="modal-body">
				<div class="row">
					<div class="col-sm-8">
						<div class="form-group form-group-default">
							<label>Concepto</label>
							<asp:TextBox ID="txtConcepto" runat="server" class="form-control"
									name="concepto" ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
					<div class="col-sm-4">
                        <div class="form-group form-group-default">
							<label>Código Interno</label>
							<asp:TextBox ID="txtCodigoInterno" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
				</div>
                <div class="row">
                    <div class="col-sm-4">
                        <div class="form-group form-group-default">
							<label>Precio</label>
							<asp:TextBox ID="txtPrecio" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
					<div class="col-sm-4">
						<div class="form-group form-group-default">
							<label>Moneda</label>
							<select class="full-width full-height select2-hidden-accessible" name="moneda" data-init-plugin="select2" runat="server" 
                                id="cbxMoneda" data-id="cbxMoneda" tabindex="-1" aria-hidden="true">
							</select>
						</div>
					</div>
					<div class="col-sm-4">
						<div class="form-group form-group-default">
							<label>Código SAT</label>
							<select class="full-width full-height select2-hidden-accessible" name="codigoSat" data-init-plugin="select2" runat="server" 
                                id="cbxCodigoSat" data-id="cbxCodigoSat" tabindex="-1" aria-hidden="true">
							</select>
						</div>
					</div>
				</div>
                <div class="row">
					<div class="col-sm-6">
						<div class="form-group form-group-default">
							<label>Unidad</label>
							<asp:TextBox ID="txtUnidad" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
					<div class="col-sm-6">
                        <div class="form-group form-group-default">
							<label>Unidad SAT</label>
                            <asp:TextBox ID="txtUnidadSat" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
				</div>
                <div class="row">
					<div class="col-sm-7">
						<div class="form-group form-group-default">
							<label>Categoria</label>
							<asp:TextBox ID="txtCategoria" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
					<div class="col-sm-5">
                        <div class="form-group form-group-default">
							<label>Subcategoria</label>
                            <asp:TextBox ID="txtSubcategoria" runat="server" class="form-control"
									ClientIDMode="Static">
							</asp:TextBox>
						</div>
					</div>
				</div>
			</div>
			<div class="modal-footer">
				<button id="btnAgregarProducto" type="button" style="visibility:hidden; display: none" runat="server" onserverclick="btnAgregarProducto_ServerClick" data-dismiss="modal" class="btn btn-primary btn-cons"></button>
                <button id="btnTrigger" type="button" class="btn btn-primary btn-cons">Agregar</button>
				<button type="button" class="btn btn-cons" data-dismiss="modal">Cancelar</button>
			</div>
		</div>
	</div>
</div>


<script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Productos.js")) %>' type="text/javascript"></script>
</asp:Content>
