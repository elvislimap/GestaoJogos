using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Categoria/v1")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Categoria categoria)
        {
            return _categoriaAppService.Adicionar(categoria).TaskResult();
        }

        [Route("Atualizar")]
        [HttpPut]
        public Task<ObjectResult> Atualizar([FromBody] Categoria categoria)
        {
            return _categoriaAppService.Atualizar(categoria).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _categoriaAppService.ObterTodos(usuarioId).TaskResult();
        }
    }
}