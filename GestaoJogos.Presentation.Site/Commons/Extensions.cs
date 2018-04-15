using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GestaoJogos.Domain.ValuesObjects;
using Microsoft.AspNetCore.Mvc;

namespace GestaoJogos.Presentation.Site.Commons
{
    public static class Extensions
    {
        public static HttpStatusCode GetHttpStatusCode(this Result result)
        {
            return result.Messages.Any() || result.ValidationErrors.Any()
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;
        }

        public static ObjectResult Result(this Result result)
        {
            return new ObjectResult(result) {StatusCode = (int) result.GetHttpStatusCode()};
        }
    }
}