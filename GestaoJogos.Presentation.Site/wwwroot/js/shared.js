$(document).ready(function() {
    $(".button-collapse").sideNav();

    $("#btnLogOff").click(function() {
        var sucesso = function() {
            window.location.replace(webroot + "login");
        };
        RequestAjax("Login", "POST", "LogOut", null, sucesso);
    });

    $("#menu-amigos").click(function() {
        window.location.href = webroot + "amigo";
    });

    $("#menu-jogos").click(function () {
        window.location.href = webroot + "jogo";
    });

    $("#menu-emprestimos").click(function () {
        window.location.href = webroot + "emprestimo";
    });

    $("#menu-devolucoes").click(function () {
        window.location.href = webroot + "devolucao";
    });

    $("#menu-logoff").click(function () {
        var sucesso = function () {
            window.location.replace(webroot + "login");
        };
        RequestAjax("Login", "POST", "LogOut", null, sucesso);
    });
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
                window.location.replace(webroot + "login");
            }, 2000);
            return;
        }

        if (e.status === httpStatusCode.BadRequest && e.responseJSON.ValidationErrors.length) {
            if (erro != null) {
                erro(e.responseJSON);
                return;
            }
        }
        
        if (e.responseJSON.Messages.length)
            AlertToastArray(e.responseJSON.Messages);

        else if (e.responseJSON.ValidationErrors.length) {
            var msgs = [];
            $.each(e.responseJSON.ValidationErrors,
                function(i, item) {
                    msgs.push(item.Message);
                });

            AlertToastArray(msgs);
        }

        return;
    }

    var url = type === "GET"
        ? (webroot + controller + "/" + metodo + "?" + valor)
        : (webroot + controller + "/" + metodo);


    $.ajax({
        url: url,
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

function FormatDateTime(dateTime) {
    dateTime = dateTime.replace("T", " ");
    dateTime = dateTime.split(".")[0];
    var date = dateTime.split(" ")[0];
    var hour = dateTime.split(" ")[1];
    var splitDate = date.split("-");

    return splitDate[2] + "/" + splitDate[1] + "/" + splitDate[0] + " " + hour;
}