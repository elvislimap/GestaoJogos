using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Devolucao/v1")]
    public class DevolucaoController : Controller
    {
        private readonly IDevolucaoAppService _devolucaoAppService;

        public DevolucaoController(IDevolucaoAppService devolucaoAppService)
        {
            _devolucaoAppService = devolucaoAppService;
        }


        [Route("Adicionar")]
        [HttpPost]
        public Task<ObjectResult> Adicionar([FromBody] Devolucao devolucao)
        {
            return _devolucaoAppService.Adicionar(devolucao).TaskResult();
        }
    }
}