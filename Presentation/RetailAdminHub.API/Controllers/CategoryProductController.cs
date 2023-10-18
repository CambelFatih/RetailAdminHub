using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;
using RetailAdminHub.Application.Features.Command.CategoryProduct.RemoveCategoryProduct;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.API.Controllers;
/// <summary>
/// Controller for managing category-product relationships.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoryProductController : ControllerBase
{

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryProductController"/> class.
    /// </summary>
    /// <param name="mediator">The Mediator service for handling requests.</param>
    readonly private IMediator mediator;
    public CategoryProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    /// <summary>
    /// Creates a new category-product relationship.
    /// </summary>
    /// <param name="createCategoryProductCommandRequest">The request to create a category-product relationship.</param>
    /// <returns>An API response containing the result of the create operation.</returns>
    [HttpPost("Create/{ProductId}/{CategoryId}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreateCategoryProductCommandResponse>> CratePost([FromRoute] CreateCategoryProductCommandRequest createCategoryProductCommandRequest)
    {
        return await mediator.Send(createCategoryProductCommandRequest);
    }
    /// <summary>
    /// Removes an existing category-product relationship.
    /// </summary>
    /// <param name="removeCategoryProductCommandRequest">The request to remove a category-product relationship.</param>
    /// <returns>An API response containing the result of the remove operation.</returns>
    [HttpPost("Remove/{ProductId}/{CategoryId}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveCategoryProductCommandResponse>> Post([FromRoute] RemoveCategoryProductCommandRequest removeCategoryProductCommandRequest)
    {
        return await mediator.Send(removeCategoryProductCommandRequest);
    }
}

