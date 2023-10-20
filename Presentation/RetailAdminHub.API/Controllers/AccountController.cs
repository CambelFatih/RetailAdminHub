using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> Get()
    {
        var getAllAccountQueryRequest = new GetAllAccountQueryRequest();
        var response = await mediator.Send(getAllAccountQueryRequest);
        return response.Success ? Ok(response.Response) : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();
    }
    /// <summary>
    /// Retrieves an account by its ID.
    /// </summary>
    /// <param name="getByIdAccountQueryRequest">The request to get an account by ID.</param>
    /// <returns>A response containing the account information.</returns>
    [HttpGet("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Get([FromRoute] GetByIdAccountQueryRequest getByIdAccountQueryRequest)
    {
        var response = await mediator.Send(getByIdAccountQueryRequest);
        return response.Success ? Ok(response.Response) : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();
    }
    /// <summary>
    /// Creates a new account.
    /// </summary>
    /// <param name="createAccountCommandRequest">The request to create a new account.</param>
    /// <returns>A response containing the result of the account creation.</returns>
    [HttpPost]
    public async Task<IActionResult> Post(CreateAccountCommandRequest createAccountCommandRequest)
    {
        var response = await mediator.Send(createAccountCommandRequest);
        return response.Success
            ? Created("api/account/" + response.Response.AccountNumber, response.Response)
            : BadRequest(response.Message);
    }
    /// <summary>
    /// Updates an existing account.
    /// </summary>
    /// <param name="updateAccountCommandRequest">The request to update an account.</param>
    /// <returns>A response containing the result of the account update.</returns>
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Put([FromBody] UpdateAccountCommandRequest updateAccountCommandRequest)
    {
        var response = await mediator.Send(updateAccountCommandRequest);
        return response.Success ? NoContent() : response.Message == "Record not found" ? NotFound() : BadRequest();

    }
    /// <summary>
    /// Removes an account by its ID.
    /// </summary>
    /// <param name="removeAccountCommandRequest">The request to remove an account by ID.</param>
    /// <returns>A response containing the result of the account removal.</returns>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete([FromRoute] RemoveAccountCommandRequest removeAccountCommandRequest)
    {
        var response = await mediator.Send(removeAccountCommandRequest);
        return response.Success ? NoContent() : response.Message == "Record not found" ? NotFound() : BadRequest();

    }
}

