using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[Authorize]
public class HomeController : ApiController
{
    [HttpGet]
    public IActionResult List()
    {
        return Ok(Array.Empty<string>());
    }
}
