using MediatR;
using RetailAdminHub.Domain.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<ApiResponse<GetByIdProductQueryResponse>>
    {
        public string Id { get; set; }
    }
}
