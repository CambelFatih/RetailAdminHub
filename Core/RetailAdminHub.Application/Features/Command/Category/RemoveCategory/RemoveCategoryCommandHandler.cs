

using MediatR;
using RetailAdminHub.Application.Features.Command.Product.RemoveProduct;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.RemoveCategory;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, ApiResponse<RemoveCategoryCommandResponse>>
{
    private readonly ICategoryWriteRepository categoryWriteRepository;

    public RemoveCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        this.categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<ApiResponse<RemoveCategoryCommandResponse>> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await categoryWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        return new ApiResponse<RemoveCategoryCommandResponse>(result);
    }
}

