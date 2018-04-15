using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Pessoa/v1")]
    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Pessoa pessoa)
        {
            return _pessoaAppService.Adicionar(pessoa).TaskResult();
        }

        [Route("Atualizar")]
        [HttpPut]
        public Task<ObjectResult> Atualizar([FromBody] Pessoa pessoa)
        {
            return _pessoaAppService.Atualizar(pessoa).TaskResult();
        }

        [Route("Obter")]
        [HttpGet]
        public Task<ObjectResult> Obter(int pessoaId)
        {
            return _pessoaAppService.Obter(pessoaId).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _pessoaAppService.ObterTodos(usuarioId).TaskResult();
        }
    }
}