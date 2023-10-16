using MediatR;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Base.Encryption;
using RetailAdminHub.Domain.Base.Response;
using a=RetailAdminHub.Domain.Entities;


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
            AccountNumber = uniqueInt,
            Email = request.Email,
            Password = Md5.Create(request.Password.ToUpper()),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "admin"
           
        });
        await accountWriteRepository.SaveAsync();
        return new ApiResponse<CreateAccountCommandResponse>(true);
    }
}
