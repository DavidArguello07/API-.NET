using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloworldService helloworldServices;

    TareasContext dbcontext;
    private readonly ILogger<HelloWorldController> _logger;
    //Recibir la dependencia de IHelloworldService a través del constructor
    public HelloWorldController(TareasContext db, IHelloworldService helloworld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        // this.helloworldServices = helloworld;
        helloworldServices = helloworld;
        dbcontext = db;
    }
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Logging from Get(). Hi!");
        return Ok(helloworldServices.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {//validar si la base de datos existe
        dbcontext.Database.EnsureCreated();

        return Ok("Database created");
    }

    // [Route("get/bye")]
    // public IActionResult GetBye()
    // {
    //     _logger.LogDebug("Saying goodbye @ GetBye()");
    //     return Ok(helloworldServices.GetByeWorld());
    // }
}