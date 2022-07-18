using ClientEvaluation.Domain.Handlers;
using ClientEvaluation.Domain.Repositories;
using ClientEvaluation.Infra.Contexts;
using ClientEvaluation.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<CreateClientHandler, CreateClientHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors(x => x
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    .AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
