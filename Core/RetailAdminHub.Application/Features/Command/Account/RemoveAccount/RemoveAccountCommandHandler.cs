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
        // Call the SoftDeleteById method to mark an account for deletion (soft delete).
        var result = await unitOfWork.AccountWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        if(result==false)
            return new ApiResponse<RemoveAccountCommandResponse>("Record not found", false);
        // Create an ApiResponse with the result of the removal operation.
        return new ApiResponse<RemoveAccountCommandResponse>(result);
    }
}

