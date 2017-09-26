<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ComboEmpresas.ascx.vb" Inherits="Freedom.ComboEmpresas" %>

<div class="form-group form-group-default" style="padding-top:0px; padding-bottom: 2px; border: 0px;">
	<label>Empresa</label>
	<select class="full-width full-height" name="empresa" data-init-plugin="select2" 
		runat="server" id="cbxEmpresa" data-id="cbxEmpresa" tabindex="-1" aria-hidden="false" onchange="__doPostBack()" onserverchange="cbxEmpresa_ServerChange">
	</select>
</div>

