namespace GestaoJogos.Domain.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Excluido { get; set; }
    }
}