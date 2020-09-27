using System;
using Api.Domain.Entities.UserEntity.ValueObject;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public CPF CPF { get; set; }

        public DateTime CreateAt { get; set; }


    }
}
