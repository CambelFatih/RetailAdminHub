﻿using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct;

public class CreateCategoryProductCommandRequest : IRequest<ApiResponse<CreateCategoryProductCommandResponse>>
{
    public string ProductId { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
}

