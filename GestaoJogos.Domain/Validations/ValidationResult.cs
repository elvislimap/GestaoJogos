using System.Collections.Generic;
using System.Linq;

namespace GestaoJogos.Domain.Validations
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            _errors = new List<ValidationError>();
        }

        private readonly List<ValidationError> _errors;
        public bool IsValid => !_errors.Any();
        public IEnumerable<ValidationError> Errors => _errors;


        public ValidationResult Add(string campo, string errorMessage)
        {
            _errors.Add(new ValidationError(campo, errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _errors.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _errors.AddRange(result.Errors);

            return this;
        }
    }
}