using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/PessoaEndereco/v1")]
    public class PessoaEnderecoController : Controller
    {
        private readonly IPessoaEnderecoAppService _pessoaEnderecoAppService;

        public PessoaEnderecoController(IPessoaEnderecoAppService pessoaEnderecoAppService)
        {
            _pessoaEnderecoAppService = pessoaEnderecoAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] PessoaEndereco pessoaEndereco)
        {
            return _pessoaEnderecoAppService.Adicionar(pessoaEndereco).TaskResult();
        }

        [Route("Atualizar")]
        [HttpPut]
        public Task<ObjectResult> Atualizar([FromBody] PessoaEndereco pessoaEndereco)
        {
            return _pessoaEnderecoAppService.Atualizar(pessoaEndereco).TaskResult();
        }

        [Route("Obter")]
        [HttpGet]
        public Task<ObjectResult> Obter(int pessoaEnderecoId)
        {
            return _pessoaEnderecoAppService.Obter(pessoaEnderecoId).TaskResult();
        }

        [Route("ObterPorPessoa")]
        [HttpGet]
        public Task<ObjectResult> ObterPorPessoa(int pessoaId)
        {
            return _pessoaEnderecoAppService.ObterPorPessoa(pessoaId).TaskResult();
        }
    }
}