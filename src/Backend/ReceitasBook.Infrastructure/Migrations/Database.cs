using Dapper;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace ReceitasBook.Infrastructure.Migrations;
public static class Database
{
    public static void CreateDatabase(string conectionString, string NameDatabase)
    {
        using var minhaconexao = new SqlConnection(conectionString);
        var parametro = new DynamicParameters();
        parametro.Add("nome", NameDatabase);
        var registros = minhaconexao.Query("SELECT * FROM sys.databases WHERE name=@nome", parametro);
        if (!registros.Any())
        {
            minhaconexao.Execute($"CREATE DATABASE {NameDatabase}");
        }
    }
}
