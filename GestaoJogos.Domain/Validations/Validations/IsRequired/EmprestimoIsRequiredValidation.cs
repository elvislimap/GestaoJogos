using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.EmprestimoSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class EmprestimoIsRequiredValidation : Validation<Emprestimo>
    {
        public EmprestimoIsRequiredValidation()
        {
            AddRule(new ValidationRule<Emprestimo>(new JogoIdIsRequiredSpec()));
            AddRule(new ValidationRule<Emprestimo>(new PessoaIdIsRequiredSpec()));
        }
    }
}