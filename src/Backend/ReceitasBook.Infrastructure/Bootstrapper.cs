using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ReceitasBook.Domain.Extensions;
using ReceitasBook.Domain.Repository;
using ReceitasBook.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ReceitasBook.Infrastructure
{
    public static class Bootstrapper
    {

        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            AddContext(services, configuration);
            AddFluentMigration(services, configuration);
            AddRepositories(services);
            AddUinitOfWork(services);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>()
                .AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
        }

        public static void AddUinitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReceitaBookContext>(DbOptions =>
            {
                DbOptions.UseSqlServer(configuration.GetFullConnection());
            });
        }
        public static void AddFluentMigration(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddFluentMigratorCore().ConfigureRunner(m =>
            m.AddSqlServer().WithGlobalConnectionString(configuration.GetFullConnection()).ScanIn(Assembly.Load("ReceitasBook.Infrastructure")).For.All());
        }
    }
}
