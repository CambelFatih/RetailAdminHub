using AutoMapper;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;
using RetailAdminHub.Application.Dto; 
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;
using RetailAdminHub.Application.Features.Command.Product.PatchProduct;

namespace RetailAdminHub.Application.Features.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, GetAllCategoryQueryResponse>();
        CreateMap<Account, GetAllAccountQueryResponse>();
        CreateMap<Product, GetAllProductQueryResponse>();

        CreateMap<Category, GetByIdCategoryQueryResponse>();
        CreateMap<Product, GetByIdProductQueryResponse>();
        CreateMap<Account, GetByIdAccountQueryResponse>();

        CreateMap<Product, PatchProductCommandRequest>();
        CreateMap<PatchProductCommandRequest, Product>();

        CreateMap<Product, ProductSummaryDto>();
        CreateMap<Product, ProductDetailDto>();
        CreateMap<Category, CategorySummaryDto>();

    }
}

