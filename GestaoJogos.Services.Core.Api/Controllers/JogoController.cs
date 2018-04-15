using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Jogo/v1")]
    public class JogoController : Controller
    {
        private IJogoAppService _jogoAppService;

        public JogoController(IJogoAppService jogoAppService)
        {
            _jogoAppService = jogoAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Jogo jogo)
        {
            return _jogoAppService.Adicionar(jogo).TaskResult();
        }

        [Route("Atualizar")]
        [HttpPut]
        public Task<ObjectResult> Atualizar([FromBody] Jogo jogo)
        {
            return _jogoAppService.Atualizar(jogo).TaskResult();
        }

        [Route("Obter")]
        [HttpGet]
        public Task<ObjectResult> Obter(int jogoId)
        {
            return _jogoAppService.Obter(jogoId).TaskResult();
        }

        [Route("ObterComFiltro")]
        [HttpGet]
        public Task<ObjectResult> ObterComFiltro(int usuarioId, string filtro)
        {
            return _jogoAppService.Obter(usuarioId, filtro).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _jogoAppService.ObterTodos(usuarioId).TaskResult();
        }
    }
}