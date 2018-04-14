using System.Text.RegularExpressions;

namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class EmailValidation
    {
        public static bool IsValid(string email, int length)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            if (email.Length > length)
                return false;

            var regex = new Regex(
                @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            return regex.IsMatch(email);
        }
    }
}