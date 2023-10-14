using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Response;
using System.Collections.Generic;

namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQueryRequest, ApiResponse<List<GetAllAccountQueryResponse>>>
{
    //private readonly RetailAdminHubDbContext
    private readonly IAccountReadRepository accountReadRepository;
    private readonly IMapper mapper;

    public GetAllAccountQueryHandler(IAccountReadRepository accountReadRepository, IMapper mapper)
    {
        this.accountReadRepository = accountReadRepository;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Handle(GetAllAccountQueryRequest request, CancellationToken cancellationToken)
    {
        var account = accountReadRepository.GetAll(false).Where(x => x.IsActive).ToList();
        List < GetAllAccountQueryResponse > mapped= mapper.Map<List<GetAllAccountQueryResponse>>(account);
        return new ApiResponse<List<GetAllAccountQueryResponse>>(mapped);
    }
}
