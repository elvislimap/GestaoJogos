using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class JogoIsRequiredValidation : Validation<Jogo>
    {
        public JogoIsRequiredValidation()
        {
            AddRule(new ValidationRule<Jogo>(new NomeIsRequiredSpec()));
        }
    }
}