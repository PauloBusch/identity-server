using System.ComponentModel.DataAnnotations;

namespace Identity.Domain.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string Password { get; set; }
    }
}
