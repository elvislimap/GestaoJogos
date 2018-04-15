using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GestaoJogos.Domain.ValuesObjects;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Services.Core.Api.Commons
{
    public static class Extensions
    {
        public static HttpStatusCode GetHttpStatusCode(this Result result)
        {
            return result.Messages.Any() || result.ValidationErrors.Any()
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;
        }

        public static Task<ObjectResult> TaskResult(this Result result)
        {
            var retorno = new TaskCompletionSource<ObjectResult>();
            retorno.SetResult(new ObjectResult(result) {StatusCode = (int) result.GetHttpStatusCode()});

            return retorno.Task;
        }
    }
}