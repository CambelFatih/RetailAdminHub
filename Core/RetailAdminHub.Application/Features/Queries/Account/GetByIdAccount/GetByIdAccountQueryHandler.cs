using AutoMapper;
using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQueryRequest, ApiResponse<GetByIdAccountQueryResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GetByIdAccountQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<GetByIdAccountQueryResponse>> Handle(GetByIdAccountQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.AccountReadRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
            return new ApiResponse<GetByIdAccountQueryResponse>("Record not found", false);

        var mapped = mapper.Map<GetByIdAccountQueryResponse>(category);
        return new ApiResponse<GetByIdAccountQueryResponse>(mapped);
    }
}

