using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Category.CreateCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;
using RetailAdminHub.Application.Features.Command.Category.UpdateCategory;
using RetailAdminHub.Application.Features.Command.Category.RemoveCategory;
using RetailAdminHub.Domain.Base.Response;
using Microsoft.AspNetCore.Authorization;

namespace RetailAdminHub.API.Controllers;
/// <summary>
/// Controller for managing product categories.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    readonly private IMediator mediator;
    public CategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    /// <summary>
    /// Retrieves a list of all product categories.
    /// </summary>
    /// <returns>A response containing the list of categories.</returns>
    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<List<GetAllCategoryQueryResponse>>> Get()
    {
        GetAllCategoryQueryRequest getAllCategoryQueryRequest = new GetAllCategoryQueryRequest();
        return await mediator.Send(getAllCategoryQueryRequest);
    }
    /// <summary>
    /// Creates a new product category.
    /// </summary>
    /// <param name="createCategoryCommandRequest">The request to create a new category.</param>
    /// <returns>A response containing the result of the category creation.</returns>
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreateCategoryCommandResponse>> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
    {
        return await mediator.Send(createCategoryCommandRequest);
    }
    /// <summary>
    /// Retrieves a product category by its ID.
    /// </summary>
    /// <param name="getByIdCategoryQueryRequest">The request to get a category by ID.</param>
    /// <returns>A response containing the category information.</returns>
    [HttpGet("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<GetByIdCategoryQueryResponse>> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
    {
        return await mediator.Send(getByIdCategoryQueryRequest);
    }
    /// <summary>
    /// Updates an existing product category.
    /// </summary>
    /// <param name="updateCategoryCommandRequest">The request to update a category.</param>
    /// <returns>A response containing the result of the category update.</returns>
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<UpdateCategoryCommandResponse>> Put([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
    {
        return await mediator.Send(updateCategoryCommandRequest);
    }
    /// <summary>
    /// Removes a product category by its ID.
    /// </summary>
    /// <param name="removeCategoryCommandRequest">The request to remove a category by ID.</param>
    /// <returns>A response containing the result of the category removal.</returns>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveCategoryCommandResponse>> Delete([FromRoute] RemoveCategoryCommandRequest removeCategoryCommandRequest)
    {
        return await mediator.Send(removeCategoryCommandRequest);
    }
}

