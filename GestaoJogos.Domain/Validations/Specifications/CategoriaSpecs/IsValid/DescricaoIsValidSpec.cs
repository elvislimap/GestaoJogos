using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.CategoriaSpecs.IsValid
{
    public class DescricaoIsValidSpec : ISpecification<Categoria>
    {
        public ValidationRuleReturn IsSatisfiedBy(Categoria entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Descricao, 30),
                Field = "Descricao",
                MessageError = "A descricao deve conter no máximo 30 caracteres"
            };
        }
    }
}