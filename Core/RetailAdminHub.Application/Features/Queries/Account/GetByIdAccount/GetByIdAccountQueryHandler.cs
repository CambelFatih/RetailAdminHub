using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQueryRequest, ApiResponse<GetByIdAccountQueryResponse>>
{
    private readonly IMapper mapper;
    private readonly IAccountReadRepository accountReadRepository;

    public GetByIdAccountQueryHandler(IMapper mapper, IAccountReadRepository accountReadRepository)
    {
        this.mapper = mapper;
        this.accountReadRepository = accountReadRepository;
    }

    public async Task<ApiResponse<GetByIdAccountQueryResponse>> Handle(GetByIdAccountQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await accountReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
            return new ApiResponse<GetByIdAccountQueryResponse>("Record not found", false);

        var mapped = mapper.Map<GetByIdAccountQueryResponse>(category);
        return new ApiResponse<GetByIdAccountQueryResponse>(mapped);
    }
}

