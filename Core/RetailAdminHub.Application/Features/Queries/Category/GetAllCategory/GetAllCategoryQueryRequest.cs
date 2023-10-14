using MediatR;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryRequest : IRequest<ApiResponse<GetAllCategoryQueryResponse>>
{
}

