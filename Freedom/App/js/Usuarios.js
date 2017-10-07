$(function () {

    $('#btnNuevoUsuario').click(function () {
        $('#addNewAppModal').modal('show');
    });

    $('#btnTrigger').click(function () {
        if (validarModal()) {
            $("#btnAgregarFolio").click();
            return true;
        }
        return false;
    });

    var initTblUsuarios = function () {
        var table = $('#tblUsuarios');

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


    initTblUsuarios();
});