using api_neo_nasa;
using api_neo_nasa.Services;
using api_neo_nasa.Services.Interface;
using api_neo_nasa.Utils;
using api_neo_nasa.Utils.Interface;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAsteroidServices,AsteroidServices>();
builder.Services.AddTransient<IUtils,Utils>();
builder.Services.AddHttpClient();
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
