using System.Linq;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class AmigoController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly IPessoaEnderecoAppService _pessoaEnderecoAppService;

        public AmigoController(IPessoaAppService pessoaAppService, IEnderecoAppService enderecoAppService,
            IPessoaEnderecoAppService pessoaEnderecoAppService)
        {
            _pessoaAppService = pessoaAppService;
            _enderecoAppService = enderecoAppService;
            _pessoaEnderecoAppService = pessoaEnderecoAppService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ObterLista()
        {
            try
            {
                var usuarioId = Request.Cookies["id"].ToInt();
                return _pessoaAppService.ObterTodos(usuarioId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        public IActionResult Obter(int pessoaId)
        {
            try
            {
                return _pessoaAppService.Obter(pessoaId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] AmigoAdd amigo)
        {
            try
            {
                amigo.Pessoa.UsuarioId = Request.Cookies["id"].ToInt();
                var resultPessoa = _pessoaAppService.Adicionar(amigo.Pessoa);

                if (resultPessoa.Messages.Any() || resultPessoa.ValidationErrors.Any())
                    return resultPessoa.Result();

                if (amigo.Endereco.AllFieldsEmpty())
                    return resultPessoa.Result();

                var resultEndereco = _enderecoAppService.Adicionar(amigo.Endereco);

                if (resultEndereco.Messages.Any() || resultEndereco.ValidationErrors.Any())
                    return resultEndereco.Result();

                var pessoa = (Pessoa) resultPessoa.Return;
                var endereco = (Endereco) resultEndereco.Return;
                var pessoaEndereco = new PessoaEndereco
                {
                    PessoaId = pessoa.PessoaId,
                    EnderecoId = endereco.EnderecoId
                };

                return _pessoaEnderecoAppService.Adicionar(pessoaEndereco).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] AmigoAdd amigo)
        {
            try
            {
                amigo.Pessoa.UsuarioId = Request.Cookies["id"].ToInt();
                var resultPessoa = _pessoaAppService.Atualizar(amigo.Pessoa);

                if (resultPessoa.Messages.Any() || resultPessoa.ValidationErrors.Any())
                    return resultPessoa.Result();

                if (amigo.Endereco.AllFieldsEmpty())
                    return resultPessoa.Result();

                var resultEndereco = _enderecoAppService.Adicionar(amigo.Endereco);

                if (resultEndereco.Messages.Any() || resultEndereco.ValidationErrors.Any())
                    return resultEndereco.Result();

                var endereco = (Endereco)resultEndereco.Return;
                var pessoaEndereco = new PessoaEndereco
                {
                    PessoaEnderecoId = amigo.PessoaEnderecoId,
                    PessoaId = amigo.Pessoa.PessoaId,
                    EnderecoId = endereco.EnderecoId
                };

                return _pessoaEnderecoAppService.Atualizar(pessoaEndereco).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }
    }
}