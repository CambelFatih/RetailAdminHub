using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.PatchProduct;

public class PatchProductCommandHandler : IRequestHandler<PatchProductCommandRequest, ApiResponse<PatchProductCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PatchProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<PatchProductCommandResponse>> Handle(PatchProductCommandRequest request, CancellationToken cancellationToken)
    {
        using (var transaction = unitOfWork.BeginTransaction())
        {
            try
            {
                var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.Id, cancellationToken);

                if (product == null)
                    return new ApiResponse<PatchProductCommandResponse>("Record not found", false);
                if (request.PatchDocument == null)
                    return new ApiResponse<PatchProductCommandResponse>("BadRequest", false);

                var PatchProductCommandRequestDTO = mapper.Map<PatchProductCommandRequest>(product);
                request.PatchDocument.ApplyTo(PatchProductCommandRequestDTO);

                // Apply changes to the product
                product.Name = PatchProductCommandRequestDTO.Name;
                product.Stock = PatchProductCommandRequestDTO.Stock;
                product.Price = PatchProductCommandRequestDTO.Price;

                await unitOfWork.ProductWriteRepository.SaveAsync(cancellationToken);
                transaction.Commit();

                return new ApiResponse<PatchProductCommandResponse>(true);
            }
            catch (Exception ex)
            {
                // Handle the exception
                transaction.Rollback();
                return new ApiResponse<PatchProductCommandResponse>($"An error occurred: {ex.Message}", false);
            }
        }
    }
}

/*
 [
  {
    "op": "replace",
    "path": "/user/name",
    "value": "Jane Doe"
  }
]

 */

//[HttpPatch("{id:int}")]
//public async Task<ActionResult> Patch(int id, JsonPatchDocument<LibroPatchDTO> patchDocument)
//{
//    if (patchDocument == null)
//    {
//        return BadRequest();
//    }

//    var libroDB = await context.Libros.FirstOrDefaultAsync(x => x.Id == id);

//    if (libroDB == null)
//    {
//        return NotFound();
//    }

//    var libroDTO = mapper.Map<LibroPatchDTO>(libroDB);

//    patchDocument.ApplyTo(libroDTO, ModelState);

//    var esValido = TryValidateModel(libroDTO);

//    if (!esValido)
//    {
//        return BadRequest(ModelState);
//    }

//    mapper.Map(libroDTO, libroDB);

//    await context.SaveChangesAsync();
//    return NoContent();
//}