using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HelpNow.Auth.Domain.Enums;

namespace HelpNow.Auth.Domain.Dtos;
public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Senha).NotEmpty().MinimumLength(6);
        RuleFor(x => x.TpAcesso)
        .Must(x => Enum.IsDefined(typeof(TipoAcesso), x))
        .WithMessage("TpAcesso inválido.");
    }
}
