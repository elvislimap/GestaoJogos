using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Services;
using GestaoJogos.Domain.ValuesObjects;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/Auth/v1")]
    public class AuthController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ISecurityService _securityService;

        public AuthController(IUsuarioAppService usuarioAppService, ISecurityService securityService)
        {
            _usuarioAppService = usuarioAppService;
            _securityService = securityService;
        }


        [Route("Token")]
        [HttpPost]
        public Task<ObjectResult> ObterUsuario([FromBody] Usuario usuario)
        {
            var result = _usuarioAppService.Autenticar(usuario.Email, usuario.Senha);

            return !result.Return.ToBool()
                ? new Result {Messages = new List<string> {"Email ou senha inválido"}}.TaskResult()
                : new Result {Return = _securityService.CreateToken(usuario.Email, usuario.Senha)}.TaskResult();
        }
    }
}