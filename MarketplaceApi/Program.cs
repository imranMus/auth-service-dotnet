using Microsoft.EntityFrameworkCore;
using MarketplaceApi.Data;

var builder = WebApplication.CreateBuilder(args);

var dbHost = builder.Configuration["DB_HOST"];
var dbPort = builder.Configuration["DB_PORT"] ?? "5432";
var dbName = builder.Configuration["DB_NAME"];
var dbUser = builder.Configuration["DB_USER"];
var dbPassword = builder.Configuration["DB_PASSWORD"];

if (string.IsNullOrWhiteSpace(dbHost) ||
    string.IsNullOrWhiteSpace(dbName) ||
    string.IsNullOrWhiteSpace(dbUser) ||
    string.IsNullOrWhiteSpace(dbPassword))
{
    throw new Exception("Database user secrets are missing.");
}

var connectionString =
    $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();