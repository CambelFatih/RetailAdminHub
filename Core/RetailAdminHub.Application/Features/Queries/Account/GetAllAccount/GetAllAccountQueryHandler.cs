using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQueryRequest, ApiResponse<List<GetAllAccountQueryResponse>>>
{
    private readonly IAccountReadRepository accountReadRepository;
    private readonly IMapper mapper;

    public GetAllAccountQueryHandler(IAccountReadRepository accountReadRepository, IMapper mapper)
    {
        this.accountReadRepository = accountReadRepository;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Handle(GetAllAccountQueryRequest request, CancellationToken cancellationToken)
    {
        var account = await accountReadRepository.GetAll(false).Where(x => x.IsActive).ToListAsync(cancellationToken);
        List<GetAllAccountQueryResponse> mapped = mapper.Map<List<GetAllAccountQueryResponse>>(account);
        return new ApiResponse<List<GetAllAccountQueryResponse>>(mapped);
    }
}
