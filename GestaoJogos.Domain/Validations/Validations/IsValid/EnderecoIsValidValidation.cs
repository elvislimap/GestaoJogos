using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class EnderecoIsValidValidation : Validation<Endereco>
    {
        public EnderecoIsValidValidation()
        {
            AddRule(new ValidationRule<Endereco>(new BairroIsValidSpec()));
            AddRule(new ValidationRule<Endereco>(new CepIsValidSpec()));
            AddRule(new ValidationRule<Endereco>(new LogradouroIsValidSpec()));
            AddRule(new ValidationRule<Endereco>(new MunicipioIsValidSpec()));
            AddRule(new ValidationRule<Endereco>(new NumeroIsValidSpec()));
            AddRule(new ValidationRule<Endereco>(new UfIsValidSpec()));
        }
    }
}