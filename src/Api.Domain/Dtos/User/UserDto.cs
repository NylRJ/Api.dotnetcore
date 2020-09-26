using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome é deve ter no máximo {1}  caractere.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "E-mail é deve ter no máximo {1}  caractere.")]
        public string Email { get; set; }
    }
}
