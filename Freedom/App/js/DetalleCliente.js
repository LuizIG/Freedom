$(function () {
    $(window).load(function () {
        cargarEstados(1);
    });

    var editar = $("#txtEditarCliente").val();
    var validacionesTabs = true;

    if (editar == "True") {
        validacionesTabs = false;
    } else {
        //validacionesTabs = true;
        validacionesTabs = false;
    }
    
    $('#tabsCliente a[href="#tab1"]').tab('show');

    $('#btnGuardarInfo').click(function (e) {
        if (validarInfoGeneral()) {
            GuardarCliente();
            return true;
        } else {
            return false;
        }
    });

    $('#btnGuardarDomicilio').click(function (e) {
        if (validarDomicilioFiscal()) {
            GuardarDomicilio();
            return true;
        } else {
            return false;
        }
    });



    $('#btnFinalizar').click(function (e) {
        window.location.replace("Clientes.aspx");
    });

    $('#btnAnteriorTab2').click(function (e) {
        e.preventDefault();
        $('#tabsCliente a[href="#tab1"]').tab('show');
    });

    $('#btnAnteriorTab3').click(function (e) {
        e.preventDefault();
        $('#tabsCliente a[href="#tab2"]').tab('show');
    });

    $('#btnAnteriorTab4').click(function (e) {
        e.preventDefault();
        $('#tabsCliente a[href="#tab3"]').tab('show');
    });

    $('#btnAnteriorTab5').click(function (e) {
        e.preventDefault();
        $('#tabsCliente a[href="#tab4"]').tab('show');
    });

    $('#btnAnteriorTab6').click(function (e) {
        e.preventDefault();
        $('#tabsCliente a[href="#tab5"]').tab('show');
    });


});

function getInfoParams() {
    var retValue = [];
    var item = {};
    item["ParamName"] = "Nombre";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtNombre").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "RFC";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtRFC").val();
    retValue.push(item);

    var options = $("[data-id=cbxRegimenFiscal] option:selected").val(); //$("[data-init-plugin=select2] option:selected").map(function () { return this.value }).get().join(", ");
    item = {};
    item["ParamName"] = "RegimenFiscal";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = options;
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function getDomicilioParams() {
    var retValue = [];
    var item = {};
    item["ParamName"] = "Calle";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCalle").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "NumExt";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtNumExt").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "NumInt";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtNumInt").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Calles";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCalles").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Colonia";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtColonia").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "CP";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCP").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Municipio";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtMunicipio").val();
    retValue.push(item);

    var estado = $("[data-id=cbxEstado] option:selected").val();
    item = {};
    item["ParamName"] = "Estado";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = estado;
    retValue.push(item);

    var pais = $("[data-id=cbxPais] option:selected").val();
    item = {};
    item["ParamName"] = "Pais";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = pais;
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function validarInfoGeneral() {
    var nombre = $("#txtNombre").val();
    var rfc = $("#txtRFC").val();
    var regimenFiscal = $("[data-id=cbxRegimenFiscal] option:selected").val();

    if (nombre == "") {
        showDialog("Ingrese el nombre o razón social del cliente");
        return false;
    }

    if (rfc == "") {
        showDialog("Ingrese el RFC del cliente");
        return false;
    } else {
        if (rfc.length != 13) {
            showDialog("El RFC debe ser de 13 carácteres");
            return false;
        } else {
            if (!validarRFC(rfc, false)) {
                showDialog("El RFC tiene un formato incorrecto");
                return false;
            }
        }
    }

    if (regimenFiscal == "") {
        showDialog("Seleccione el régimen fiscal del cliente");
        return false;
    }

    return true;
}

function validarDomicilioFiscal() {
    var calle = $("#txtCalle").val();
    var numExt = $("#txtNumExt").val();
    var calles = $("#txtCalles").val();
    var colonia = $("#txtColonia").val();

    if (calle == "") {
        showDialog("Ingrese la calle de la dirección del cliente");
        return false;
    }

    if (numExt == "") {
        showDialog("Ingrese el número exterior de la dirección del cliente");
        return false;
    }

    if (calles == "") {
        showDialog("Indique entre que calles se encuentra la dirección del cliente");
        return false;
    }

    if (colonia == "") {
        showDialog("Ingrese la colonia de la dirección del cliente");
        return false;
    }

    return true;
}

function GuardarCliente() {
    var parameters = getClienteParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "../configuraciones/DetalleCliente.aspx/GuardarCliente";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;
            showDialog(data.Message);
            if (data.Ret) {
                window.location.replace("../configuraciones/Cliente.aspx");
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function GuardarDomicilio() {
    var parameters = getDomicilioParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleCliente.aspx/GuardarDomicilio";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;

            if (data.Result != true) {
                showDialog(data.Message);
            } else {
                var info = JSON.parse(data.Ret);
                $('[data-id=lblCalle]').text(info[0].calle);
                $("#requeridoCalle").attr('class', 'fa fa-check');
                $('[data-id=lblNoExt]').text(info[0].numeroExterno);
                $("#requeridoNumExt").attr('class', 'fa fa-check');
                $('[data-id=lblNoInt]').text(info[0].numeroInterno);
                $('[data-id=lblColonia]').text(info[0].colonia);
                $("#requeridoColonia").attr('class', 'fa fa-check');
                $('[data-id=lblCalles]').text(info[0].entreCalles);
                $('[data-id=lblCP]').text(info[0].cp);
                $('[data-id=lblPais]').text(info[0].pais);
                $('[data-id=lblEstado]').text(info[0].estado);
                $('[data-id=lblMunicipio]').text(info[0].municipio);

                showDialog(data.Message);
                $('#tabsEmpresa a[href="#tab3"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function cargarEstados(pais) {
    var dataj = "{paisId: '" + pais + "'}";
    var url = "../configuraciones/DetalleCliente.aspx/CargarEstados";

    $.ajax({
        type: "POST",
        url: url,
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (ret) {
            data = ret.d;

            if (data.Result != true) {
                showDialog(data.Message);
            } else {
                var obj = JSON.parse(data.Ret);

                $("[data-id=cbxEstado]").empty().append($.map(obj, function (o) {
                    return $('<option/>', {
                        value: o.EstadoId,
                        text: o.Estado
                    });
                }));
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}