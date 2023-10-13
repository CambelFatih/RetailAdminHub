using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;
using RetailAdminHub.Domain.Response;

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
    [HttpPost("deneme")]
    public async Task<ApiResponse<CreateCategoryProductCommandResponse>> Post(CreateCategoryProductCommandRequest createCategoryProductCommandRequest)
    {
        return await mediator.Send(createCategoryProductCommandRequest);
    }
}

