namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class PasswordValidation
    {
        public static bool IsValid(string pass)
        {
            return pass != null && pass.Length >= 8 && pass.Length <= 16;
        }
    }
}