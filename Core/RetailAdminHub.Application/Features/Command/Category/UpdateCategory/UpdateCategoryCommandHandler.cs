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
        // Retrieve the category to be updated by its ID
        var category = await unitOfWork.CategoryReadRepository.GetByIdAsync(request.Id,cancellationToken);
        // Check if the category exists
        if (category == null)
            return new ApiResponse<UpdateCategoryCommandResponse>("Record not found", false);
        // Update category properties with the values from the request
        category.Name = request.Name;
        category.Description = request.Description;
        // Save the updated category
        await unitOfWork.CategoryWriteRepository.SaveAsync(cancellationToken);
        // Return a response indicating a successful update
        return new ApiResponse<UpdateCategoryCommandResponse>(true);
    }
}

