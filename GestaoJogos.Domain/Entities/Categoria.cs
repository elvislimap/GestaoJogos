namespace GestaoJogos.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }
    }
}