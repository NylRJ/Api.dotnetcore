using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.UserEntity;

namespace Api.Domain.interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll(Guid id);

        Task<UserEntity> Post(UserEntity user);

        Task<UserEntity> Put(UserEntity user);

        Task<bool> Delete(Guid id);

    }
}
