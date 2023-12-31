﻿using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest <ApiResponse<CreateProductCommandResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
