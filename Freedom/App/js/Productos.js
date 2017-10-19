$(function () {

    $('#btnNuevoProducto').click(function () {
        $('#addNewAppModal').modal('show');
    });

    $('#btnTrigger').click(function () {
        if (validarModal()) {
            $("#btnAgregarProducto").click();
            return true;
        }
        return false;
    });

    var initTblProductos = function () {
        var table = $('#tblProductos');

        var settings = {
            "sDom": "<t><'row'<p i>>",
            "destroy": true,
            "scrollCollapse": true,
            "oLanguage": {
                "sLengthMenu": "_MENU_ ",
                "sInfo": "Mostrando <b>_START_ a _END_</b> de _TOTAL_ registros"
            },
            "iDisplayLength": 5
        };

        table.dataTable(settings);
    }


    initTblProductos();
});

function validarModal() {
    var concepto = $("#txtConcepto").val();

    if (concepto == "") {
        showDialog("Es necesario ingresar un concepto");
        return false;
    }

    return true;
}