using AspNetCorePostgreSQL.API.BusinessRules;
using AspNetCorePostgreSQL.API.Data;
using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    context => context.UseNpgsql(connectionString)
);

/**************************
* Injecao de dependencias *
**************************/
builder.Services.AddScoped<IUsuariosRepositoryQuery, UsuariosRepositoryQuery>();
builder.Services.AddScoped<IUsuariosRepositoryCommand, UsuariosRepositoryCommand>();

builder.Services.AddScoped<UsuariosRulesQuery>();
builder.Services.AddScoped<UsuariosRulesCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
