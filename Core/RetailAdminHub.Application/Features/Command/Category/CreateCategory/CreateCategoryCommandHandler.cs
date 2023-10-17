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
        await unitOfWork.CategoryWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Description = request.Description,
        });
        await unitOfWork.CategoryWriteRepository.SaveAsync();
        return new ApiResponse<CreateCategoryCommandResponse>(true);
    }
}

