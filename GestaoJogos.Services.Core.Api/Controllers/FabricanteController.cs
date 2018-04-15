using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Fabricante/v1")]
    public class FabricanteController : Controller
    {
        private readonly IFabricanteAppService _fabricanteAppService;

        public FabricanteController(IFabricanteAppService fabricanteAppService)
        {
            _fabricanteAppService = fabricanteAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Fabricante fabricante)
        {
            return _fabricanteAppService.Adicionar(fabricante).TaskResult();
        }

        [Route("Atualizar")]
        [HttpPut]
        public Task<ObjectResult> Atualizar([FromBody] Fabricante fabricante)
        {
            return _fabricanteAppService.Atualizar(fabricante).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _fabricanteAppService.ObterTodos(usuarioId).TaskResult();
        }
    }
}