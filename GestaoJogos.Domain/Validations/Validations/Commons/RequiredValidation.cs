using GestaoJogos.Domain.Commons;

namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class RequiredValidation
    {
        public static bool IsValid(object value)
        {
            var valueText = value.ToText();

            if (int.TryParse(valueText, out var valueInt))
                return valueInt > 0;

            return !string.IsNullOrEmpty(valueText);
        }
    }
}