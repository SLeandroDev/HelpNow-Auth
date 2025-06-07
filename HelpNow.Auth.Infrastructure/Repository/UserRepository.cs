using HelpNow.Auth.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpNow.Auth.Infrastructure.UoW;
using HelpNow.Auth.Domain.Dtos;
using Dapper;
using HelpNow.Auth.Domain.Models;
 
namespace HelpNow.Auth.Infrastructure.Repository;
public class UserRepository(IUnitOfWork uow) : IUserRepository
{
    private readonly IUnitOfWork _uow = uow;

    public async Task AdicionarUsuarioAsync(UserModel usuario)
    {
        var query = @"INSERT INTO TbUser (Nome, Email, SenhaHash, DtCriacao, DtAtualizacao, TpAcesso)
                      VALUES (@Nome, @Email, @SenhaHash, @DtCriacao, @DtAtualizacao, @TpAcesso)";

        await _uow.Connection.ExecuteAsync(query, usuario, _uow.Transaction);
    }

    public async Task<UserModel> ObterUserPorEmailAsync(string email)
    {
        var query = @"SELECT * FROM TbUser WHERE Email = @Email";

        return await _uow.Connection.QueryFirstOrDefaultAsync<UserModel>(query, new { Email = email }, _uow.Transaction);
    }
}
