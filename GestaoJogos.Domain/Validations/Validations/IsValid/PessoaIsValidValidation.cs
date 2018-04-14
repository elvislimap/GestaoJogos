using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class PessoaIsValidValidation : Validation<Pessoa>
    {
        public PessoaIsValidValidation()
        {
            AddRule(new ValidationRule<Pessoa>(new CpfIsValidSpec()));
            AddRule(new ValidationRule<Pessoa>(new EmailIsValidSpec()));
            AddRule(new ValidationRule<Pessoa>(new NomeIsValidSpec()));
            AddRule(new ValidationRule<Pessoa>(new SobrenomeIsValidSpec()));
            AddRule(new ValidationRule<Pessoa>(new TelefoneIsValidSpec()));
        }
    }
}