using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryRequest : IRequest<ApiResponse<List<GetAllAccountQueryResponse>>>
{
}

