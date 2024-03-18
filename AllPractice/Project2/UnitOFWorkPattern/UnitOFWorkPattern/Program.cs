using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using UnitOFWorkPattern.Context;
using UnitOFWorkPattern.Interface;
using UnitOFWorkPattern.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnitOfWorkDB"));
});


builder.Services.AddControllers();
builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<SieveProcessor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

app.Run();
