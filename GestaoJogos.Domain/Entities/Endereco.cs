using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Validations;
using GestaoJogos.Domain.Validations.Validations.IsRequired;
using GestaoJogos.Domain.Validations.Validations.IsValid;

namespace GestaoJogos.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        private bool IsRequiredValid(out List<ValidationError> listValidationErrors)
        {
            var rules = new EnderecoIsRequiredValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }

        public bool IsValid(out List<ValidationError> listValidationErrors)
        {
            if (!IsRequiredValid(out listValidationErrors))
                return false;

            var rules = new EnderecoIsValidValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }

        public bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(Logradouro) && string.IsNullOrEmpty(Numero) && string.IsNullOrEmpty(Bairro) &&
                   string.IsNullOrEmpty(Municipio) && string.IsNullOrEmpty(Uf) && string.IsNullOrEmpty(Cep);
        }
    }
}