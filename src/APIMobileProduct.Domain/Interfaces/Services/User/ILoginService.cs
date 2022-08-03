using System.Threading.Tasks;
using APIMobileProduct.Domain.Dtos;

namespace APIMobileProduct.Domain.Interfaces.Services.Company
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto login);
    }
}
