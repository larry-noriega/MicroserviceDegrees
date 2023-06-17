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

builder.Services.AddDbContext<PersonDBContext>();

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

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PersonDBContext>();

    db.Database.EnsureDeleted();
    db.Database.Migrate();

    SeedData.Initialize(db);    
}

app.Run();
