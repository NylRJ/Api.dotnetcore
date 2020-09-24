using System.Threading.Tasks;
using Api.Domain.Entities.UserEntity;
using Api.Domain.Repository;
using Api.Repository.Context;
using Api.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
