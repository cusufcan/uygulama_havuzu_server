using Microsoft.EntityFrameworkCore;
using uygulama_havuzu_server.Application.Services;
using uygulama_havuzu_server.Core.Interfaces;
using uygulama_havuzu_server.Infrastructure.Data;
using uygulama_havuzu_server.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Added Connection String & DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
