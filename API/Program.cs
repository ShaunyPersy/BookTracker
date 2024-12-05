using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApiRepo, MySqlAPIRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//var _connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
var _connectionString = "server=mysql-container;database=api_db;user=api_user;password=api_pw;";
System.Console.WriteLine("connection string: " + _connectionString);
builder.Services.AddDbContext<APIContext>(opt => 
    opt.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();