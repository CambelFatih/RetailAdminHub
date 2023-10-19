using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Category.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, ApiResponse<CreateCategoryCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        // Add a new category to the repository
        await unitOfWork.CategoryWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Description = request.Description,
        });
        // Save changes to the category repository
        await unitOfWork.CategoryWriteRepository.SaveAsync();
        // Return a response indicating a successful category creation
        return new ApiResponse<CreateCategoryCommandResponse>(true);
    }
}

