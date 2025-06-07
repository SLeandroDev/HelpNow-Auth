using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; 
using Microsoft.Extensions.Configuration;

namespace HelpNow.Auth.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction _transaction;

    public UnitOfWork(IConfiguration configuration)
    {
        _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _connection.Open();
    }

    public IDbConnection Connection => _connection;
    public IDbTransaction Transaction => _transaction;

    public void Begin()
    {
        _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection?.Dispose();
    }
}
