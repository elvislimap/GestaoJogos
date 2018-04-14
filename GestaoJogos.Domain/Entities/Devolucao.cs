using System;

namespace GestaoJogos.Domain.Entities
{
    public class Devolucao
    {
        public int DevolucaoId { get; set; }
        public int EmprestimoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
        public int Avaliacao { get; set; }
    }
}