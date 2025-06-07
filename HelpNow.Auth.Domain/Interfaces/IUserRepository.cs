using HelpNow.Auth.Domain.Dtos;
using HelpNow.Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Domain.Interfaces;
public interface IUserRepository
{
    Task AdicionarUsuarioAsync(UserModel userModel);

    Task<UserModel> ObterUserPorEmailAsync(string email);
}
