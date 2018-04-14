using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class EnderecoIsRequiredValidation : Validation<Endereco>
    {
        public EnderecoIsRequiredValidation()
        {
            AddRule(new ValidationRule<Endereco>(new BairroIsRequiredSpec()));
            AddRule(new ValidationRule<Endereco>(new CepIsRequiredSpec()));
            AddRule(new ValidationRule<Endereco>(new LogradouroIsRequiredSpec()));
            AddRule(new ValidationRule<Endereco>(new MunicipioIdIsRequiredSpec()));
        }
    }
}