using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.RemoveCategory;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, ApiResponse<RemoveCategoryCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<RemoveCategoryCommandResponse>> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        // Call the SoftDeleteById method to mark a category for deletion (soft delete).
        var result = await unitOfWork.CategoryWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        // Create an ApiResponse with the result of the removal operation.
        return new ApiResponse<RemoveCategoryCommandResponse>(result);
    }
}

