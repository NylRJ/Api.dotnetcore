using System;
using Api.Domain.Entities.UserEntity.ValueObject;

namespace Api.Domain.Models
{
    public class UserModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private CPF _cpf;
        public CPF CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }


        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }


    }
}
