using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class PessoaIsRequiredValidation : Validation<Pessoa>
    {
        public PessoaIsRequiredValidation()
        {
            AddRule(new ValidationRule<Pessoa>(new NomeIsRequiredSpec()));
        }
    }
}