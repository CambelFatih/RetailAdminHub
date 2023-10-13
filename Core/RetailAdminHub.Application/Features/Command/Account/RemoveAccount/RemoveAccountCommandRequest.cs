using MediatR;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;
using RetailAdminHub.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Command.Account.RemoveAccount;

public class RemoveAccountCommandRequest : IRequest<ApiResponse<RemoveAccountCommandResponse>>
{
    public string AccountId { get; set; }
}

