namespace GestaoJogos.Domain.Services
{
    public interface ISecurityService
    {
        string CreateToken(string user, string pass);
        bool ValidateToken(string token);
    }
}