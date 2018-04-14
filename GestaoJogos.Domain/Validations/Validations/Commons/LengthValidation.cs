namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class LengthValidation
    {
        public static bool IsValid(string text, int maxLength)
        {
            return string.IsNullOrEmpty(text) || text.Length <= maxLength;
        }
    }
}