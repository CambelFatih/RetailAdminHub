using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQueryRequest, ApiResponse<List<GetAllAccountQueryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllAccountQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GetAllAccountQueryResponse>>> Handle(GetAllAccountQueryRequest request, CancellationToken cancellationToken)
    {
        var account = await unitOfWork.AccountReadRepository.GetAll(false).Where(x => x.IsActive).ToListAsync(cancellationToken);
        List<GetAllAccountQueryResponse> mapped = mapper.Map<List<GetAllAccountQueryResponse>>(account);
        return new ApiResponse<List<GetAllAccountQueryResponse>>(mapped);
    }
}
