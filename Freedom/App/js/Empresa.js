function testDialog() {
    var test = "Test message";
    var dataj = "{test: '" + test + "'}";
    var url = "../configuraciones/Empresa.aspx/TestDialog";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;
            showConfirmDialog(data.Message, "Deseas realizar esta accion?", "Aceptar", testMsg);
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function testMsg() {
    showDialog("sucess!!!");
}