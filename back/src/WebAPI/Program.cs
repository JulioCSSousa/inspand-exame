using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Adicionando suporte ao banco de dados SQL Server (rodando no Docker)
var connectionString = builder.Configuration.GetConnectionString("SQLConnection");

builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(connectionString)); // 🔹 Configurando SQL Server

// 🔹 Configuração de CORS
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Testando conexão com o banco ao iniciar a API
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SqlDbContext>();
    try
    {
        db.Database.CanConnect();
        Console.WriteLine("✅ Conectado ao SQL Server!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Erro ao conectar no SQL Server: {ex.Message}");
    }
}

app.MapGet("/", () => Results.Ok("API is healthy!"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
