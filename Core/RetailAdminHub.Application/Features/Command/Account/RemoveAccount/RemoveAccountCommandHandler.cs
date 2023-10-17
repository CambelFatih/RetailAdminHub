using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Response;


namespace RetailAdminHub.Application.Features.Command.Account.RemoveAccount;

public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommandRequest, ApiResponse<RemoveAccountCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public RemoveAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<RemoveAccountCommandResponse>> Handle(RemoveAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.AccountWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        return new ApiResponse<RemoveAccountCommandResponse>(result);
    }
}

