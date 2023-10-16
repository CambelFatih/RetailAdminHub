using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.API.Extensions.Middleware;
using RetailAdminHub.Application.Features.Command.Token.CreateToken;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private IMediator mediator;

    public TokenController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ApiResponse<CreateTokenCommandResponse>> Post([FromBody] CreateTokenCommandRequest createTokenCommandRequest)
    {
        return await mediator.Send(createTokenCommandRequest);
    }
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