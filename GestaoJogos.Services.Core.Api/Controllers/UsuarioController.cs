using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/Usuario/v1")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Usuario usuario)
        {
            return _usuarioAppService.Adicionar(usuario).TaskResult();
        }
    }
}