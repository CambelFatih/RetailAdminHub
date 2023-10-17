﻿using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;


namespace RetailAdminHub.Application.Abstractions.Uow;

public interface IUnitOfWork
{
    void Complete();
    void CompleteTransaction();

    IProductReadRepository ProductReadRepository { get; }
    ICategoryReadRepository CategoryReadRepository { get; }
    IAccountReadRepository AccountReadRepository { get; }

    IProductWriteRepository ProductWriteRepository { get; }
    ICategoryWriteRepository CategoryWriteRepository { get; }
    IAccountWriteRepository AccountWriteRepository { get; }
}

