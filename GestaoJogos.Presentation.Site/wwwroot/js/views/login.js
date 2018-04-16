$(document).ready(function () {
    $("#txtEmail").focus();

    $("#btnLogar").click(function () {
        Post.Logar();
    });
});

var Post = {
    Logar: function() {
        var valor = { "Email": $("#txtEmail").val(), "Senha": $("#txtSenha").val() };

        var sucesso = function () {
            window.location.href = webroot + "home";
        }

        RequestAjax("Login", "POST", "Logar", valor, sucesso);
    }
}