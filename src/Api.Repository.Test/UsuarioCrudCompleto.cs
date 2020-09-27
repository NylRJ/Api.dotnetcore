using System;
using System.Threading.Tasks;
using Api.Domain.Entities.UserEntity;
using Api.Domain.Entities.UserEntity.ValueObject;
using Api.Repository.Context;
using Api.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Repository.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                CPF _cpf = new CPF("00123456789");
                UserEntity _userEntity = new UserEntity
                {
                    Email = "teste@gmail.com",
                    Name = "Teste",
                    CPF = _cpf,


                };
                var _registroCriado = await _repositorio.InsertAsync(_userEntity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste@gmail.com", _userEntity.Email);
                Assert.Equal("Teste", _userEntity.Name);
                Assert.Equal(_cpf, _userEntity.CPF);
                Assert.False(_registroCriado.Id == Guid.Empty);

            }
        }
    }
}
