using MediatR;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Response;


namespace RetailAdminHub.Application.Features.Command.Account.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommandRequest, ApiResponse<CreateAccountCommandResponse>>
{
    private readonly IAccountWriteRepository accountWriteRepository;

    public CreateAccountCommandHandler(IAccountWriteRepository accountWriteRepository)
    {
        this.accountWriteRepository = accountWriteRepository;
    }

    public async Task<ApiResponse<CreateAccountCommandResponse>> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        int uniqueInt = rnd.Next();
        await accountWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            AccountNumber = uniqueInt,
            Balance = request.Balance,
            OpenDate = DateTime.UtcNow,
            IsActive = true,
        });
        await accountWriteRepository.SaveAsync();
        return new ApiResponse<CreateAccountCommandResponse>(true);
    }
}
