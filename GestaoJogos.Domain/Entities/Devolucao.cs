using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Validations;
using GestaoJogos.Domain.Validations.Validations.IsRequired;
using GestaoJogos.Domain.Validations.Validations.IsValid;

namespace GestaoJogos.Domain.Entities
{
    public class Devolucao
    {
        public int DevolucaoId { get; set; }
        public int EmprestimoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
        public byte Avaliacao { get; set; }

        public virtual Emprestimo Emprestimo { get; set; }

        private bool IsRequiredValid(out List<ValidationError> listValidationErrors)
        {
            var rules = new DevolucaoIsRequiredValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }

        public bool IsValid(out List<ValidationError> listValidationErrors)
        {
            if (!IsRequiredValid(out listValidationErrors))
                return false;

            var rules = new DevolucaoIsValidValidation();
            var validationResult = rules.Execute(this);

            listValidationErrors = validationResult.Errors.ToList();

            return validationResult.IsValid;
        }
    }
}