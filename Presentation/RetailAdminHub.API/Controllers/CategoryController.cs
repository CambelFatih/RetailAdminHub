using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Category.CreateCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;
using System.Net;
using RetailAdminHub.Domain.Response;

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
    public async Task<ApiResponse<GetAllCategoryQueryResponse>> Get([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
    {
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
}

