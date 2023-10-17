using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;
using RetailAdminHub.Application.Features.Command.Account.RemoveAccount;
using RetailAdminHub.Application.Features.Command.Account.UpdateAccount;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;
using RetailAdminHub.Domain.Base.Response;
using System.Data;

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
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Get()
    {
        var getAllAccountQueryRequest = new GetAllAccountQueryRequest();
        return await mediator.Send(getAllAccountQueryRequest);
    }
    [HttpGet("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<GetByIdAccountQueryResponse>> Get([FromRoute] GetByIdAccountQueryRequest getByIdAccountQueryRequest)
    {
        return await mediator.Send(getByIdAccountQueryRequest);
    }
    [HttpPost]
    public async Task<ApiResponse<CreateAccountCommandResponse>> Post(CreateAccountCommandRequest createAccountCommandRequest)
    {
        return await mediator.Send(createAccountCommandRequest);
    }
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<UpdateAccountCommandResponse>> Put([FromBody] UpdateAccountCommandRequest updateAccountCommandRequest)
    {
        return await mediator.Send(updateAccountCommandRequest);
    }
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveAccountCommandResponse>> Delete([FromRoute] RemoveAccountCommandRequest removeAccountCommandRequest)
    {
        return await mediator.Send(removeAccountCommandRequest);
    }
}

