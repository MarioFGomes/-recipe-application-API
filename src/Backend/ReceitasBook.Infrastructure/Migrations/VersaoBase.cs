

using FluentMigrator.Builders.Create.Table;

namespace ReceitasBook.Infrastructure.Migrations;

public static class VersaoBase
{
    public static ICreateTableWithColumnOrSchemaOrDescriptionSyntax InsertColumInTable(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        table.WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
             .WithColumn("DataRegistro").AsDateTime().NotNullable()
             .WithColumn("Status").AsBoolean().NotNullable();

        return table;
    }
}
