using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTarefas.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseRouting(); 
app.MapControllers();  


app.Run();