using MetalCoin.Api.Configuracoes;
using MetalCoin.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco de dados SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.ResolveDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir todas as origens
    options.AllowAnyMethod(); // Permitir todos os métodos (GET, POST, PUT, DELETE, etc.)
    options.AllowAnyHeader(); // Permitir todos os cabeçalhos
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
