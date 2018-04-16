using System;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    public class DevolucaoController : Controller
    {
        private readonly IDevolucaoAppService _devolucaoAppService;
        private readonly IEmprestimoAppService _emprestimoAppService;

        public DevolucaoController(IDevolucaoAppService devolucaoAppService, IEmprestimoAppService emprestimoAppService)
        {
            _devolucaoAppService = devolucaoAppService;
            _emprestimoAppService = emprestimoAppService;
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
                return _devolucaoAppService.ObterTodos(usuarioId).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }

        public IActionResult ObterEmprestimos()
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

        [HttpPost]
        public IActionResult Adicionar([FromBody] Devolucao devolucao)
        {
            try
            {
                devolucao.UsuarioId = Request.Cookies["id"].ToInt();
                return _devolucaoAppService.Adicionar(devolucao).Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }
    }
}