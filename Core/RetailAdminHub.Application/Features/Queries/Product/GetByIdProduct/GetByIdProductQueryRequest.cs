using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryRequest : IRequest<ApiResponse<GetByIdProductQueryResponse>>
{
    public string Id { get; set; } = string.Empty;
}

