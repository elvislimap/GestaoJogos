using System.Collections.Generic;
using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.Validations;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
        }


        public Result Adicionar(Categoria categoria)
        {
            if (!categoria.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _categoriaRepository.Adicionar(categoria);

            return new Result();
        }

        public Result Atualizar(Categoria categoria)
        {
            return !categoria.IsValid(out var listValidationErrors)
                ? new Result {ValidationErrors = listValidationErrors}
                : _categoriaService.Atualizar(categoria);
        }

        public Result ObterTodos(int usuarioId)
        {
            return new Result {Return = _categoriaRepository.ObterTodos(usuarioId)};
        }
    }
}