using Microsoft.EntityFrameworkCore;
using StressTestImdb.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<ImdbContext>(options => options.UseSqlServer(connectionString));
if (builder.Environment.IsDevelopment()) ImdbContext.MigrateAndSeed(connectionString);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
