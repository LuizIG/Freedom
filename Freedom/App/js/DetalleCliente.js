$(function () {
    $(window).load(function () {
        cargarEstados(1);
    });

    var editar = $("#txtEditarCliente").val();
    var validacionesTabs = true;

    if (editar == "True") {
        validacionesTabs = false;
    } else {
        validacionesTabs = true;
        //validacionesTabs = false;
    }
    
    $('#tabsCliente a[href="#tab1"]').tab('show');

    $('#btnTriggerAgregaContacto').click(function (e) {
        if (validarContacto()) {
            $("#btnAgregarContacto").click();
            return true;
        }
        return false;
    });

    $('#btnGuardarInfo').click(function (e) {
        if (validarInfoClienteGeneral()) {
            GuardarCliente();
            return true;
        } else {
            return false;
        }
    });

    $('#btnGuardarDomicilio').click(function (e) {
        if (validarDomicilioClienteFiscal()) {
            GuardarDomicilio();
            return true;
        } else {
            return false;
        }
    });

    $('#btnGuardarPersonalizar').click(function (e) {
        GuardarPersonalizacion();
    });

    //$('#btnGuardarFormasPago').click(function (e) {
    //    GuardarFormasPago();
    //});

    $('#btnGuardarContactos').click(function (e) {
        GuardarContactos();
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

    if (validacionesTabs) {
        $('#tabDomicilio').click(function (e) {
            validarInfoClienteGeneral();
        });

        $('#tabPersonalizacion').click(function (e) {
            validarInfoClienteGeneral();
        });

        $('#tabFormasPago').click(function (e) {
            validarInfoClienteGeneral();
        });

        $('#tabContactos').click(function (e) {
            validarInfoClienteGeneral();
        });

        $('#tabCheck').click(function (e) {
            validarInfoClienteGeneral();
        });
    } else {
        $('#refDomicilio').attr('href', '#tab2');
        $('#refPersonalizacion').attr('href', '#tab3');
        $('#refContactos').attr('href', '#tab4');
        $('#refFormasPago').attr('href', '#tab5');
        $('#refCheck').attr('href', '#tab6');
    }
});

function UpdateResumen(contactos) {
    // I N F O  G E N E R A L
    var nombre = $("#txtNombre").val();
    var rfc = $("#txtRFC").val();
    var regFiscal = $("[data-id=cbxRegimenFiscal] option:selected").text();

    if (nombre != "") {
        $('[data-id=lblNombreEmpresa]').text(nombre);
        $("#requeridoNombre").attr('class', 'fa fa-check');
    }

    if (rfc != "") {
        $('[data-id=lblRFC]').text(rfc);
        $("#requeridoRFC").attr('class', 'fa fa-check');
    }

    if (regFiscal != "") {
        $('[data-id=lblRegimen]').text(regFiscal);
        $("#requeridoRegimen").attr('class', 'fa fa-check');
    }


    // D O M I C I L I O
    var calle = $("#txtCalle").val();
    var numExt = $("#txtNumExt").val();
    var numInt = $("#txtNumInt").val();
    var calles = $("#txtCalles").val();
    var colonia = $("#txtColonia").val();
    var cp = $("#txtCP").val();
    var municipio = $("#txtMunicipio").val();
    var estado = $("[data-id=cbxEstado] option:selected").text();
    var pais = $("[data-id=cbxPais] option:selected").text();
    //var esLugarEmision = $("[data-id=cbxEmision]").is(':checked');

    if (calle != "") {
        $('[data-id=lblCalle]').text(calle);
        $("#requeridoCalle").attr('class', 'fa fa-check');
    }

    if (numExt != "") {
        $('[data-id=lblNoExt]').text(numExt);
        $("#requeridoNumExt").attr('class', 'fa fa-check');
    }

    if (numInt != "") {
        $('[data-id=lblNoInt]').text(numInt);
    }

    if (calles != "") {
        $('[data-id=lblCalles]').text(calles);
    }

    if (cp != "") {
        $('[data-id=lblCP]').text(cp);
    }

    if (municipio != "") {
        $('[data-id=lblMunicipio]').text(municipio);
    }

    if (pais != "") {
        $('[data-id=lblPais]').text(pais);
    }

    if (estado != "") {
        $('[data-id=lblEstado]').text(estado);
    }

    if (colonia != "") {
        $('[data-id=lblColonia]').text(colonia);
        $("#requeridoColonia").attr('class', 'fa fa-check');
    }

    // P E R S O N A L I Z A C I O N
    var telefonosPer = $("#txtTelefonoPer").val();
    var correoPer = $("#txtCorreoPer").val();
    var diasCredito = $("#txtDiasCredito").val();

    if (telefonosPer != "") {
        $('[data-id=lblTelefono]').text(telefonosPer);
    }

    if (correoPer != "") {
        $('[data-id=lblCorreoElectronico]').text(correoPer);
    }

    if (diasCredito != "") {
        $('[data-id=lblDiasCredito]').text(diasCredito);
    }


    // C O N T A C T O S
    if (contactos != "") {
        $('[data-id=lblContactos]').html(contactos);
        $("#requeridoContactos").attr('class', 'fa fa-check');
    }
}

function getInfoClienteParams() {
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
    item["ParamName"] = "RegimenFiscalId";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = options;
    retValue.push(item);

    var regFiscal = $("[data-id=cbxRegimenFiscal] option:selected").text();
    item = {};
    item["ParamName"] = "RegimenFiscal";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = regFiscal;
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function getDomicilioClienteParams() {
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

    var estadoId = $("[data-id=cbxEstado] option:selected").val();
    item = {};
    item["ParamName"] = "EstadoId";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = estadoId;
    retValue.push(item);

    var estado = $("[data-id=cbxEstado] option:selected").text();
    item = {};
    item["ParamName"] = "Estado";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = estado;
    retValue.push(item);

    var paisId = $("[data-id=cbxPais] option:selected").val();
    item = {};
    item["ParamName"] = "PaisId";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = paisId;
    retValue.push(item);

    var pais = $("[data-id=cbxPais] option:selected").text();
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

function getPersonalizarClienteParams() {
    var retValue = [];
    var item = {};

    item = {};
    item["ParamName"] = "TelefonoCliente";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtTelefonoPer").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "CorreoCliente";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCorreoPer").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "DiasCredito";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtDiasCredito").val();
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function validarInfoClienteGeneral() {
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
        if (rfc.length != 12 && rfc.length != 13) {
            showDialog("El RFC debe ser de al menos 12 carácteres");
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

function validarDomicilioClienteFiscal() {
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

function validarContacto() {
    var nombre = $("#txtNombreContacto").val();

    if (nombre == "") {
        showDialog("Es necesario ingresar el nombre del contacto");
        return false;
    }

    return true;
}

function GuardarCliente() {
    var parameters = getInfoClienteParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleCliente.aspx/GuardarCliente";

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

                $("#btnTriggerUpdate").click();
                $('[data-id=lblNombreEmpresa]').text(info.NombreEmpresa);
                $("#requeridoNombre").attr('class', 'fa fa-check');
                $('[data-id=lblRFC]').text(info.RFC);
                $("#requeridoRFC").attr('class', 'fa fa-check');
                $('[data-id=lblRegimen]').text(info.RegimenFiscal);
                $("#requeridoRegimen").attr('class', 'fa fa-check');
                $('[data-id=lblCURP]').text(info.CURP);

                showDialog(data.Message);
                $('#refDomicilio').attr('href', '#tab2');
                $('#refPersonalizacion').attr('href', '#tab3');
                $('#refContactos').attr('href', '#tab4');
                $('#refFormasPago').attr('href', '#tab5');
                $('#refCheck').attr('href', '#tab6');
                $('#tabsEmpresa a[href="#tab2"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function GuardarDomicilio() {
    var parameters = getDomicilioClienteParams();
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
                $('[data-id=lblCalle]').text(info[0].Calle);
                $("#requeridoCalle").attr('class', 'fa fa-check');
                $('[data-id=lblNoExt]').text(info[0].NumeroExterno);
                $("#requeridoNumExt").attr('class', 'fa fa-check');
                $('[data-id=lblNoInt]').text(info[0].NumeroInterno);
                $('[data-id=lblColonia]').text(info[0].Colonia);
                $("#requeridoColonia").attr('class', 'fa fa-check');
                //$('[data-id=lblCalles]').text(info[0].entreCalles);
                $('[data-id=lblCP]').text(info[0].CP);
                $('[data-id=lblMunicipio]').text(info[0].Municipio);
                $('[data-id=lblPais]').text(info[0].Pais);
                $('[data-id=lblEstado]').text(info[0].Estado);
                

                showDialog(data.Message);
                $('#tabsCliente a[href="#tab3"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function GuardarContactos() {
    var dataj = "{}";
    var url = "DetalleCliente.aspx/GuardarContactos";

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
                var info = data.Ret;

                $('[data-id=lblContactos]').html(info);
                $("#requeridoContactos").attr('class', 'fa fa-check');

                showDialog(data.Message);
                $('#tabsCliente a[href="#tab6"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function GuardarPersonalizacion() {
    var parameters = getPersonalizarClienteParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleCliente.aspx/GuardarPersonalizacion";
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

                $('[data-id=lblTelefono]').text(info.Telefono);
                $('[data-id=lblCorreoElectronico]').text(info.CorreoElectronico);
                $('[data-id=lblDiasCredito]').text(info.DiasCredito);

                showDialog(data.Message);
                $('#tabsCliente a[href="#tab4"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function eliminarContacto() {
    $("#btnEliminarContacto").click();
}

function cargarEstados(pais) {
    var dataj = "{paisId: '" + pais + "'}";
    var url = "DetalleCliente.aspx/CargarEstados";

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