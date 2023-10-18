using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailAdminHub.Application.Abstractions.Services;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Application.Repositories.ProductRepository;

namespace RetailAdminHub.Persistence.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}

