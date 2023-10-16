using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryRequest : IRequest<ApiResponse<List<GetAllCategoryQueryResponse>>>
{
}

