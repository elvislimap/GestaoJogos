namespace GestaoJogos.Domain.Entities
{
    public class PessoaEndereco
    {
        public int PessoaEnderecoId { get; set; }
        public int PessoaId { get; set; }
        public int EnderecoId { get; set; }
        public bool Excluido { get; set; }
    }
}