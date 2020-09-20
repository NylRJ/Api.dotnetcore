using Api.Domain.Entities.UserEntity.ValueObject;

namespace Api.Domain.Entities.UserEntity
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public Email Email { get; set; }
    }
}
