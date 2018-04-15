$(document).ready(function () {
    Post.Logar();
});

var Post = {
    Logar: function() {
        $("#btnLogar").click(function() {
            var valor = { "Email": $("#txtEmail").val(), "Senha": $("#txtSenha").val() };

            var sucesso = function () {
                window.location.href = webroot + "home";
            }

            RequestAjax("Login", "POST", "Logar", valor, sucesso);
        });
    }
}