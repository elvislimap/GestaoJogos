namespace GestaoJogos.Domain.Validations
{
    public class ValidationError
    {
        public ValidationError(string campo, string message)
        {
            Campo = campo;
            Message = message;
        }

        public string Campo { get; set; }
        public string Message { get; set; }
    }
}