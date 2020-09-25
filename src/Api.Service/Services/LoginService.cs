using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities.UserEntity;
using Api.Domain.interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        public SigningConfigurations _signinConfigurations;
        public TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration { get; }
        private IUserRepository _repository;
        public LoginService(
                IUserRepository repository,
                SigningConfigurations signinConfigurations,
                TokenConfigurations tokenConfigurations,
                IConfiguration configuration)
        {
            this._repository = repository;
            this._signinConfigurations = signinConfigurations;
            this._tokenConfigurations = tokenConfigurations;
            this._configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baserUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baserUser = await _repository.FindByLogin(user.Email);
                if (baserUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao Autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                       new GenericIdentity(user.Email),
                       new[]{
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),//jti o id  do token
                            new Claim(JwtRegisteredClaimNames.UniqueName,user.Email),
                       }
                   );

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds); // tempo de expirar
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, user);

                }

            }
            else
            {
                return null;
            }

        }



        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                useName = user.Email,
                message = "Usuário Logado Com Sucesso!"
            };
        }
    }
}
