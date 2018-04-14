using System.Collections.Generic;
using GestaoJogos.Domain.Validations;

namespace GestaoJogos.Domain.ValuesObjects
{
    public class Result
    {
        public Result()
        {
            Messages = new List<string>();
            ValidationErrors = new List<ValidationError>();
        }

        public object Return { get; set; }
        public List<string> Messages { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
    }
}