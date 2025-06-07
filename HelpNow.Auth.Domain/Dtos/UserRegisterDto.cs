using HelpNow.Auth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Domain.Dtos;
public class UserRegisterDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoAcesso TpAcesso { get; set; }
}
