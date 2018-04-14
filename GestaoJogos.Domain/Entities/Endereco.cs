namespace GestaoJogos.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int MunicipioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
    }
}