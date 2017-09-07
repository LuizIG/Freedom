var mostrarOverlay = true;

$("#modal-overlay").hide();
$document.ready(function () {
    $("#modal-overlay").hide();
});

$(document).on({
    ajaxStart: function () {
        if (mostrarOverlay) {
            $("#modal-overlay").show();
        }
    },
    ajaxStop: function () {
        $("#modal-overlay").hide();
    },
    ajaxError: function (event, jqxhr, settings, thrownError) {
        $("#modal-overlay").hide();
    }
});