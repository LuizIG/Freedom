$(function () {
    $(window).load(function () {
        cargarEstados(1);
        cargarEstadosEmision(1);
    });



    var editar = $("#txtEditarEmpresa").val();
    var validacionesTabs = true;

    if (editar == "True") {
        validacionesTabs = false;
    } else {
        validacionesTabs = true;
    }

    $('#lugarEmisionPart').hide();
    $('#resumenLugarEmision').hide();
    $("#domicilioFiscalPart").attr('class', 'col-md-6 col-md-offset-3');
    $('#tabsEmpresa a[href="#tab1"]').tab('show'); 

    $('#cbxEmision').change(function () {
        if (this.checked) {
            $("#domicilioFiscalPart").attr('class', 'col-md-6 col-md-offset-3');
            $('#btnGuardarDomicilio').show();
            $('#btnAnteriorTab2A').show();
            $('#lugarEmisionPart').fadeOut('fast');
            $('#resumenLugarEmision').hide();
        } 
        else {
            $("#domicilioFiscalPart").attr('class', 'col-md-6');
            $('#lugarEmisionPart').fadeIn('fast');
            $('#btnGuardarDomicilio').hide();
            $('#btnAnteriorTab2A').hide();
            $('#resumenLugarEmision').show();
        } 
    });

    $('#btnGuardarInfo').click(function (e) {
        if (validarInfoGeneral()) {
            GuardarEmpresa();
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

    $('#btnGuardarLugarEmision').click(function (e) {
        if (validarDomicilioFiscal()) {
            if (validarLugarEmision()) {
                GuardarDomicilio();
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    });

    $('#btnTriggerAgregaContacto').click(function (e) {
        console.log("in");
        if (validarContacto()) {
            $("#btnAgregarContacto").click();
            return true;
        }
        return false;
    });

    $('#btnGuardarPersonalizar').click(function (e) {
        GuardarPersonalizacion();
    });

    $('#btnGuardarCertificados').click(function (e) {
        GuardarCertificados();
    });

    $('#btnGuardarContactos').click(function (e) {
        GuardarContactos();
    });

    $('#btnGuardarImpuestos').click(function (e) {
        GuardarImpuestos();
    });

    $('#btnFinalizar').click(function (e) {
        window.location.replace("Empresas.aspx");
    });


    $('#btnAnteriorTab2A').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab1"]').tab('show');
    });

    $('#btnAnteriorTab2B').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab1"]').tab('show');
    });

    $('#btnAnteriorTab3').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab2"]').tab('show');
    });

    $('#btnAnteriorTab4').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab3"]').tab('show');
    });

    $('#btnAnteriorTab5').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab4"]').tab('show');
    });

    $('#btnAnteriorTab6').click(function (e) {
        e.preventDefault();
        $('#tabsEmpresa a[href="#tab5"]').tab('show');
    });

    //$('#btnAnteriorTab7').click(function (e) {
    //    e.preventDefault();
    //    $('#tabsEmpresa a[href="#tab6"]').tab('show');
    //});

    if (validacionesTabs) {
        $('#tabDomicilio').click(function (e) {
            validarInfoGeneral();
        });

        $('#tabPersonalizacion').click(function (e) {
            validarInfoGeneral();
        });

        $('#tabCertificados').click(function (e) {
            validarInfoGeneral();
        });

        $('#tabContactos').click(function (e) {
            validarInfoGeneral();
        });

        //$('#tabImpuestos').click(function (e) {
        //    validarInfoGeneral();
        //});

        $('#tabCheck').click(function (e) {
            validarInfoGeneral();
        });
    } else {
        $('#refDomicilio').attr('href', '#tab2');
        $('#refPersonalizacion').attr('href', '#tab3');
        $('#refCertificados').attr('href', '#tab4');
        $('#refContactos').attr('href', '#tab5');
        //$('#refImpuestos').attr('href', '#tab6');
        $('#refCheck').attr('href', '#tab6');
    }
    
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

    item = {};
    item["ParamName"] = "CURP";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCURP").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Activo";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("[data-id=cbx_active]").is(':checked');
    retValue.push(item);

    item = {};
    item["ParamName"] = "Predeterminado";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("[data-id=cbx_default]").is(':checked');
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

    var esLugarEmision = $("[data-id=cbxEmision]").is(':checked');
    item = {};
    item["ParamName"] = "LugarEmision";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = esLugarEmision;
    retValue.push(item);

    if (!esLugarEmision) {
        item = {};
        item["ParamName"] = "CalleEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtCalleEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "NumExtEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtNumExtEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "NumIntEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtNumIntEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "CallesEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtCallesEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "ColoniaEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtColoniaEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "CPEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtCPEmision").val();
        retValue.push(item);

        item = {};
        item["ParamName"] = "MunicipioEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = $("#txtMunicipioEmision").val();
        retValue.push(item);

        var estado = $("[data-id=cbxEstadoEmision] option:selected").val();
        item = {};
        item["ParamName"] = "EstadoEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = estado;
        retValue.push(item);

        var pais = $("[data-id=cbxPaisEmision] option:selected").val();
        item = {};
        item["ParamName"] = "PaisEmision";
        item["ParamType"] = "NVARCHAR";
        item["ParamValue"] = pais;
        retValue.push(item);
    }

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function validarInfoGeneral() {
    var nombre = $("#txtNombre").val();
    var rfc = $("#txtRFC").val();
    var curp = $("#txtCURP").val();
    var regimenFiscal = $("[data-id=cbxRegimenFiscal] option:selected").val();

    if (nombre == "") {
        showDialog("Ingrese el nombre de la empresa");
        return false;
    }

    if (rfc == "") {
        showDialog("Ingrese el RFC de la empresa");
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

    if (curp != "") {
        if (curp.length != 18) {
            showDialog("El CURP debe ser de 18 carácteres");
            return false;
        } else {
            if (!validarCURP(curp)) {
                showDialog("El CURP tiene un formato incorrecto");
                return false;
            }
        }
    }

    if (regimenFiscal == "") {
        showDialog("Seleccione el régimen fiscal de la empresa");
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
        showDialog("Ingrese la calle de la dirección de la empresa");
        return false;
    }

    if (numExt == "") {
        showDialog("Ingrese el número exterior de la dirección de la empresa");
        return false;
    }

    if (calles == "") {
        showDialog("Indique entre que calles se encuentra la dirección de la empresa");
        return false;
    }

    if (colonia == "") {
        showDialog("Ingrese la colonia de la dirección de la empresa");
        return false;
    }

    return true;
}

function validarLugarEmision() {
    var calle = $("#txtCalleEmision").val();
    var numExt = $("#txtNumExtEmision").val();
    var calles = $("#txtCallesEmision").val();
    var colonia = $("#txtColoniaEmision").val();

    if (calle == "") {
        showDialog("Ingrese la calle del lugar de emision de la empresa");
        return false;
    }

    if (numExt == "") {
        showDialog("Ingrese el número exterior del lugar de emision de la empresa");
        return false;
    }

    if (calles == "") {
        showDialog("Indique entre que calles se encuentra el lugar de emision de la empresa");
        return false;
    }

    if (colonia == "") {
        showDialog("Ingrese la colonia del lugar de emision de la empresa");
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

function GuardarEmpresa() {
    var parameters = getInfoParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleEmpresa.aspx/GuardarEmpresa";

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
                $('[name=lblEmpresa]').text(info.NombreEmpresa);
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
                $('#refCertificados').attr('href', '#tab4');
                $('#refContactos').attr('href', '#tab5');
                //$('#refImpuestos').attr('href', '#tab6');
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
    var parameters = getDomicilioParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleEmpresa.aspx/GuardarDomicilio";

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

                if (info.length == 2) {
                    $('[data-id=lblCalleEmision]').text(info[1].calle);
                    $("#requeridoCalleEmision").attr('class', 'fa fa-check');
                    $('[data-id=lblNumExtEmision]').text(info[1].numeroExterno);
                    $("#requeridoNumExtEmision").attr('class', 'fa fa-check');
                    $('[data-id=lblNumIntEmision]').text(info[1].numeroInterno);
                    $('[data-id=lblColoniaEmision]').text(info[1].colonia);
                    $("#requeridoColoniaEmision").attr('class', 'fa fa-check');
                    $('[data-id=lblCallesEmision]').text(info[1].entreCalles);
                    $('[data-id=lblCPEmision]').text(info[1].cp);
                    $('[data-id=lblPaisEmision]').text(info[1].pais);
                    $('[data-id=lblEstadoEmision]').text(info[1].estado);
                    $('[data-id=lblMunicipioEmision]').text(info[1].municipio);
                }

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
    var url = "DetalleEmpresa.aspx/CargarEstados";

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

function cargarEstadosEmision(pais) {
    var dataj = "{paisId: '" + pais + "'}";
    var url = "DetalleEmpresa.aspx/CargarEstados";

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

                $("[data-id=cbxEstadoEmision]").empty().append($.map(obj, function (o) {
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

function GuardarContactos() {
    var dataj = "{}";
    var url = "DetalleEmpresa.aspx/GuardarContactos";

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
                $('#tabsEmpresa a[href="#tab6"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function GuardarImpuestos() {
    var retValue = []; 
    var selected = [];
    var impuestos = [];
    var item = {};

    $('#tblImpuestos input[type="checkbox"]').each(function () {
        if ($(this).prop('checked') == true) {
            var trow = $(this).parents('tr');
            var id = trow.find('input[name="lblTipoImpuestoId"]').val();
            var impuesto = trow.find('input[name="lblTipoImpuesto"]').val();
            selected.push(id);
            impuestos.push(impuesto);
        }
    });

    item["ParamName"] = "ImpuestoId";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = selected;
    retValue.push(item);

    item = {};
    item["ParamName"] = "Impuesto";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = impuestos;
    retValue.push(item);

    item = {};
    var tipoComprobanteId = $("[data-id=cbxComprobante] option:selected").val();
    item["ParamName"] = "TipoComprobanteId";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = tipoComprobanteId;
    retValue.push(item);

    item = {};
    var tipoComprobante = $("[data-id=cbxComprobante] option:selected").text();
    item["ParamName"] = "TipoComprobante";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = tipoComprobante;
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    var parameters = retValueJson;
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleEmpresa.aspx/GuardarImpuestos";

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

                var impuestos = "";
                info.forEach(function (item) {
                    impuestos += item.TipoImpuesto + "<br/>";
                });

                console.log(impuestos);

                $('[data-id=lblComprobante]').text(info[0].TipoComprobante);
                $("#requeridoComprobante").attr('class', 'fa fa-check');
                $('[data-id=lblImpuestos]').html(impuestos);
                $("#requeridoImpuestos").attr('class', 'fa fa-check');

                showDialog(data.Message);
                $('#tabsEmpresa a[href="#tab7"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

function showBrowseDialog() {
    $("#fuSelloDigital").click();
}

function uploadCertificado() {
    var file = $('#fuSelloDigital')[0].files[0];
    $("#txtSelloDigital").val(file.name);
}

function showFileDialog() {
    $("#fuClavePrivada").click();
}

function uploadLlave() {
    var file = $('#fuClavePrivada')[0].files[0];
    $("#txtClavePrivada").val(file.name);
}

function GuardarCertificados() {
    var parameters = getCertificadosParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleEmpresa.aspx/GuardarCertificados";
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
                var llavePrivada = "No";
                var llavePublica = "No";
                var certificado = "No";

                if (info.llavePrivada != "") { llavePrivada = "Si"; }
                if (info.llavePublica != "") { llavePublica = "Si"; }
                if (info.certificado != "") { certificado = "Si"; }

                $('[data-id=lblClavePrivada]').text(llavePrivada);
                $("#requeridoClavePrivada").attr('class', 'fa fa-check');
                $('[data-id=lblContraseñaLlavePrivada]').text(llavePublica);
                $("#requeridoContraseñaLlavePrivada").attr('class', 'fa fa-check');
                $('[data-id=lblSelloDigital]').text(certificado);
                $("#requeridoSelloDigital").attr('class', 'fa fa-check');

                showDialog(data.Message);
                $('#tabsEmpresa a[href="#tab5"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}

var selectKey = function (event) {
    uploadLlave();
    var input = event.target;

    var reader = new FileReader();
    reader.onload = function () {
        var binaryString = reader.result;
        var encryptedFile = arrayBufferToBase64(binaryString);
        $("#binaryKey").val(encryptedFile);
    };
    reader.readAsArrayBuffer(input.files[0]);
};

var selectCert = function (event) {
    uploadCertificado();
    var input = event.target;

    var reader = new FileReader();
    reader.onload = function () {
        var binaryString = reader.result;
        var encryptedFile = arrayBufferToBase64(binaryString);
        $("#binaryCert").val(encryptedFile);
    };
    reader.readAsArrayBuffer(input.files[0]);
};

function getCertificadosParams() {
    var llavePrivada = $('#fuClavePrivada')[0].files[0];
    var selloDigital = $('#fuSelloDigital')[0].files[0];
    var retValue = [];
    var item = {};

    item["ParamName"] = "LlavePublica";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtPassClavePrivada").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "SelloDigital";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#binaryCert").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "LlavePrivada";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#binaryKey").val();
    retValue.push(item);

    $("#binaryKey").val("");
    $("#binaryCert").val("");

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}


function showLogoFileDialog() {
    $("#fuLogo").click();
}

function uploadLogo() {
    var file = $('#fuLogo')[0].files[0];
    $("#txtLogo").val(file.name);
}

var selectLogo = function (event) {
    uploadLogo();
    var input = event.target;

    var reader = new FileReader();
    reader.onload = function () {
        var binaryString = reader.result;
        var encryptedFile = arrayBufferToBase64(binaryString);
        $("#binaryLogo").val(encryptedFile);
    };
    reader.readAsArrayBuffer(input.files[0]);
};

function getPersonalizarParams() {
    var llavePrivada = $('#fuLogo')[0].files[0];
    var retValue = [];
    var item = {};

    item["ParamName"] = "NombreComercial";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtNombreComercial").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Logo";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#binaryLogo").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "MensajeFactura";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtMensaje").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "TelefonoFactura";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtTelefonos").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "CorreoFactura";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtCorreo").val();
    retValue.push(item);


    $("#binaryLogo").val("");

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}

function GuardarPersonalizacion() {
    var parameters = getPersonalizarParams();
    var dataj = "{value: '" + parameters + "'}";
    var url = "DetalleEmpresa.aspx/GuardarPersonalizacion";
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
                $('[data-id=lblNombreComercial]').text(info.nombreComercial);
                $("#requeridoNombreComercial").attr('class', 'fa fa-check');
                $('[data-id=lblLogotipo]').text(info.logo);
                $('[data-id=lblMensaje]').text(info.mensajeFactura);
                $("#requeridoMensaje").attr('class', 'fa fa-check');
                $('[data-id=lblTelefonos]').text(info.telefonoFactura);
                $('[data-id=lblCorreoFactura]').text(info.correoFactura);

                showDialog(data.Message);
                $('#tabsEmpresa a[href="#tab4"]').tab('show');
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
}