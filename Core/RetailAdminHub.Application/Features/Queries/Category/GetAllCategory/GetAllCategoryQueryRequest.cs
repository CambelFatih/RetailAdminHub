using MediatR;
using RetailAdminHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<GetAllCategoryQueryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
