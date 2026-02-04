using Microsoft.AspNetCore.Mvc;

namespace CreditCardGlobalTransfer.Presentation.Controllers;

[ApiController]
[Route("api")]
public class HelloWorldController: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}