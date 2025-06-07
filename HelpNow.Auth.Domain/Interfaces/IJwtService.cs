using HelpNow.Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Domain.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserModel user);
}
