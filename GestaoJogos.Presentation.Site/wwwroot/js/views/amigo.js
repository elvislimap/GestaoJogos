$(document).ready(function() {
    $(".modal").modal();
    $(".tabs").tabs();

    Get.Amigos();

    $("#btnAbrirModalAddAmigo").click(function() {
        Montar.FormDadosPessoais();
        Montar.FormEndereco();

        $("#modalAddAmigo").attr("rq", "add");
        $("#modalAddAmigo").attr("peId", "");
        $("#modalAddAmigo").modal("open");
    });

    $("#btnAddAmigo").click(function() {
        if ($("#modalAddAmigo").attr("rq") === "add")
            Post.Adicionar();
        else
            Put.Atualizar();
    });
});

var Post = {
    Adicionar: function() {
        var valor = {
            "Pessoa": {
                "Nome": $("#txtNome").val(),
                "Sobrenome": $("#txtSobrenome").val(),
                "Cpf": $("#txtCpf").val(),
                "Telefone": $("#txtTelefone").val(),
                "Email": $("#txtEmail").val()
            },
            "Endereco": {
                "Logradouro": $("#txtLogradouro").val(),
                "Numero": $("#txtNumero").val(),
                "Bairro": $("#txtBairro").val(),
                "Municipio": $("#txtMunicipio").val(),
                "Uf": $("#txtUf").val(),
                "Cep": $("#txtCep").val()
            }
        };

        var sucesso = function () {
            AlertToast("Amigo criado com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "amigo";
            }, 2000);
        }

        RequestAjax("Amigo", "POST", "Adicionar", valor, sucesso);
    }
}

var Get = {
    Amigos: function () {
        var sucesso = function (data) {
            Montar.TabelaAmigos(data.Return);
        };

        RequestAjax("Amigo", "GET", "ObterLista", null, sucesso);
    },
    Amigo: function(pessoaId) {
        var sucesso = function (data) {
            Montar.FormDadosPessoais(true, data.Return.Pessoa);
            Montar.FormEndereco(data.Return.Endereco);
            $("#modalAddAmigo").modal("open");
            $("#modalAddAmigo").attr("rq", "upd");
            $("#modalAddAmigo").attr("peId", data.Return.PessoaEnderecoId);
        };

        RequestAjax("Amigo", "GET", "Obter", "pessoaId=" + pessoaId, sucesso);
    }
}

var Put = {
    Atualizar: function() {
        var valor = {
            "Pessoa": {
                "PessoaId": $("#frmDadosPessoais").attr("pId"),
                "Nome": $("#txtNome").val(),
                "Sobrenome": $("#txtSobrenome").val(),
                "Cpf": $("#txtCpf").val(),
                "Telefone": $("#txtTelefone").val(),
                "Email": $("#txtEmail").val(),
                "Excluido": $("#chkExcluido").is(":checked")
            },
            "Endereco": {
                "Logradouro": $("#txtLogradouro").val(),
                "Numero": $("#txtNumero").val(),
                "Bairro": $("#txtBairro").val(),
                "Municipio": $("#txtMunicipio").val(),
                "Uf": $("#txtUf").val(),
                "Cep": $("#txtCep").val()
            },
            "PessoaEnderecoId": $("#modalAddAmigo").attr("peId")
        };

        var sucesso = function () {
            AlertToast("Amigo atualizado com sucesso");

            setTimeout(function () {
                window.location.href = webroot + "amigo";
            }, 2000);
        }

        RequestAjax("Amigo", "PUT", "Atualizar", valor, sucesso);
    }
}

var Montar = {
    TabelaAmigos: function(lista) {
        var html = "";

        if (lista.length) {
            $.each(lista,
                function(i, item) {
                    html +=
                        "<tr class=\"tooltipped\" data-position=\"top\" data-tooltip=\"Clique para mais detalhes\">";
                    html += "   <td>" + item.PessoaId + "</td>";
                    html += "   <td>" + item.Nome + "</td>";
                    html += "   <td>" + item.Email + "</td>";
                    html += "</tr>";
                });

        } else {
            html += "<tr>";
            html += "   <td colspan=\"3\" class=\"center\">Nenhum registro encontrado</td>";
            html += "</tr>";
        }

        $("#tblAmigos tbody").html(html);
        $(".tooltipped").tooltip();

        $("#tblAmigos tbody tr").click(function () {
            Get.Amigo($(this).find("td").first().html());
        });
    },
    FormDadosPessoais: function(exibeExcluir, dados) {
        var html = "";
        
        var pessoaId = "";
        var nome = "";
        var sobrenome = "";
        var cpf = "";
        var telefone = "";
        var email = "";
        var active = "";

        if (dados != null) {
            pessoaId = dados.PessoaId;
            nome = dados.Nome;
            sobrenome = dados.Sobrenome;
            cpf = dados.Cpf;
            telefone = dados.Telefone;
            email = dados.Email;
            active = "class=\"active\"";
        }

        html += "<form id=\"frmDadosPessoais\" pId=\"" + pessoaId + "\">";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtNome\" type=\"text\" value=\"" + nome + "\">";
        html += "            <label for=\"txtNome\" " + active + ">Nome</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtSobrenome\" type=\"text\" value=\"" + sobrenome + "\">";
        html += "            <label for=\"txtSobrenome\" " + active + ">Sobrenome</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtCpf\" type=\"text\" value=\"" + cpf + "\">";
        html += "            <label for=\"txtCpf\" " + active + ">CPF</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtTelefone\" type=\"text\" value=\"" + telefone + "\">";
        html += "            <label for=\"txtTelefone\" " + active + ">Telefone</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtEmail\" type=\"text\" value=\"" + email + "\">";
        html += "            <label for=\"txtEmail\" " + active + ">Email</label>";
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

        $("#divDadosPessoais").html(html);
    },
    FormEndereco: function (dados) {
        var html = "";
        
        var enderecoId = "";
        var uf = "";
        var municipio = "";
        var logradouro = "";
        var numero = "";
        var bairro = "";
        var cep = "";
        var active = "";

        if (dados != null) {
            enderecoId = dados.EnderecoId == null ? "" : dados.EnderecoId;
            uf = dados.Uf == null ? "" : dados.Uf;
            municipio = dados.Municipio == null ? "" : dados.Municipio;
            logradouro = dados.Logradouro == null ? "" : dados.Logradouro;
            numero = dados.Numero == null ? "" : dados.Numero;
            bairro = dados.Bairro == null ? "" : dados.Bairro;
            cep = dados.Cep == null ? "" : dados.Cep;
            active = "class=\"active\"";
        }

        html += "<form id=\"frmEndereco\" eId=\"" + enderecoId + "\">";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtUf\" type=\"text\" value=\"" + uf + "\">";
        html += "            <label for=\"txtUf\" " + active + ">UF</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtMunicipio\" type=\"text\" value=\"" + municipio + "\">";
        html += "            <label for=\"txtMunicipio\" " + active + ">Município</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtLogradouro\" type=\"text\" value=\"" + logradouro + "\">";
        html += "            <label for=\"txtLogradouro\" " + active + ">Logradouro</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtNumero\" type=\"text\" value=\"" + numero + "\">";
        html += "            <label for=\"txtNumero\" " + active + ">Numero</label>";
        html += "        </div>";
        html += "    </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtBairro\" type=\"text\" value=\"" + bairro + "\">";
        html += "            <label for=\"txtBairro\" " + active + ">Bairro</label>";
        html += "        </div>";
        html += "   </div>";
        html += "    <div class=\"row\">";
        html += "        <div class=\"input-field col s12\">";
        html += "            <input id=\"txtCep\" type=\"text\" value=\"" + cep + "\">";
        html += "            <label for=\"txtCep\" " + active + ">Cep</label>";
        html += "        </div>";
        html += "   </div>";
        html += "</form>";

        $("#divEndereco").html(html);
    }
}