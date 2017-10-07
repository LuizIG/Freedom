<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.vb" Inherits="Freedom.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <ul class="breadcrumb">
    <li><a href="#" class="active">Usuarios</a></li>
</ul>

<div class="panel panel-transparent">
    <div class="panel-heading">
        <div class="panel-title">
            Usuarios
        </div>
         <div class="btn-group pull-right m-b-10">
             <a id="btnNuevoUsuario" class="btn btn-primary btn-cons"><i class="fa fa-plus"></i> Nuevo
            </a>
        </div>
        <div class="clearfix"></div>
    </div>
    <div class="panel-body">
        <table class="table table-hover demo-table-dynamic table-responsive-block dataTable no-footer" id="tblUsuarios">
            <thead>
                <tr role="row">
                    <th style="width: 1px; visibility:hidden;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Id</th>
                    <th style="width: 250px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Title: activate to sort column descending">Usuario</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Key: activate to sort column ascending">Nombre</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Password</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Email</th>
                    <th style="width: 150px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Activo</th>
                    <th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Perfil </th>
                    <%--<th style="width: 120px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Activo</th>
                    <th style="width: 80px; text-align:center;" class="sorting" tabindex="0" aria-controls="tblEmpresas" rowspan="1" colspan="1" aria-label="Condensed: activate to sort column ascending">Eliminar</th>--%>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repUsuarios" runat="server">
                    <ItemTemplate>
                        <tr role="row">
                            <td class="v-align-middle">
                            <input name="lblUsuarioId" type="hidden" value='<%# Eval("Id") %>'>
                        </td>
                        <td class="v-align-middle semi-bold sorting_1" style="text-align:center;">
                            <asp:Label ID="txtName" runat="server" Text='<%# Eval("Usuario") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                            <asp:Label ID="TextBox1" runat="server" Text='<%# Eval("Nombre") %>' />
                        </td>
                        <td class="v-align-middle semi-bold" style="text-align:center;">
                            <asp:Label ID="TextBox2" runat="server" Text='<%# Eval("Password") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Activo") %>' />
                        </td>
                        <td class="v-align-middle" style="text-align:center;">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Perfil") %>' />
                        </td>
                        <%--<td class="v-align-middle" style="text-align:center;">
                                <span><i id="eliminaFolio" data-id="eliminaFolio" style="cursor: pointer;" class="fa fa-trash"></i></span>
                            <asp:CheckBox runat="server" ID="chkDeleteFolio" style="visibility:hidden; display: none" CssClass="deleteChecked" data-id="chkDeleteFolio" ClientIDMode="Static"/>
                        </td>--%>
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
				<h4 class="p-b-5">Registrar Usuario</h4>
			</div>
			<div class="modal-body">
				<div class="row">
					<div class="col-sm-6">
						<div class="form-group form-group-default required">
		                    <label>Nombre</label>
                            <input type="text" runat="server" id="txtNombre" name="uname" placeholder="Nombre Completo" class="form-control" required>
	                    </div>
					</div>
				</div>
                <div class="row">
					<div class="col-md-6">
			            <div class="form-group form-group-default required">
				            <label>Apellido Paterno</label>
                            <input type="text" runat="server" id="txtApellidoPaterno" name="surnameP" placeholder="Paterno" class="form-control" required>
			            </div>
		            </div>
		            <div class="col-md-6">
			            <div class="form-group form-group-default">
				            <label>Apellido Materno</label>
                            <input type="text" runat="server" id="txtApellidoMaterno" name="surnameM" placeholder="Materno" class="form-control" required>
			            </div>
		            </div>
				</div>
                <div class="row">
		            <div class="col-md-6">
			            <div class="form-group form-group-default required">
				            <label>Email</label>
                            <input type="email" runat="server" id="txtEmail" name="email" placeholder="Correo electronico" class="form-control" required>
                        </div>
		            </div>
		            <div class="col-md-6">
			            <div class="form-group form-group-default">
				            <label>Teléfono</label>
                            <input type="text" runat="server" id="txtTelefono" name="phone" maxlength="10" placeholder="Celular" class="form-control" required>
                        </div>
		            </div>
	            </div>
                <div class="row">
		            <div class="col-md-6">
			            <div class="form-group form-group-default required">
				            <label>Contraseña</label>
                            <input type="password" runat="server" id="txtPass" name="pass" placeholder="Mínimo de 6 carácteres" class="form-control" required>
                        </div>
		            </div>
		            <div class="col-md-6">
			            <div class="form-group form-group-default">
				            <label>Confirmar Contraseña</label>
                            <input type="password" runat="server" id="txtConfirmarPass" name="pass2" placeholder="Repetir contraseña" class="form-control" required>
                        </div>
		            </div>
	            </div>
			</div>
			<div class="modal-footer">
				<button id="btnAgregarUsuario" type="button" style="visibility:hidden; display: none" runat="server" data-dismiss="modal" class="btn btn-primary btn-cons"></button>
                <button id="btnTrigger" type="button" class="btn btn-primary btn-cons">Agregar</button>
				<button type="button" class="btn btn-cons" data-dismiss="modal">Cancelar</button>
			</div>
		</div>
	</div>
</div>


<script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Usuarios.js")) %>' type="text/javascript"></script>
</asp:Content>
