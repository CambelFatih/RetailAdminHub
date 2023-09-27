﻿using FluentValidation;
using RetailAdminHub.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Validators.Products
{
    public class CrateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CrateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Product Name is required.")
                .MaximumLength(150).MinimumLength(5).WithMessage("Product Name should be between 5 to 150 characters.");

            RuleFor(p => p.Sock)
                .NotEmpty().NotNull().WithMessage("Stock value is required.")
                .Must(s => s > 0).WithMessage("Stock value must be positive.");

            RuleFor(p => p.Price)
                .NotEmpty().NotNull().WithMessage("Price is required.")
                .Must(s => s > 0).WithMessage("Price must be positive.");
        }
    }
}
