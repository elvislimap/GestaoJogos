$(document).ready(function () {
    $(".modal").modal();

    Get.Emprestimos();

    $("#btnAbrirModalAddEmprestimo").click(function () {
        Get.DadosComplementares();
    });

    $("#btnAddEmprestimo").click(function () {
        Post.Adicionar();
    });
});

var Post = {
    Adicionar: function () {
        var valor = { "PessoaId": $("#cbxPessoa").val(), "JogoId": $("#cbxJogo").val() };

        var sucesso = function () {
            AlertToast("Empréstimo efetuado com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "emprestimo";
            }, 2000);
        }

        RequestAjax("Emprestimo", "POST", "Adicionar", valor, sucesso);
    }
}

var Get = {
    Emprestimos: function () {
        var sucesso = function (data) {
            Montar.TabelaEmprestimos(data.Return);
        };

        RequestAjax("Emprestimo", "GET", "ObterLista", null, sucesso);
    },
    DadosComplementares: function() {
        var sucesso = function (data) {
            Montar.FormEmprestimo(data.Return);
            $("#modalAddEmprestimo").modal("open");
        };

        RequestAjax("Emprestimo", "GET", "ObterDadosComplementares", null, sucesso);
    }
}

var Montar = {
    TabelaEmprestimos: function (lista) {
        var html = "";

        if (lista.length) {
            $.each(lista,
                function (i, item) {
                    html +=
                        "<tr>";
                    html += "   <td>" + item.EmprestimoId + "</td>";
                    html += "   <td>" + item.Pessoa.Nome + "</td>";
                    html += "   <td>" + item.Jogo.Nome + "</td>";
                    html += "   <td>" + FormatDateTime(item.DataHora) + "</td>";
                    html += "</tr>";
                });
        } else {
            html += "<tr>";
            html += "   <td colspan=\"4\" class=\"center\">Nenhum registro encontrado</td>";
            html += "</tr>";
        }

        $("#tblEmprestimos tbody").html(html);
        $(".tooltipped").tooltip();
    },
    FormEmprestimo: function (dados) {
        var html = "";
        html += "<form id=\"frmEmprestimo\">";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <select id=\"cbxPessoa\">";
        html += "               <option value=\"\" disabled selected>Informe um amigo</option>";

        $.each(dados.Pessoas, function(i, item) {
            html += "               <option value=\"" + item.PessoaId + "\">" + item.Nome + "</option>";
        });

        html += "            </select>";
        html += "            <label for=\"cbxPessoa\">Amigo</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <select id=\"cbxJogo\">";
        html += "               <option value=\"\" disabled selected>Informe um jogo</option>";

        $.each(dados.Jogos, function (i, item) {
            html += "               <option value=\"" + item.JogoId + "\">" + item.Nome + "</option>";
        });

        html += "            </select>";
        html += "            <label for=\"cbxJogo\">Jogo</label>";
        html += "        </div>";
        html += "    </div>";
        html += "</form>";

        $("#divFrmEmprestimo").html(html);
        $("select").material_select();
    }
}