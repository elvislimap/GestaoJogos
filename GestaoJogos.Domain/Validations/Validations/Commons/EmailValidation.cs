namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class EmailValidation
    {
        public static bool IsValid(string email, int length)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            return email.Length <= length && email.Contains("@");
        }
    }
}