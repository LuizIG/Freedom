$(function () {

    $('#btnNuevaSerie').click(function () {
        $('#addNewAppModal').modal('show');
    });

    $('#btnTrigger').click(function () {
        if (validarModal()) {
            $("#btnAgregarFolio").click();
            return true;
        }
        return false;
    });

    var initTblFolios = function () {
        var table = $('#tblFolios');
        
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

        

        //$('#btnAgregarFolio').click(function () {
        //    table.dataTable().fnAddData([
        //        $("#appName").val(),
        //        $("#appDescription").val(),
        //        $("#appPrice").val(),
        //        $("#appNotes").val()
        //    ]);
        //    $('#addNewAppModal').modal('hide');
        //});
    }


    initTblFolios();
});

function validarModal() {
    var nombre = $("#txtNombreContacto").val();

    if (nombre == "") {
        showDialog("Es necesario ingresar el nombre del contacto");
        return false;
    }

    return true;
}