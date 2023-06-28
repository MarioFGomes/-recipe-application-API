using FluentMigrator;
namespace ReceitasBook.Infrastructure.Migrations.Versions;

[Migration((long)NumberVersion.CreateTableUser, "Create table Usuario")]
public class Version0001 : Migration
{

    public override void Up()
    {
        var table = VersaoBase.InsertColumInTable(Create.Table("Usuario"));


        table
             .WithColumn("Name").AsString(100).NotNullable()
             .WithColumn("Email").AsString().NotNullable()
             .WithColumn("Telefone").AsString(100).NotNullable()
             .WithColumn("Password").AsString(2000).NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
    
}
