using System.Threading.Tasks;
using Api.Domain.Entities.UserEntity;

namespace Api.Domain.interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
