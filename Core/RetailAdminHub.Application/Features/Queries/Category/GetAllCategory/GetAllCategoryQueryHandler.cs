using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, ApiResponse<List<GetAllCategoryQueryResponse>>>
{
    private readonly ICategoryReadRepository categoryReadRepository;
    private readonly IMapper mapper;

    public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
    {
        this.categoryReadRepository = categoryReadRepository;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GetAllCategoryQueryResponse>>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoryReadRepository.GetAll(false).Include(c => c.Products).Where(x => x.IsActive).ToListAsync(cancellationToken);
        var mapped = mapper.Map<List<GetAllCategoryQueryResponse>>(categories);
        return new ApiResponse<List<GetAllCategoryQueryResponse>>(mapped);
    }
}