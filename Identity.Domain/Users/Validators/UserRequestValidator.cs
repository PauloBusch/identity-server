using FluentValidation;
using Identity.Domain.Users.Dtos;

namespace Identity.Domain.Users.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage($"Name deve ser informado")
                .Length(3, 150).WithMessage("Nome deve ter no mínimo 3 caracteres e no máximo 150 caracteres");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage($"Email deve ser informado")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage($"Password deve ser informado")
                .MinimumLength(3).WithMessage("Password deve ter no mínimo 3");
        }
    }
}
