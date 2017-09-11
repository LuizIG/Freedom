$(function () {

    $('[data-id=editaEmpresa]').click(function (e) {
        //$(this).parent().siblings(".editChecked").checked(true);
        var trow = $(this).parent().siblings(".editChecked");
        console.log(trow);
        var valor = trow.find('input[type="checkbox"]').val();
        valor.prop('checked') = true;
        console.log(valor);
        //$('#tblEmpresas input[type="checkbox"]').each(function () {
        //    $(this).checked(true);
        //});
        showConfirmDialog("Editar Empresa", "Deseas editar esta empresa?", "Aceptar", editarEmpresa);
    });

    $('[data-id=eliminaEmpresa]').click(function (e) {
        showConfirmDialog("Eliminar Empresa", "Deseas eliminar esta empresa?", "Aceptar", eliminarEmpresa);
    });

});

function editarEmpresa() {
    var empresaId = "";
    $('#tblEmpresas input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            var trow = $(this).parents('tr');
            empresaId = trow.find('input[name="lblEmpresaId"]').val();
        }

        //var trow = $(this).parents('tr');
        //empresaId = trow.find('input[name="lblEmpresaId"]').val();

        //if (empresaId != "") {
        //    return false;
        //}
    });

    var dataj = "{empresaId: '" + empresaId + "'}";
    var url = "Empresas.aspx/EditarEmpresa";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;

            window.location.replace("DetalleEmpresa.aspx");
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function eliminarEmpresa() {
    var empresaId = "";
    $('#tblEmpresas [data-id=eliminaEmpresa]').each(function () {
        var trow = $(this).parents('tr');
        empresaId = trow.find('input[name="lblEmpresaId"]').val();
    });

    var dataj = "{empresaId: '" + empresaId + "'}";
    var url = "Empresas.aspx/EliminarEmpresa";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;

            showDialog(data.Message);
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}