

using DataBaseServises.Managers;
using DataBaseServises.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<AdsManager>();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllerRoute(name:"Default","{Controller=Api}/{action}" ); //шаблон маршрута
app.Run();

