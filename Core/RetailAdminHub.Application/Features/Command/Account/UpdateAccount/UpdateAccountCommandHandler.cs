using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Account.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommandRequest, ApiResponse<UpdateAccountCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public UpdateAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<UpdateAccountCommandResponse>> Handle(UpdateAccountCommandRequest request, CancellationToken cancellationToken)
    {
        // Retrieve the account to be updated by its ID
        var category = await unitOfWork.AccountReadRepository.GetByIdAsync(request.Id, cancellationToken);
        // Check if the account exists
        if (category == null)
            return new ApiResponse<UpdateAccountCommandResponse>("Record not found", false);
        // Update account properties if the request values are not "string"
        if (request.Email != null && request.Email != "string")
            category.Email = request.Email;
        if (request.Password != null && request.Password != "string")
            category.Password = request.Password;
        if (request.FirstName != null && request.FirstName != "string")
            category.FirstName = request.FirstName;
        if (request.LastName != null && request.LastName != "string")
            category.LastName = request.LastName;
        // Save the updated account
        await unitOfWork.AccountWriteRepository.SaveAsync(cancellationToken);
        // Return a response indicating a successful update
        return new ApiResponse<UpdateAccountCommandResponse>(true);
    }
}