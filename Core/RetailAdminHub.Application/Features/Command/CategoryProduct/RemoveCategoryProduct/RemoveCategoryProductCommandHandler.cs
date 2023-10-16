using MediatR;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.RemoveCategoryProduct;

public class RemoveCategoryProductCommandHandler : IRequestHandler<RemoveCategoryProductCommandRequest, ApiResponse<RemoveCategoryProductCommandResponse>>
{
    private readonly IProductWriteRepository productWriteRepository;

    public RemoveCategoryProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        this.productWriteRepository = productWriteRepository;
    }

    public async Task<ApiResponse<RemoveCategoryProductCommandResponse>> Handle(RemoveCategoryProductCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // RemoveProductCategoryRelationAsync fonksiyonunu çağırarak işlemi gerçekleştir
            bool success = await productWriteRepository.RemoveProductCategoryRelationAsync(request.ProductId, request.CategoryId);

            if (success)
            {
                return new ApiResponse<RemoveCategoryProductCommandResponse>("CategoryProduct relation successfully removed.",true);
            }
            else
            {
                return new ApiResponse<RemoveCategoryProductCommandResponse>("Failed to remove CategoryProduct relation.");
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<RemoveCategoryProductCommandResponse>(ex.Message);
        }
    }
}

