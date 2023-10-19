using MediatR;
using Microsoft.IdentityModel.Tokens;
using RetailAdminHub.Domain.Base.Encryption;
using RetailAdminHub.Domain.Base.Response;
using RetailAdminHub.Domain.Base.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using RetailAdminHub.Application.Abstractions.Uow;

namespace RetailAdminHub.Application.Features.Command.Token.CreateToken;

public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommandRequest, ApiResponse<CreateTokenCommandResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly JwtConfig jwtConfig;
    public CreateTokenCommandHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
    {
        this.unitOfWork = unitOfWork;
        this.jwtConfig = jwtConfig.CurrentValue;
    }

    public async Task<ApiResponse<CreateTokenCommandResponse>> Handle(CreateTokenCommandRequest request, CancellationToken cancellationToken)
    {
        // Retrieve the user entity based on the provided account number
        var entity = await unitOfWork.AccountReadRepository.GetSingleAsync(x => x.AccountNumber == request.AccountNumber, cancellationToken);
        // Check if the user entity exists
        if (entity == null)      
            return new ApiResponse<CreateTokenCommandResponse>("Invalid user informations");
        // Check if the provided password matches the stored password
        var md5 = Md5.Create(request.Password.ToUpper());
        if (entity.Password != md5)
        {
            entity.LastActivityDate = DateTime.UtcNow;
            entity.PasswordRetryCount++;
            await unitOfWork.AccountWriteRepository.SaveAsync(cancellationToken);

            return new ApiResponse<CreateTokenCommandResponse>("Invalid user informations");
        }
        // Check if the user is active
        if (!entity.IsActive)
        {
            return new ApiResponse<CreateTokenCommandResponse>("Invalid user!");
        }
        // Generate a JWT token for the user
        string token = Token(entity);
        CreateTokenCommandResponse tokenResponse = new()
        {
            Token = token,
            ExpireDate = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            AccountNumber = entity.AccountNumber,
            Email = entity.Email
        };

        return new ApiResponse<CreateTokenCommandResponse>(tokenResponse);
    }

    private string Token(RetailAdminHub.Domain.Entities.Account user)
    {
        // Create claims for the user
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);
        // Create a JWT token with the claims
        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        );
        // Generate and return the access token
        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
    }

    private Claim[] GetClaims(RetailAdminHub.Domain.Entities.Account customer)
    {
        // Define the claims for the user
        var claims = new[]
        {
            new Claim("Id", customer.Id.ToString()),
            new Claim("CustomerNumber", customer.AccountNumber.ToString()),
            new Claim("Role", customer.Role),
            new Claim("Email", customer.Email),
            new Claim(ClaimTypes.Role, customer.Role),
            new Claim("FullName", $"{customer.FirstName} {customer.LastName}")
        };
        return claims;
    }
}

