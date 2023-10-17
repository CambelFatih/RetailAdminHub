using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, ApiResponse<List<GetAllCategoryQueryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GetAllCategoryQueryResponse>>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.CategoryReadRepository.GetAll(false).Include(c => c.Products).Where(x => x.IsActive).ToListAsync(cancellationToken);
        var mapped = mapper.Map<List<GetAllCategoryQueryResponse>>(categories);
        return new ApiResponse<List<GetAllCategoryQueryResponse>>(mapped);
    }
}