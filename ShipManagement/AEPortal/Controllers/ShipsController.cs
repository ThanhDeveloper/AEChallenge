using AEPortal.Bussiness.ResponseModel;
using AEPortal.Bussiness.Services;
using AEPortal.Bussiness.ViewModel;
using AEPortal.Common.Models;
using AEPortal.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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

    [SwaggerOperation(Summary = "Retrieve a list of all ships")]
    [Produces(typeof(CustomResponseDto<PageList<ShipResponseDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetShips([FromQuery] ShipSearchViewModel shipSearchViewModel)
    {
        var result = await _shipService.GetShips(shipSearchViewModel);
        return Ok(CustomResponseDto<PageList<ShipResponseDto>>.SuccessResponse(StatusCodes.Status200OK, result));
    }

    [SwaggerOperation(Summary = "Create a ship by providing ship details")]
    [Produces(typeof(CustomResponseDto<Ship>))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShipCreateViewModel shipCreateViewModel)
    {
        var result = await _shipService.Create(shipCreateViewModel);
        return Ok(CustomResponseDto<Ship>.SuccessResponse(StatusCodes.Status200OK, result));
    }

    [SwaggerOperation(Summary = "Update the velocity of a ship by providing the ship's unique identifier")]
    [HttpPut("{id}/velocity")]
    [SwaggerResponse(statusCode:204)]
    public async Task<IActionResult> Update([FromBody] ShipUpdateViewModel shipUpdateViewModel, Guid id)
    {
        await _shipService.Update(shipUpdateViewModel, id);
        return NoContent();
    }
}