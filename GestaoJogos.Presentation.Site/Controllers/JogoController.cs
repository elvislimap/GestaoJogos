using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoAppService _jogoAppService;

        public JogoController(IJogoAppService jogoAppService)
        {
            _jogoAppService = jogoAppService;
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
                return _jogoAppService.ObterTodos(usuarioId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        public IActionResult Obter(int jogoId)
        {
            try
            {
                return _jogoAppService.Obter(jogoId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Jogo jogo)
        {
            try
            {
                jogo.UsuarioId = Request.Cookies["id"].ToInt();
                return _jogoAppService.Adicionar(jogo).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Jogo jogo)
        {
            try
            {
                jogo.UsuarioId = Request.Cookies["id"].ToInt();
                return _jogoAppService.Atualizar(jogo).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }
    }
}