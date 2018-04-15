using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Emprestimo/v1")]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoAppService _emprestimoAppService;

        public EmprestimoController(IEmprestimoAppService emprestimoAppService)
        {
            _emprestimoAppService = emprestimoAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Emprestimo emprestimo)
        {
            return _emprestimoAppService.Adicionar(emprestimo).TaskResult();
        }

        [Route("Obter")]
        [HttpGet]
        public Task<ObjectResult> Obter(int emprestimoId)
        {
            return _emprestimoAppService.Obter(emprestimoId).TaskResult();
        }

        [Route("ObterTodos")]
        [HttpGet]
        public Task<ObjectResult> ObterTodos(int usuarioId)
        {
            return _emprestimoAppService.ObterTodos(usuarioId).TaskResult();
        }
    }
}