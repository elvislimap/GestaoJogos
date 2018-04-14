using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IMunicipioAppService
    {
        Result Obter(int estadoId);
    }
}