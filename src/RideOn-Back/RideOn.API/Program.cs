using Microsoft.EntityFrameworkCore;
using RideOn.CrossCutting.Dependencies;
using RideOn.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies(builder.Configuration);

var app = builder.Build();


// Roda migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RideOnDbContext>();
    db.Database.Migrate();
}

// Configura rotas e middlewares
app.MapControllers();
app.Run();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
