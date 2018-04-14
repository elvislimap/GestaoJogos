namespace GestaoJogos.Domain.Validations.Validations.Commons
{
    public abstract class IntegerValidation
    {
        public static bool IsValid(int? value)
        {
            return value == null || value > 0;
        }
    }
}