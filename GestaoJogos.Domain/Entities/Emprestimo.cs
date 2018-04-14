using System;

namespace GestaoJogos.Domain.Entities
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public int PessoaId { get; set; }
        public int JogoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
    }
}