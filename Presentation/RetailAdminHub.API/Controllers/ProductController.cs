using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Product.CreateProduct;
using RetailAdminHub.Application.Features.Command.Product.RemoveProduct;
using RetailAdminHub.Application.Features.Command.Product.UpdateProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Domain.Base.Response;
using System.Net;

namespace RetailAdminHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    readonly IMediator mediator;
    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet]
    public async Task<ApiResponse<GetAllProductQueryResponse>> Get([FromRoute] GetAllProductQueryRequest getAllProductQueryRequest) 
    {
        return  await mediator.Send(getAllProductQueryRequest);
    }
    [HttpGet("{Id}")]
    public async Task<ApiResponse<GetByIdProductQueryResponse>> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
    {
        return await mediator.Send(getByIdProductQueryRequest);
    }

    [HttpPost]
    public async Task<ApiResponse<CreateProductCommandResponse>> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        return  await mediator.Send(createProductCommandRequest);
    }
    [HttpPut]
    public async Task<ApiResponse<UpdateProductCommandResponse>> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
    {
        return await mediator.Send(updateProductCommandRequest);
    }
    [HttpDelete("{Id}")]
    public async Task<ApiResponse<RemoveProductCommandResponse>> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
    {
        return await mediator.Send(removeProductCommandRequest);
    }
}


