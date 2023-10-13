using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;
using RetailAdminHub.Application.Features.Command.Account.RemoveAccount;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    readonly private IMediator mediator;

    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ApiResponse<CreateAccountCommandResponse>> Post(CreateAccountCommandRequest createAccountCommandRequest)
    {
        return await mediator.Send(createAccountCommandRequest);
    }
    [HttpDelete("{Id}")]
    public async Task<ApiResponse<RemoveAccountCommandResponse>> Delete([FromRoute] RemoveAccountCommandRequest removeAccountCommandRequest)
    {
        return await mediator.Send(removeAccountCommandRequest);
    }
}

