$(function () {

    $('#tblEmpresas').on("click", "[data-id=editaEmpresa]", function (e) {
        var trow = $(this).parent().siblings(".editChecked");
        trow.find('input[type="checkbox"]').prop('checked', true);
        editarEmpresa();
    });

    $('#tblEmpresas').on("click", "[data-id=eliminaEmpresa]", function (e) {
        var trow = $(this).parent().siblings(".deleteChecked");
        trow.find('input[type="checkbox"]').prop('checked', true);
        showConfirmDialog("Eliminar Empresa", "Deseas eliminar esta empresa?", "Aceptar", eliminarEmpresa);
    });

});

function editarEmpresa() {
    var empresaId = "";
    $('#tblEmpresas #chkImpuestos').each(function () {
        if ($(this).prop('checked') == true) {
            var trow = $(this).parents('tr');
            empresaId = trow.find('input[name="lblEmpresaId"]').val();
        }
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
    $('#tblEmpresas #chkDeleteEmpresa').each(function () {
        if ($(this).prop('checked') == true) {
            var trow = $(this).parents('tr');
            empresaId = trow.find('input[name="lblEmpresaId"]').val();
        }
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
            window.location.replace("Empresas.aspx");
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}