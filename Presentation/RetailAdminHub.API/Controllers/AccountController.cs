using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;
using RetailAdminHub.Application.Features.Command.Account.RemoveAccount;
using RetailAdminHub.Application.Features.Command.Account.UpdateAccount;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.API.Controllers;
/// <summary>
/// Controller for managing account-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    readonly private IMediator mediator;

    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    /// <summary>
    /// Retrieves a list of all accounts.
    /// </summary>
    /// <returns>A response containing the list of accounts.</returns>
    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Get()
    {
        var getAllAccountQueryRequest = new GetAllAccountQueryRequest();
        return await mediator.Send(getAllAccountQueryRequest);
    }
    /// <summary>
    /// Retrieves an account by its ID.
    /// </summary>
    /// <param name="getByIdAccountQueryRequest">The request to get an account by ID.</param>
    /// <returns>A response containing the account information.</returns>
    [HttpGet("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<GetByIdAccountQueryResponse>> Get([FromRoute] GetByIdAccountQueryRequest getByIdAccountQueryRequest)
    {
        return await mediator.Send(getByIdAccountQueryRequest);
    }
    /// <summary>
    /// Creates a new account.
    /// </summary>
    /// <param name="createAccountCommandRequest">The request to create a new account.</param>
    /// <returns>A response containing the result of the account creation.</returns>
    [HttpPost]
    public async Task<ApiResponse<CreateAccountCommandResponse>> Post(CreateAccountCommandRequest createAccountCommandRequest)
    {
        return await mediator.Send(createAccountCommandRequest);
    }
    /// <summary>
    /// Updates an existing account.
    /// </summary>
    /// <param name="updateAccountCommandRequest">The request to update an account.</param>
    /// <returns>A response containing the result of the account update.</returns>
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<UpdateAccountCommandResponse>> Put([FromBody] UpdateAccountCommandRequest updateAccountCommandRequest)
    {
        return await mediator.Send(updateAccountCommandRequest);
    }
    /// <summary>
    /// Removes an account by its ID.
    /// </summary>
    /// <param name="removeAccountCommandRequest">The request to remove an account by ID.</param>
    /// <returns>A response containing the result of the account removal.</returns>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveAccountCommandResponse>> Delete([FromRoute] RemoveAccountCommandRequest removeAccountCommandRequest)
    {
        return await mediator.Send(removeAccountCommandRequest);
    }
}

