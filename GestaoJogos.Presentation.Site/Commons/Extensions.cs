using System.Linq;
using System.Net;
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

        public static ObjectResult ResultError(this Result result)
        {
            return new ObjectResult(result)
            {
                StatusCode = result.Messages.Any() || result.ValidationErrors.Any()
                    ? (int) HttpStatusCode.BadRequest
                    : (int) HttpStatusCode.InternalServerError
            };
        }
    }
}