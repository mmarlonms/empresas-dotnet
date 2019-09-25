using Empresas.Domain.Models;

namespace Empresas.Domain.Services
{
    public interface IAuthService
    {
        object Authorize(string user, string pass);
    }
}