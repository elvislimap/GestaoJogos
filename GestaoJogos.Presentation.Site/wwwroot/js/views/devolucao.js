$(document).ready(function () {
    $(".modal").modal();

    Get.Devolucoes();

    $("#btnAbrirModalAddDevolucao").click(function () {
        Get.Emprestimos();
    });

    $("#btnAddDevolucao").click(function () {
        Post.Adicionar();
    });
});

var Post = {
    Adicionar: function () {
        var valor = { "EmprestimoId": $("#cbxEmprestimo").val(), "Avaliacao": $("#cbxAvaliacao").val() };

        var sucesso = function () {
            AlertToast("Devolução efetuada com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "devolucao";
            }, 2000);
        }

        RequestAjax("Devolucao", "POST", "Adicionar", valor, sucesso);
    }
}

var Get = {
    Devolucoes: function () {
        var sucesso = function (data) {
            Montar.TabelaDevolucoes(data.Return);
        };

        RequestAjax("Devolucao", "GET", "ObterLista", null, sucesso);
    },
    Emprestimos: function () {
        var sucesso = function (data) {
            Montar.FormDevolucao(data.Return);
            $("#modalAddDevolucao").modal("open");
        };

        RequestAjax("Devolucao", "GET", "ObterEmprestimos", null, sucesso);
    }
}

var Montar = {
    TabelaDevolucoes: function (lista) {
        var html = "";
        console.log(lista);
        if (lista.length) {
            $.each(lista,
                function (i, item) {
                    html += "<tr>";
                    html += "   <td>" + item.DevolucaoId + "</td>";
                    html += "   <td>" + item.Emprestimo.Pessoa.Nome + "</td>";
                    html += "   <td>" + item.Emprestimo.Jogo.Nome + "</td>";
                    html += "   <td>" + item.Avaliacao + "</td>";
                    html += "   <td>" + FormatDateTime(item.DataHora) + "</td>";
                    html += "</tr>";
                });
        } else {
            html += "<tr>";
            html += "   <td colspan=\"5\" class=\"center\">Nenhum registro encontrado</td>";
            html += "</tr>";
        }

        $("#tblDevolucoes tbody").html(html);
        $(".tooltipped").tooltip();
    },
    FormDevolucao: function (dados) {
        var html = "";
        html += "<form id=\"frmDevolucao\">";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <select id=\"cbxEmprestimo\">";
        html += "               <option value=\"\" disabled selected>Informe o empréstimo</option>";
        
        $.each(dados, function (i, item) {
            html += "               <option value=\"" + item.EmprestimoId + "\">" + item.Pessoa.Nome + " - " + item.Jogo.Nome + " - " + FormatDateTime(item.DataHora) + "</option>";
        });

        html += "            </select>";
        html += "            <label for=\"cbxEmprestimo\">Empréstimo</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <select id=\"cbxAvaliacao\">";
        html += "               <option value=\"\" disabled selected>Selecione</option>";

        for (var j = 0; j <= 5; j++) {
            html += "               <option value=\"" + j + "\">" + j + "</option>";
        }

        html += "            </select>";
        html += "            <label for=\"cbxAvaliacao\">Responsabilidade do amigo</label>";
        html += "        </div>";
        html += "    </div>";
        html += "</form>";

        $("#divFrmDevolucao").html(html);
        $("select").material_select();
    }
}