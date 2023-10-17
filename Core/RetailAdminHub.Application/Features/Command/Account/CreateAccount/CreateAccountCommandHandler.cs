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
        request.Password = Md5.Control(request.Password.ToUpper());
        await accountWriteRepository.AddAsync(new()
        {
            AccountNumber = uniqueInt,
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "admin"
           
        });
        await accountWriteRepository.SaveAsync();
        var response = new CreateAccountCommandResponse()
        {
            AccountNumber = uniqueInt
        };
        return new ApiResponse<CreateAccountCommandResponse>(response);
    }
}
