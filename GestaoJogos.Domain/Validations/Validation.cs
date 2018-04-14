using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Interfaces.Validations;

namespace GestaoJogos.Domain.Validations
{
    public class Validation<TEntity> : IValidation<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IValidationRule<TEntity>> _validationsRules;

        public Validation()
        {
            _validationsRules = new Dictionary<string, IValidationRule<TEntity>>();
        }

        protected virtual void AddRule(IValidationRule<TEntity> validationRule)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");
            _validationsRules.Add(ruleName, validationRule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            _validationsRules.Remove(ruleName);
        }

        public ValidationResult Execute(TEntity entity)
        {
            var result = new ValidationResult();

            foreach (var key in _validationsRules.Keys)
            {
                var rule = _validationsRules[key];

                var validationRuleRet = rule.Valid(entity);

                if (validationRuleRet.Valid) continue;

                result.Add(new ValidationError(validationRuleRet.Field, validationRuleRet.MessageError));
            }

            return result;
        }
    }
}