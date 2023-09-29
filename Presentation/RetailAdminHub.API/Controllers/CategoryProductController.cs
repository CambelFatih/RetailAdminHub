using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;

namespace RetailAdminHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        readonly private IMediator _mediator;
        public CategoryProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("deneme")]
        public async Task<IActionResult> Post(CreateCategoryProductCommandRequest createCategoryProductCommandRequest)
        {
            CreateCategoryProductCommandResponse response = await _mediator.Send(createCategoryProductCommandRequest);
            return Ok(response);
            // return Ok(_productReadRepository.GetAll(false));
        }
    }
}
