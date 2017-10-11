$(function () {

    $('#tblClientes').on("click", "[data-id=eliminaCliente]", function (e) {
        var trow = $(this).parent().siblings(".deleteChecked");
        trow.find('input[type="checkbox"]').prop('checked', true);
        showConfirmDialog("Eliminar Cliente", "Deseas eliminar este cliente?", "Aceptar", eliminarCliente);
    });

});

function eliminarCliente() {
    var clienteId = "";
    $('#tblClientes #chkDeleteCliente').each(function () {
        if ($(this).prop('checked') == true) {
            var trow = $(this).parents('tr');
            clienteId = trow.find('input[name="lblClienteId"]').val();
        }
    });

    var dataj = "{clienteId: '" + clienteId + "'}";
    var url = "Clientes.aspx/EliminarCliente";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;

            showDialog(data.Message);
            window.location.replace("Clientes.aspx");
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}