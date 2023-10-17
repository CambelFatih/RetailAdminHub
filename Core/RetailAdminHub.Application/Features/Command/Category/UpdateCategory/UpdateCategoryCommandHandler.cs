using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, ApiResponse<UpdateCategoryCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryReadRepository.GetByIdAsync(request.Id,cancellationToken);

        if (category == null)
            return new ApiResponse<UpdateCategoryCommandResponse>("Record not found", false);

        category.Name = request.Name;
        category.Description = request.Description;
        await unitOfWork.CategoryWriteRepository.SaveAsync(cancellationToken);
        return new ApiResponse<UpdateCategoryCommandResponse>(true);
    }
}

