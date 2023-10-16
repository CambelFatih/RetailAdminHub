using MediatR;
using RetailAdminHub.Application.Features.Command.Product.UpdateProduct;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Command.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, ApiResponse<UpdateCategoryCommandResponse>>
{
    private readonly ICategoryReadRepository categoryReadRepository;
    private readonly ICategoryWriteRepository categoryWriteRepository;

    public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
    {
        this.categoryReadRepository = categoryReadRepository;
        this.categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<ApiResponse<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryReadRepository.GetByIdAsync(request.Id,cancellationToken);

        if (category == null)
            return new ApiResponse<UpdateCategoryCommandResponse>("Record not found", false);

        category.Name = request.Name;
        category.Description = request.Description;
        await categoryWriteRepository.SaveAsync(cancellationToken);
        return new ApiResponse<UpdateCategoryCommandResponse>(true);
    }
}

