using Microsoft.AspNetCore.Mvc;
using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

namespace StressTestImdb.Web.Controllers;

[ApiController]
[Route("odata/[controller]")]
public class TestOdataController(ImdbContext context) : ODataController
{
    [EnableQuery]
    public IQueryable<NameBasics> GetNameBasics() => context.NameBasics;

    [EnableQuery]
    public IQueryable<TitleAkas> GetTitleAkas() => context.TitleAkas;

    [EnableQuery]
    public IQueryable<TitleBasics> GetTitleBasics() => context.TitleBasics;

    [EnableQuery]
    public IQueryable<TitleCrew> GetTitleCrew() => context.TitleCrew;

    [EnableQuery]
    public IQueryable<TitleEpisode> GetTitleEpisode() => context.TitleEpisode;

    [EnableQuery]
    public IQueryable<TitlePrincipals> GetTitlePrincipals() => context.TitlePrincipals;

    [EnableQuery]
    public IQueryable<TitleRating> GetTitleRatings() => context.TitleRatings;
}