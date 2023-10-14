using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;
using RetailAdminHub.Application.Features.Command.Account.RemoveAccount;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
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
    [HttpGet]
    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Get()
    {
        var getAllAccountQueryRequest = new GetAllAccountQueryRequest();
        return await mediator.Send(getAllAccountQueryRequest);
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

