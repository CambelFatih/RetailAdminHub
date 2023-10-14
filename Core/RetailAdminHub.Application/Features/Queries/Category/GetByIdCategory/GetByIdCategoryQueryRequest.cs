using MediatR;
using RetailAdminHub.Domain.Response;


namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;

public class GetByIdCategoryQueryRequest : IRequest<ApiResponse<GetByIdCategoryQueryResponse>>
{
    public string Id { get; set; }
}

