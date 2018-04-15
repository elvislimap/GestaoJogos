$(document).ready(function() {
    $("#txtNome").focus();
    Post.NovoUsuario();
});

var Post = {
    NovoUsuario: function() {
        $("#btnSalvar").click(function() {
            var valor = { "Nome": $("#txtNome").val(), "Email": $("#txtEmail").val(), "Senha": $("#txtSenha").val() };
            
            var sucesso = function() {
                AlertToast("Usuário criado com sucesso. Em instantes você será redirecionado para a página de login.");

                setTimeout(function() {
                    window.location.href = webroot + "login";
                }, 3000);
            }

            var erro = function(e) {
                if (e.ValidationErrors.length) {
                    Form.Validate(e.ValidationErrors);
                }
            }

            RequestAjax("Usuario", "POST", "Adicionar", valor, sucesso, erro);
        });
    }
}

var Form = {
    Validate: function (arrayErrors) {
        var nomeIsValid = true;
        var emailIsValid = true;
        var senhaIsValid = true;

        $.each(arrayErrors,
            function(i, item) {
                if (item.Campo === "Nome") {
                    nomeIsValid = false;
                    $("#valid-nome").html(item.Message).addClass("is-invalid");
                }
                if (item.Campo === "Email") {
                    emailIsValid = false;
                    $("#valid-email").html(item.Message).addClass("is-invalid");
                }
                if (item.Campo === "Senha") {
                    senhaIsValid = false;
                    $("#valid-senha").html(item.Message).addClass("is-invalid");
                }
            });

        if (nomeIsValid)
            $("#valid-nome").html("").removeClass("is-invalid");
        if (emailIsValid)
            $("#valid-email").html("").removeClass("is-invalid");
        if (senhaIsValid)
            $("#valid-senha").html("").removeClass("is-invalid");
    }
}