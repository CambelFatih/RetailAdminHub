using MediatR;
using RetailAdminHub.Application.Features.Command.Product.RemoveProduct;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Command.Account.RemoveAccount;

public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommandRequest, ApiResponse<RemoveAccountCommandResponse>>
{
    readonly IAccountWriteRepository accountWriteRepository;

    public RemoveAccountCommandHandler(IAccountWriteRepository accountWriteRepository)
    {
        this.accountWriteRepository = accountWriteRepository;
    }

    public async Task<ApiResponse<RemoveAccountCommandResponse>> Handle(RemoveAccountCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await accountWriteRepository.SoftDeleteById(request.Id, cancellationToken);
        return new ApiResponse<RemoveAccountCommandResponse>(result);
    }
}

