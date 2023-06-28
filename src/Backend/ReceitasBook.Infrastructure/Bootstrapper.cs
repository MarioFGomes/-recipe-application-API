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

namespace ReceitasBook.Infrastructure
{
    public static class Bootstrapper
    {

        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            AddFluentMigration(services, configuration);
        }

        public static void AddFluentMigration(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddFluentMigratorCore().ConfigureRunner(m =>
            m.AddSqlServer().WithGlobalConnectionString(configuration.GetFullConnection()).ScanIn(Assembly.Load("ReceitasBook.Infrastructure")).For.All());
        }
    }
}
