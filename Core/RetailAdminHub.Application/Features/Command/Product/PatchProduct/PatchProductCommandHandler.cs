using AutoMapper;
using MediatR;
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
                // Retrieve the product to be patched by its ID
                var product = await unitOfWork.ProductReadRepository.GetByIdAsync(request.Id, cancellationToken);
                // Check if the product exists
                if (product == null)
                    return new ApiResponse<PatchProductCommandResponse>("Record not found", false);
                // Check if the patch document is valid
                if (request.PatchDocument == null)
                    return new ApiResponse<PatchProductCommandResponse>("BadRequest", false);
                // Map the existing product to a DTO for patching
                var PatchProductCommandRequestDTO = mapper.Map<PatchProductCommandRequest>(product);
                // Apply the patch document to the DTO
                request.PatchDocument.ApplyTo(PatchProductCommandRequestDTO);

                // Apply changes from the DTO back to the product
                product.Name = PatchProductCommandRequestDTO.Name;
                product.Stock = PatchProductCommandRequestDTO.Stock;
                product.Price = PatchProductCommandRequestDTO.Price;
                // Save the updated product
                await unitOfWork.ProductWriteRepository.SaveAsync(cancellationToken);
                transaction.Commit();
                // Return a response indicating a successful patch
                return new ApiResponse<PatchProductCommandResponse>(true);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the patching process
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
    "path": "name",
    "value": "4090 GPU"
  }
]
 */
