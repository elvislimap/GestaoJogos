$(document).ready(function() {
    Post.NovoUsuario();
});

var Post = {
    NovoUsuario: function() {
        $("#btnSalvar").click(function() {
            var valor = { "Nome": $("#txtNome").val(), "Email": $("#txtEmail").val(), "Senha": $("#txtSenha").val() };
            console.log(valor);
            var sucesso = function() {
                AlertToast("Usuário criado com sucesso. Em instantes você será redirecionado para a página de login.");

                setTimeout(function() {
                    window.location.href = "login";
                }, 3000);
            }

            PostAjax("Usuario", "Adicionar", valor, sucesso);
        });
    }
}