namespace GestaoJogos.Domain.Entities
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public int? FabricanteId { get; set; }
        public int? CategoriaId { get; set; }
        public string Nome { get; set; }
        public bool Excluido { get; set; }
    }
}