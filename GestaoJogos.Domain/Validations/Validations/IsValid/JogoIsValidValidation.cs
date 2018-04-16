using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class JogoIsValidValidation : Validation<Jogo>
    {
        public JogoIsValidValidation()
        {
            AddRule(new ValidationRule<Jogo>(new NomeIsValidSpec()));
        }
    }
}