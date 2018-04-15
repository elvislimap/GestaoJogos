using System.Threading.Tasks;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Services.Core.Api.Commons;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Controllers
{
    [Route("api/Municipio/v1")]
    public class MunicipioController : Controller
    {
        private readonly IMunicipioAppService _municipioAppService;

        public MunicipioController(IMunicipioAppService municipioAppService)
        {
            _municipioAppService = municipioAppService;
        }


        [Route("Obter")]
        [HttpGet]
        public Task<ObjectResult> Obter(int estadoId)
        {
            return _municipioAppService.Obter(estadoId).TaskResult();
        }
    }
}