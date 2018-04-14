using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Validations;
using GestaoJogos.Domain.Validations.Validations.IsRequired;
using GestaoJogos.Domain.Validations.Validations.IsValid;

namespace GestaoJogos.Domain.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Excluido { get; set; }

        private bool IsRequiredValid(out List<ValidationError> listValidationErrors)
        {
            var rules = new PessoaIsRequiredValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }

        public bool IsValid(out List<ValidationError> listValidationErrors)
        {
            if (!IsRequiredValid(out listValidationErrors))
                return false;

            var rules = new PessoaIsValidValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }
    }
}