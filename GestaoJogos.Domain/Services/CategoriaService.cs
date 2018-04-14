using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public Result Atualizar(Categoria categoria)
        {
            var categoriaBd = _categoriaRepository.Obter(categoria.CategoriaId);

            if (categoriaBd == null)
                return new Result {Messages = "Categoria não encontrada".StringToList()};

            categoriaBd.Descricao = categoria.Descricao;
            categoriaBd.Excluido = categoria.Excluido;

            _categoriaRepository.Atualizar(categoriaBd);

            return new Result();
        }
    }
}