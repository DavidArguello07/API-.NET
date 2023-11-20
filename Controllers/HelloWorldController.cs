using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api2/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloworldService helloworldServices;
    private readonly ILogger<HelloWorldController> _logger;
    //Recibir la dependencia de IHelloworldService a través del constructor
    public HelloWorldController(IHelloworldService helloworld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        // this.helloworldServices = helloworld;
        helloworldServices = helloworld;
    }
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Logging from Get(). Hi!");
        return Ok(helloworldServices.GetHelloWorld());
    }

    // [Route("get/bye")]
    // public IActionResult GetBye()
    // {
    //     _logger.LogDebug("Saying goodbye @ GetBye()");
    //     return Ok(helloworldServices.GetByeWorld());
    // }
}