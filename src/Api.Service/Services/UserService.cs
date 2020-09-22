using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities.UserEntity;
using Api.Domain.interfaces;
using Api.Domain.interfaces.Services.User;

namespace Api.Service.Services
{

    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;
        public UserService(IRepository<UserEntity> repository)
        {
            this._repository = repository;

        }
        public Task<bool> Delet(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Post(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Put(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
