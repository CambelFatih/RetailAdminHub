using MediatR;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQueryRequest, ApiResponse<GetByIdAccountQueryResponse>>
{
    public Task<ApiResponse<GetByIdAccountQueryResponse>> Handle(GetByIdAccountQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

