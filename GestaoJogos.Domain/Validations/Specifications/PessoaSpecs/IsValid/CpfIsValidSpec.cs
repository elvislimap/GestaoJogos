using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsValid
{
    public class CpfIsValidSpec : ISpecification<Pessoa>
    {
        public ValidationRuleReturn IsSatisfiedBy(Pessoa entity)
        {
            return new ValidationRuleReturn
            {
                Valid = CpfValidation.IsValid(entity.Cpf),
                Field = "Cpf",
                MessageError = "O CPF é inválido"
            };
        }
    }
}