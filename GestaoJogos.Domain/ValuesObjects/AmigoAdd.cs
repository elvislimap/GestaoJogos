using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.ValuesObjects
{
    public class AmigoAdd
    {
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
        public int PessoaEnderecoId { get; set; }
    }
}