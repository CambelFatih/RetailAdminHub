using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.API.Extensions.Middleware;
using RetailAdminHub.Application.Features.Command.Token.CreateToken;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Controllers;
/// <summary>
/// Controller for managing authentication tokens.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private IMediator mediator;

    public TokenController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    /// <summary>
    /// Generates a new authentication token.
    /// </summary>
    /// <param name="createTokenCommandRequest">The request to create a new authentication token.</param>
    /// <returns>A response containing the result of the token creation.</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTokenCommandRequest createTokenCommandRequest)
    {
        var response = await mediator.Send(createTokenCommandRequest);
        return response.Success ? Created("api/token", response.Response) : response.Message == "Invalid user informations" ? ValidationProblem(response.Message) : BadRequest();
    }
    /// <summary>
    /// Endpoint for testing purposes.
    /// </summary>
    /// <remarks>This endpoint is for testing and returns an empty ApiResponse.</remarks>
    [TypeFilter(typeof(LogResourceFilter))]
    [TypeFilter(typeof(LogActionFilter))]
    [TypeFilter(typeof(LogAuthorizationFilter))]
    [TypeFilter(typeof(LogResourceFilter))]
    [TypeFilter(typeof(LogExceptionFilter))]
    [HttpGet("Test")]
    public ApiResponse Get()
    {
        return new ApiResponse();
    }
}