using HelpNow.Auth.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Domain.Models;

public class UserModel
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public DateTime DtCriacao { get; set; }
    public DateTime DtAtualizacao { get; set; }
    public TipoAcesso TpAcesso { get; set; }
}