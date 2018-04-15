using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Endereco/v1")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecoController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Endereco endereco)
        {
            return _enderecoAppService.Adicionar(endereco).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _enderecoAppService.ObterTodos().TaskResult();
        }
    }
}