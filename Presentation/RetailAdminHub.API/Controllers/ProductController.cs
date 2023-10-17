using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.Product.CreateProduct;
using RetailAdminHub.Application.Features.Command.Product.PatchProduct;
using RetailAdminHub.Application.Features.Command.Product.RemoveProduct;
using RetailAdminHub.Application.Features.Command.Product.UpdateProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Domain.Base.Response;

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
    [Authorize(Roles = "admin")]
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
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<CreateProductCommandResponse>> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        return  await mediator.Send(createProductCommandRequest);
    }
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<UpdateProductCommandResponse>> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
    {
        return await mediator.Send(updateProductCommandRequest);
    }
    [HttpPatch("{id}")]
    public async Task<ApiResponse<PatchProductCommandResponse>> Patch(string id, [FromBody] JsonPatchDocument<PatchProductCommandRequest> patch)
    {
        var command = new PatchProductCommandRequest
        {
            Id = id,
            PatchDocument = patch // Store JsonPatchDocument in PatchProductCommandRequest
        };
        return await mediator.Send(command);
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ApiResponse<RemoveProductCommandResponse>> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
    {
        return await mediator.Send(removeProductCommandRequest);
    }
}
/*  ---- Patch Method --- 
Example patch request bodys, You can use the sample request bodys code below
you can just update(replace) 

1.name property update patch method request body

[
  {
    "op": "replace",
    "path": "name",
    "value": "NVDIA 4090 GPU"
  }
]

2.stock property update patch method request body

[
  {
    "op": "replace",
    "path": "stock",
    "value": 22
  }
]

3.price property update patch method request body

[
  {
    "op": "replace",
    "path": "price",
    "value": 33.5
  }
]
 */
