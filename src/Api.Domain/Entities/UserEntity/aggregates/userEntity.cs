using Api.Domain.Entities.UserEntity.aggregates;

namespace Api.Domain.Entities.userEntity
{
    public class userEntity : BaseEntity
    {
        public string Name { get; set; }

        public Email Email { get; set; }
    }
}
