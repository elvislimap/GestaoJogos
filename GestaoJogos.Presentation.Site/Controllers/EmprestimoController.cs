using System.Collections.Generic;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoAppService _emprestimoAppService;
        private readonly IPessoaAppService _pessoaAppService;
        private readonly IJogoAppService _jogoAppService;

        public EmprestimoController(IEmprestimoAppService emprestimoAppService, IPessoaAppService pessoaAppService,
            IJogoAppService jogoAppService)
        {
            _emprestimoAppService = emprestimoAppService;
            _pessoaAppService = pessoaAppService;
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
                return _emprestimoAppService.ObterTodos(usuarioId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        public IActionResult ObterDadosComplementares()
        {
            try
            {
                var usuarioId = Request.Cookies["id"].ToInt();

                var pessoas = (List<Pessoa>) _pessoaAppService.ObterTodos(usuarioId).Return;
                var jogos = (List<Jogo>) _jogoAppService.ObterTodos(usuarioId).Return;

                return new Result {Return = new {Pessoas = pessoas, Jogos = jogos}}.Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Emprestimo emprestimo)
        {
            try
            {
                emprestimo.UsuarioId = Request.Cookies["id"].ToInt();
                return _emprestimoAppService.Adicionar(emprestimo).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }
    }
}