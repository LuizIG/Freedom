$(function () {

    $("#btnLogin").click(function (e) {
        if (validaEntrar()) {
            Login();
            return true;
        }
        return false;
    });

    $("#btnRegistrarse").click(function (e) {
        if (validaRegistro()) {
            Registro();
            return true;
        }
        return false;
    });
});

function getParams() {
    var retValue = [];
    var item = {};
    item["ParamName"] = "Usuario";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtUsername").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Contrasena";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtPassword").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "EsPersistente";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("[data-id=chkboxPersist]").is(':checked');
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}


function Login() {
    var params = getParams();
    var url = "Login.aspx/LogIn";
    var dataj = "{value: '" + params + "'}";

    $.ajax({
        url: url,
        type: "POST",
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {

            data = data.d;
            if (data.Result != true) {
                showDialog(data.Message);
            } else {
                window.location.replace(data.Ret);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            console.log("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
    return false;
};

function validaEntrar() {
    var usuario = $("#txtUsername").val();
    var pass = $("#txtPassword").val();
    if (usuario == "" || pass == "") {
        showDialog("Favor de capturar usuario y contraseña");
        return false;
    }
    return true;
}

function validaRegistro() {
    var nombre = $("#txtNombre").val();
    var apellidoPaterno = $("#txtApellidoPaterno").val();
    var correo = $("#txtEmail").val();
    var telefono = $("#txtTelefono").val();
    var pass = $("#txtPass").val();
    var confirmPass = $("#txtConfirmarPass").val();

    if (nombre == "") {
        showDialog("Es necesario ingresar tu nombre");
        return false;
    }

    if (apellidoPaterno == "") {
        showDialog("Es necesario ingresar tu apellido paterno");
        return false;
    }

    if (correo == "") {
        showDialog("Es necesario ingresar tu correo personal");
        return false;
    }else if (!validaEmail(correo)) {
        showDialog("El correo ingresado tiene un formato incorrecto");
        return false;
    }

    if (telefono == "") {
        showDialog("Es necesario ingresar un número telefónico");
        return false;
    } else if (telefono.length != 10) {
        showDialog("El número telefónico debe contener 10 dígitos");
        return false;
    } 

    if (pass == "") {
        showDialog("Es necesario ingresar una contraseña");
        return false;
    } else if (pass.length < 6) {
        showDialog("La contraseña debe contener al menos 6 carácteres");
        return false;
    } 

    if (confirmPass == "") {
        showDialog("Es necesario confirmar la contraseña");
        return false;
    } else if (pass !== confirmPass) {
        showDialog("Las contraseñas con coinciden");
        return false;
    }
    
    return true;
}

function getRegistroParams() {
    var retValue = [];
    var item = {};
    item["ParamName"] = "Nombre";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtNombre").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "ApellidoPaterno";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtApellidoPaterno").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "ApellidoMaterno";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtApellidoMaterno").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Correo";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtEmail").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Telefono";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtTelefono").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "Pass";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtPass").val();
    retValue.push(item);

    item = {};
    item["ParamName"] = "ConfirmarPass";
    item["ParamType"] = "NVARCHAR";
    item["ParamValue"] = $("#txtConfirmarPass").val();
    retValue.push(item);

    var retValueJson = "";
    if (retValue.length != 0) {
        retValueJson = JSON.stringify(retValue);
    }

    return retValueJson;
}


function Registro() {
    var params = getRegistroParams();
    var url = "Login.aspx/Registro";
    var dataj = "{value: '" + params + "'}";

    $.ajax({
        url: url,
        type: "POST",
        data: dataj,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        success: function (data) {
            data = data.d;
            if (data.Result != true) {
                showDialog(data.Message);
            } else {
                window.location.replace(data.Ret);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            showDialog("Error " + url + ": " + textStatus + ' [' + xmlHttpRequest.responseText + '] ' + errorThrown, ' -- ');
        }
    });
    return false;
};