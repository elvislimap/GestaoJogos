$(document).ready(function () {
    $(".modal").modal();

    Get.Jogos();

    $("#btnAbrirModalAddJogo").click(function () {
        Montar.FormJogo();

        $("#modalAddJogo").attr("rq", "add");
        $("#modalAddJogo").modal("open");
    });

    $("#btnAddJogo").click(function () {
        if ($("#modalAddJogo").attr("rq") === "add")
            Post.Adicionar();
        else
            Put.Atualizar();
    });
});

var Post = {
    Adicionar: function () {
        var valor = { "Nome": $("#txtNome").val() };

        var sucesso = function () {
            AlertToast("Jogo criado com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "jogo";
            }, 2000);
        }

        RequestAjax("Jogo", "POST", "Adicionar", valor, sucesso);
    }
}

var Get = {
    Jogos: function () {
        var sucesso = function (data) {
            Montar.TabelaJogos(data.Return);
        };

        RequestAjax("Jogo", "GET", "ObterLista", null, sucesso);
    },
    Jogo: function (jogoId) {
        var sucesso = function (data) {
            Montar.FormJogo(true, data.Return);
            $("#modalAddJogo").modal("open");
            $("#modalAddJogo").attr("rq", "upd");
        };

        RequestAjax("Jogo", "GET", "Obter", "jogoId=" + jogoId, sucesso);
    }
}

var Put = {
    Atualizar: function () {
        var valor = {
            "JogoId": $("#frmJogo").attr("jId"),
            "Nome": $("#txtNome").val(),
            "Excluido": $("#chkExcluido").is(":checked")
        };

        var sucesso = function () {
            AlertToast("Jogo atualizado com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "jogo";
            }, 2000);
        }

        RequestAjax("Jogo", "PUT", "Atualizar", valor, sucesso);
    }
}

var Montar = {
    TabelaJogos: function (lista) {
        var html = "";

        if (lista.length) {
            $.each(lista,
                function(i, item) {
                    html +=
                        "<tr class=\"tooltipped\" data-position=\"top\" data-tooltip=\"Clique para mais detalhes\">";
                    html += "   <td>" + item.JogoId + "</td>";
                    html += "   <td>" + item.Nome + "</td>";
                    html += "</tr>";
                });
        } else {
            html += "<tr>";
            html += "   <td colspan=\"2\" class=\"center\">Nenhum registro encontrado</td>";
            html += "</tr>";
        }

        $("#tblJogos tbody").html(html);
        $(".tooltipped").tooltip();

        $("#tblJogos tbody tr").click(function () {
            Get.Jogo($(this).find("td").first().html());
        });
    },
    FormJogo: function (exibeExcluir, dados) {
        var html = "";

        var jogoId = "";
        var nome = "";
        var active = "";

        if (dados != null) {
            jogoId = dados.JogoId;
            nome = dados.Nome;
            active = "class=\"active\"";
        }

        html += "<form id=\"frmJogo\" jId=\"" + jogoId + "\">";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtNome\" type=\"text\" value=\"" + nome + "\">";
        html += "            <label for=\"txtNome\" " + active + ">Nome</label>";
        html += "        </div>";
        html += "    </div>";
        
        if (exibeExcluir) {
            html += "    <div class=\"row\">";
            html += "        <div class=\"col s12\">";
            html += "            <input id=\"chkExcluido\" type=\"checkbox\">";
            html += "            <label for=\"chkExcluido\">Excluído</label>";
            html += "        </div>";
            html += "    </div>";
        }
        html += "</form>";

        $("#divFrmJogo").html(html);
    }
}