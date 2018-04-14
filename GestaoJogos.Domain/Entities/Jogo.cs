namespace GestaoJogos.Domain.Entities
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public int? FabricanteId { get; set; }
        public int? CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public bool Excluido { get; set; }

        public virtual Fabricante Fabricante { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}