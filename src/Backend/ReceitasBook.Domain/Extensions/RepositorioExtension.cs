using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Domain.Extensions;

public static class RepositorioExtension
{
    public static string GetDatabaseName(this IConfiguration Configuration)
    {
        var databasename = Configuration.GetConnectionString("NomeDatabase");
        return databasename;
    }

    public static string Getconnectionstring(this IConfiguration Configuration)
    {
        var connectionstring = Configuration.GetConnectionString("defaultconnection");

        return connectionstring;
    }

    public static string GetFullConnection(this IConfiguration Configuration)
    {
        var databasename = Configuration.GetConnectionString("NomeDatabase");
        var connectionstring = Configuration.GetConnectionString("defaultconnection");
        var result = $"{connectionstring}Database={databasename};";
        return result;
    }
}
