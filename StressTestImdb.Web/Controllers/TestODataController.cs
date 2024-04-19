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
    [HttpGet("NameBasics")]
    public IActionResult GetNameBasics() => Ok(context.NameBasics);

    [EnableQuery]
    [HttpGet("TitleAkas")]
    public IActionResult GetTitleAkas() => Ok(context.TitleAkas);

    [EnableQuery]
    [HttpGet("TitleBasics")]
    public IActionResult GetTitleBasics() => Ok(context.TitleBasics);

    [EnableQuery]
    [HttpGet("TitleCrew")]
    public IActionResult GetTitleCrew() => Ok(context.TitleCrew);

    [EnableQuery]
    [HttpGet("TitleEpisode")]
    public IActionResult GetTitleEpisode() => Ok(context.TitleEpisode);

    [EnableQuery]
    [HttpGet("TitlePrincipals")]
    public IActionResult GetTitlePrincipals() => Ok(context.TitlePrincipals);

    [EnableQuery]
    [HttpGet("TitleRatings")]
    public IActionResult GetTitleRatings() => Ok(context.TitleRatings);

    
}