using Microsoft.EntityFrameworkCore;
using SixDegreesIT.Core.SQL;
using SixDegreesIT.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Get Connection String
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<PruebaSDDBContext>();

// Set up Database
builder.Services.Configure<SQLSettings>(options => { options.ConnectionString = connectionString; });

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
