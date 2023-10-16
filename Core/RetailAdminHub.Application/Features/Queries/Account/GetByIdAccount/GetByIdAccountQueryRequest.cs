using MediatR;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryRequest : IRequest<ApiResponse<GetByIdAccountQueryResponse>>
{
    public string Id { get; set; }
}

