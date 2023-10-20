using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryRequest : IRequest<ApiResponse<GetByIdAccountQueryResponse>>
{
    public string Id { get; set; } = string.Empty;
}

