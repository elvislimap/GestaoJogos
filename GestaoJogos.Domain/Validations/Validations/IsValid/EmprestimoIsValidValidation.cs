using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.EmprestimoSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class EmprestimoIsValidValidation : Validation<Emprestimo>
    {
        public EmprestimoIsValidValidation()
        {
            AddRule(new ValidationRule<Emprestimo>(new JogoIdIsValidSpec()));
            AddRule(new ValidationRule<Emprestimo>(new PessoaIdIsValidSpec()));
        }
    }
}