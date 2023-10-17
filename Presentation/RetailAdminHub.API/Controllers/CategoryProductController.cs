using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;
using RetailAdminHub.Application.Features.Command.CategoryProduct.RemoveCategoryProduct;
using RetailAdminHub.Domain.Base.Response;
using System.Data;

namespace RetailAdminHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryProductController : ControllerBase
{
    readonly private IMediator mediator;
    public CategoryProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost("Create/{ProductId}/{CategoryId}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreateCategoryProductCommandResponse>> CratePost([FromRoute] CreateCategoryProductCommandRequest createCategoryProductCommandRequest)
    {
        return await mediator.Send(createCategoryProductCommandRequest);
    }
    [HttpPost("Remove/{ProductId}/{CategoryId}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveCategoryProductCommandResponse>> Post([FromRoute] RemoveCategoryProductCommandRequest removeCategoryProductCommandRequest)
    {
        return await mediator.Send(removeCategoryProductCommandRequest);
    }
}

