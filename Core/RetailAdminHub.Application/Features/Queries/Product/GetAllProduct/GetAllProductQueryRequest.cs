using MediatR;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<ApiResponse<GetAllProductQueryResponse>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 10;
    }
}
