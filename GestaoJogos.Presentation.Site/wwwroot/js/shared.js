$(document).ready(function() {
    $(".button-collapse").sideNav();
});

$(document)
    .ajaxStart(function () {
        $("body").addClass("loading");
    })
    .ajaxStop(function () {
        $("body").removeClass("loading");
    });

var httpStatusCode = {
    Ok: 200,
    BadRequest: 400,
    Unauthorization: 401
};

function RequestAjax(controller, type, metodo, valor, sucesso, erro, async, timeout) {
    var error = function (e) {
        if (e.status === httpStatusCode.Unauthorization) {
            AlertToast("Sessão expirada");
            setTimeout(function () {
                window.location.replace("login");
            }, 2000);
            return;
        }

        if (e.status === httpStatusCode.BadRequest && e.responseJSON.ValidationErrors.length) {
            erro(e.responseJSON);
            return;
        }

        AlertToastArray(e.responseJSON.Messages);
        return;
    }

    $.ajax({
        url: webroot + controller + "/" + metodo,
        type: type,
        data: JSON.stringify(valor),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditional: true,
        async: async == null ? true : false,
        success: sucesso,
        error: error,
        timeout: timeout == null ? 300000 : timeout,
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + $.cookie("token"));
        }
    });
}

function AlertToastArray(arrayMsgs) {
    var htmlMsgs = "";

    $.each(arrayMsgs, function (i, item) {
        htmlMsgs += `<div>${item}</div>`;
    });

    AlertToast(htmlMsgs);
}

function AlertToast(msg) {

    var removeAll = function () {
        window.Materialize.Toast.removeAll();
    };

    removeAll();

    window.Materialize.toast($(`<span>${msg}</span>`)
        .add($("<button class=\"btn-flat toast-action toast-close\">SAIR</button>")),
        30000);

    $(".toast-close").click(function () {
        removeAll();
    });
}