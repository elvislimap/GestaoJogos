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
            throw new System.NotImplementedException();
        }

        public Result Atualizar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(string email, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}