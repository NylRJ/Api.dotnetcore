using Api.Domain.Entities.UserEntity.ValueObject;

namespace Api.Domain.Entities.userEntity.aggregates
{
    public class userEntity : BaseEntity
    {
        public string Name { get; set; }

        public Email Email { get; set; }
    }
}
