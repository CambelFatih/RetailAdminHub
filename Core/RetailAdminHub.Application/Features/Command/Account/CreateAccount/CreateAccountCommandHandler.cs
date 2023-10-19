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
        // Generate a random integer for the account number
        Random rnd = new Random();
        int uniqueInt = rnd.Next();
        // Encrypt the password using the Md5.Control method
        request.Password = Md5.Control(request.Password.ToUpper());
        // Add a new account to the repository
        await unitOfWork.AccountWriteRepository.AddAsync(new()
        {
            AccountNumber = uniqueInt,
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "admin"
           
        });
        // Save changes to the account repository
        await unitOfWork.AccountWriteRepository.SaveAsync();
        // Create a response with the generated account number
        var response = new CreateAccountCommandResponse()
        {
            AccountNumber = uniqueInt
        };
        // Return an ApiResponse containing the response data
        return new ApiResponse<CreateAccountCommandResponse>(response);
    }
}
