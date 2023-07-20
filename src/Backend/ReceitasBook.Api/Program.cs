using ReceitasBook.Api.Filter;
using ReceitasBook.Application;
using ReceitasBook.Application.Service.AutoMapper;
using ReceitasBook.Domain.Extensions;
using ReceitasBook.Infrastructure;
using ReceitasBook.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplication(builder.Configuration);
builder.Services.AddRepository(builder.Configuration);
builder.Services.AddMvc(options=>options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped(options => new AutoMapper.MapperConfiguration(config =>
{
    config.AddProfile(new AutoMapperProvider());
}).CreateMapper());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AtualizarDatabase();

app.Run();

void AtualizarDatabase()
{
    var contionstring = builder.Configuration.Getconnectionstring();
    var namedatabase = builder.Configuration.GetDatabaseName();
    Database.CreateDatabase(contionstring, namedatabase);
    app.MigrationDataBase();
}
