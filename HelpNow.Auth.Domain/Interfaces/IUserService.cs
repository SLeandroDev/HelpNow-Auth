using HelpNow.Auth.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Domain.Interfaces;
public interface IUserService
{
    Task CriarUsuarioAsync(UserRegisterDto userRegisterDto);
    Task<string?> AuthenticateAsync(UserLoginDto loginDto);
}