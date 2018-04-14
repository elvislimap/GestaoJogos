namespace GestaoJogos.Domain.ValuesObjects
{
    public class ValidationRuleReturn
    {
        public bool Valid { get; set; }
        public string Field { get; set; }
        public string MessageError { get; set; }
    }
}