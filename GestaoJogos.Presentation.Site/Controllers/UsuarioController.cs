using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [AllowAnonymous]
        public IActionResult Novo()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Adicionar([FromBody]Usuario usuario)
        {
            try
            {
                return _usuarioAppService.Adicionar(usuario).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }
    }
}