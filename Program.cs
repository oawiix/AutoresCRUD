using AutoresCRUD.Data;
using AutoresCRUD.Services.Autores;
using AutoresCRUD.Services.Livros;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Faz a relacao de AutorInterface com a AutorService, ou seja, quando for injetada a interface, o sistema irá fornecer a implementação da classe AutorService
builder.Services.AddScoped<IAutorInterface, AutorService>();
// Faz a relacao de LivroInterface com a LivroService
builder.Services.AddScoped<ILivroInterface, LivroService>();

// lê a connection string do appsettings.json (seção "ConnectionStrings");
builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
