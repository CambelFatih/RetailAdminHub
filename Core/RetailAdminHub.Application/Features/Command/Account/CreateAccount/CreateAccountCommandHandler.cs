using MediatR;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Domain.Base.Encryption;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Account.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommandRequest, ApiResponse<CreateAccountCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;

    public CreateAccountCommandHandler( IUnitOfWork unitOfWork) 
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CreateAccountCommandResponse>> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        int uniqueInt = rnd.Next();
        request.Password = Md5.Control(request.Password.ToUpper());
        await unitOfWork.AccountWriteRepository.AddAsync(new()
        {
            AccountNumber = uniqueInt,
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "admin"
           
        });
        await unitOfWork.AccountWriteRepository.SaveAsync();
        var response = new CreateAccountCommandResponse()
        {
            AccountNumber = uniqueInt
        };
        return new ApiResponse<CreateAccountCommandResponse>(response);
    }
}
