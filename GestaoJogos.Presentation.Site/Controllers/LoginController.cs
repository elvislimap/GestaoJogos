using System;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Services;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Presentation.Site.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private const string CookieTokenName = "token";
        private const string CookieUsuarioName = "id";

        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ISecurityService _securityService;

        public LoginController(IUsuarioAppService usuarioAppService, ISecurityService securityService)
        {
            _usuarioAppService = usuarioAppService;
            _securityService = securityService;
        }

        public IActionResult Index()
        {
            RemoverCookies();
            return View();
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            RemoverCookies();
            return new Result().Result();
        }

        [HttpPost]
        public IActionResult Logar([FromBody]Usuario usuario)
        {
            try
            {
                var result = _usuarioAppService.Autenticar(usuario.Email, usuario.Senha);

                if (result.Return == null)
                    return new Result {Messages = "Usuário ou senha inválido".StringToList()}.ResultError();

                var usuarioLogado = (Usuario) result.Return;
                var token = _securityService.CreateToken(usuario.Email, usuario.Senha);

                Response.Cookies.Append(CookieTokenName, token,
                    new CookieOptions {Expires = DateTime.Now.AddHours(23)});
                Response.Cookies.Append(CookieUsuarioName, usuarioLogado.UsuarioId.ToText(),
                    new CookieOptions {Expires = DateTime.Now.AddHours(23)});

                return new Result().Result();
            }
            catch
            {
                return new Result().ResultError();
            }
        }


        private void RemoverCookies()
        {
            Response.Cookies.Delete(CookieTokenName);
            Response.Cookies.Delete(CookieUsuarioName);
        }
    }
}