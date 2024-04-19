using Microsoft.EntityFrameworkCore;
using StressTestImdb.Persistence.Database;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using StressTestImdb.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<TitleAkas>("TitleAkas").EntityType.HasKey(x => new { x.TitleId, x.Ordering });
modelBuilder.EntitySet<TitleBasics>("TitleBasics").EntityType.HasKey(x => x.Tconst);
modelBuilder.EntitySet<TitleCrew>("TitleCrew").EntityType.HasKey(x => x.Tconst);
modelBuilder.EntitySet<TitleEpisode>("TitleEpisode").EntityType.HasKey(x => new { x.Tconst, x.ParentTconst, x.SeasonNumber, x.EpisodeNumber });
modelBuilder.EntitySet<TitlePrincipals>("TitlePrincipals").EntityType.HasKey(x => new { x.Tconst, x.Nconst });
modelBuilder.EntitySet<TitleRating>("TitleRatings").EntityType.HasKey(x => x.Tconst);

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

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
