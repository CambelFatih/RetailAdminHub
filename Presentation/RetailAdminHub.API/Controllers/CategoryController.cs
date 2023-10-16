using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Category.CreateCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;
using RetailAdminHub.Domain.Response;
using RetailAdminHub.Application.Features.Command.Category.UpdateCategory;
using RetailAdminHub.Application.Features.Command.Category.RemoveCategory;

namespace RetailAdminHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    readonly private IMediator mediator;
    public CategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<List<GetAllCategoryQueryResponse>>> Get()
    {
        GetAllCategoryQueryRequest getAllCategoryQueryRequest = new GetAllCategoryQueryRequest();
        return await mediator.Send(getAllCategoryQueryRequest);
    }
    [HttpPost]
    public async Task<ApiResponse<CreateCategoryCommandResponse>> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
    {
        return await mediator.Send(createCategoryCommandRequest);
    }
    [HttpGet("{Id}")]
    public async Task<ApiResponse<GetByIdCategoryQueryResponse>> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
    {
        return await mediator.Send(getByIdCategoryQueryRequest);
    }
    [HttpPut]
    public async Task<ApiResponse<UpdateCategoryCommandResponse>> Put([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
    {
        return await mediator.Send(updateCategoryCommandRequest);
    }
    [HttpDelete("{Id}")]
    public async Task<ApiResponse<RemoveCategoryCommandResponse>> Delete([FromRoute] RemoveCategoryCommandRequest removeCategoryCommandRequest)
    {
        return await mediator.Send(removeCategoryCommandRequest);
    }
}

