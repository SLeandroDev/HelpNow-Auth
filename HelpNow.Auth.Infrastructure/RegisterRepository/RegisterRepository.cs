using HelpNow.Auth.Domain.Interfaces;
using HelpNow.Auth.Infrastructure.Repository;
using HelpNow.Auth.Infrastructure.UoW;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpNow.Auth.Infrastructure.RegisterRepository;

public static class RegisterRepository
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        // Registra a connection string como IDbConnection Scoped
        services.AddScoped<IDbConnection>(sp =>
        {
            var connString = configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connString);
        });

        // Registra os repositórios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}
