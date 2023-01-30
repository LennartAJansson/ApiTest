namespace WeatherForecastApiWithApiKey.Controllers;
using Microsoft.AspNetCore.Mvc;

using WeatherForecastApiWithApiKey.Attributes;

[Route("[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [ApiKey()]
    [HttpGet]
    public Task<IActionResult> GetValues()
    {
        object response = new { Value = "This is my value" };
        return Task.FromResult((IActionResult)Ok(response));
    }
}
