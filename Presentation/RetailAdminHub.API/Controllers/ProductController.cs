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
/// <summary>
/// Controller for managing products.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    readonly IMediator mediator;
    public ProductController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    /// <summary>
    /// Retrieves a list of all products.
    /// </summary>
    /// <param name="getAllProductQueryRequest">The request to get all products.</param>
    /// <returns>A response containing the list of products.</returns>
    [HttpGet("{Page}/{Size}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Get([FromRoute] GetAllProductQueryRequest getAllProductQueryRequest) 
    {
        var response = await mediator.Send(getAllProductQueryRequest);
        return response.Success ? Ok(response.Response) : BadRequest();
    }
    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="getByIdProductQueryRequest">The request to get a product by ID.</param>
    /// <returns>A response containing the product information.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
    {
        var response = await mediator.Send(getByIdProductQueryRequest);
        return response.Success ? Ok(response.Response) : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();
    }
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="createProductCommandRequest">The request to create a new product.</param>
    /// <returns>A response containing the result of the product creation.</returns>
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        var response = await mediator.Send(createProductCommandRequest);
        return response.Success ? NoContent() : BadRequest(response.Message);
    }
    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="updateProductCommandRequest">The request to update a product.</param>
    /// <returns>A response containing the result of the product update.</returns>
    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
    {
        var response = await mediator.Send(updateProductCommandRequest);
        return response.Success ? NoContent() : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();
    }
    /// <summary>
    /// Patches an existing product based on the provided ID and patch document.
    /// </summary>
    /// <param name="id">The ID of the product to be patched.</param>
    /// <param name="patch">The JSON patch document to apply the changes.</param>
    /// <returns>A response containing the result of the product patch.</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<PatchProductCommandRequest> patch)
    {
        var command = new PatchProductCommandRequest
        {
            Id = id,
            PatchDocument = patch // Store JsonPatchDocument in PatchProductCommandRequest
        };
        var response = await mediator.Send(command);
        return response.Success ? NoContent() : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();
    }
    /// <summary>
    /// Removes a product by its ID.
    /// </summary>
    /// <param name="removeProductCommandRequest">The request to remove a product by ID.</param>
    /// <returns>A response containing the result of the product removal.</returns>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
    {
        var response = await mediator.Send(removeProductCommandRequest);
        return response.Success ? NoContent() : response.Message == "Record not found" ? NotFound(response.Message) : BadRequest();

    }
}
/* Patch Method Instructions:
   Example patch request bodies demonstrate how to update (replace) specific properties.

   1. To update the 'name' property:
      [
        {
          "op": "replace",  //It's ok even if this line isn't there
          "path": "name",
          "value": "NVDIA 4090 GPU"
        }
      ]

   2. To update the 'stock' property:
      [
        {
          "path": "stock",
          "value": 22
        }
      ]

   3. To update the 'price' property:
      [
        {
          "path": "price",
          "value": 33.5
        }
      ]
*/

