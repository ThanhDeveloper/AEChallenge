using AEPortal.Bussiness.ResponseModel;
using AEPortal.Bussiness.Services;
using AEPortal.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AEPortal.Controllers;

[ApiController]
[Route("[controller]")]
public class PortsController : BaseController
{
    private readonly IPortService _PortService;

    public PortsController(IPortService PortService)
    {
        _PortService = PortService;
    }

    [SwaggerOperation(Summary = "Retrieve a list of all Ports")]
    [Produces(typeof(CustomResponseDto<ClosestPortResponse>))]
    [HttpGet("{shipId}/closest-port")]
    public async Task<IActionResult> GetClosestPort(Guid shipId)
    {
        var result = await _PortService.GetClosestPort(shipId);
        return Ok(CustomResponseDto<ClosestPortResponse>.SuccessResponse(StatusCodes.Status200OK, result));
    }
}