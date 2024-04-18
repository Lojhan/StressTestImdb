using Microsoft.EntityFrameworkCore;
using StressTestImdb.Persistence.Database;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using StressTestImdb.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<NameBasics>("NameBasics");
modelBuilder.EntitySet<TitleAkas>("TitleAkas");
modelBuilder.EntitySet<TitleBasics>("TitleBasics");
modelBuilder.EntitySet<TitleCrew>("TitleCrew");
modelBuilder.EntitySet<TitleEpisode>("TitleEpisode");
modelBuilder.EntitySet<TitlePrincipals>("TitlePrincipals");
modelBuilder.EntitySet<TitleRating>("TitleRatings");

builder.Services.AddDbContext<ImdbContext>(options => options.UseSqlServer(connectionString));
if (builder.Environment.IsDevelopment()) ImdbContext.MigrateAndSeed(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// map controllers and add odata

builder.Services.AddControllers()
    .AddOData(opt =>
    {
        opt.Count();
        opt.Filter();
        opt.OrderBy();
        opt.Expand();
        opt.Select();
        opt.SetMaxTop(100);

        IEdmModel model = modelBuilder.GetEdmModel();
        opt.AddRouteComponents("odata", model);
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
