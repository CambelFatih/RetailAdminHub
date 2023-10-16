﻿using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.RemoveCategoryProduct;

public class RemoveCategoryProductCommandRequest :IRequest<ApiResponse<RemoveCategoryProductCommandResponse>>
{
    public string CategoryId { get; set; }
    public string ProductId { get; set; }
}
