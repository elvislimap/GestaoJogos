using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public Result Adicionar(Usuario usuario)
        {
            if (!usuario.IsValid(out var listValidationErrors, _usuarioRepository))
                return new Result {ValidationErrors = listValidationErrors};

            _usuarioRepository.Adicionar(usuario);

            return new Result();
        }

        public Result Obter(string email, string senha)
        {
            return new Result {Return = _usuarioRepository.Obter(email, senha)};
        }
    }
}