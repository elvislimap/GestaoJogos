using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class UsuarioIsRequiredValidation : Validation<Usuario>
    {
        public UsuarioIsRequiredValidation()
        {
            AddRule(new ValidationRule<Usuario>(new NomeIsRequiredSpec()));
            AddRule(new ValidationRule<Usuario>(new EmailIsRequiredSpec()));
            AddRule(new ValidationRule<Usuario>(new SenhaIsRequiredSpec()));
        }
    }
}