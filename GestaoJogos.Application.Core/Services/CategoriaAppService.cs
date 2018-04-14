using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaAppService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public Result Adicionar(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public Result Atualizar(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterTodos(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}