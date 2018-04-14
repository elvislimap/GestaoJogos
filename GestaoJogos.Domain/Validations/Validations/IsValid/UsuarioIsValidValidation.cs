using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class UsuarioIsValidValidation : Validation<Usuario>
    {
        public UsuarioIsValidValidation()
        {
            AddRule(new ValidationRule<Usuario>(new NomeIsValidSpec()));
            AddRule(new ValidationRule<Usuario>(new EmailIsValidSpec()));
            AddRule(new ValidationRule<Usuario>(new SenhaIsValidSpec()));
        }
    }
}