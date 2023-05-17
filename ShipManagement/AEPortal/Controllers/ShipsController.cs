using AEPortal.Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AEPortal.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipsController : BaseController
{
    private readonly IShipService _shipService;

    public ShipsController(IShipService shipService)
    {
        _shipService = shipService;
    }

    [SwaggerOperation(Summary = "Get all ship")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}