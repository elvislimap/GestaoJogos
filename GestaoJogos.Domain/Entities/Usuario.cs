using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Validations;
using GestaoJogos.Domain.Validations.Validations.IsRequired;
using GestaoJogos.Domain.Validations.Validations.IsValid;

namespace GestaoJogos.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        private bool IsRequiredValid(out List<ValidationError> listValidationErrors)
        {
            var rules = new UsuarioIsRequiredValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }

        public bool IsValid(out List<ValidationError> listValidationErrors, IUsuarioRepository usuarioRepository)
        {
            if (!IsRequiredValid(out listValidationErrors))
                return false;

            var rules = new UsuarioIsValidValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            if (usuarioRepository.Obter(Email).Any())
                listValidationErrors.Add(new ValidationError("Email", "E-mail informado já existe"));

            return validationResult.IsValid && !listValidationErrors.Any();
        }
    }
}