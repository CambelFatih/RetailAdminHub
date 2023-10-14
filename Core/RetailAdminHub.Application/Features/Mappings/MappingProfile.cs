using AutoMapper;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;
using RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.Application.Features.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //for GetByIdProduct Query mapping
        CreateMap<Product, ProductDetailDTO>()
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        CreateMap<Category, CategoryDTO>();
        CreateMap<ProductDetailDTO, GetByIdProductQueryResponse>();

        //for GetAllProduct Query mapping
        CreateMap<List<ProductDetailDTO>, GetAllProductQueryResponse>()
.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));

        //for GetByIdCategory Query mapping
        CreateMap<Product, ProductDTO>()
.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => new SummaryCategoryDTO { Id = c.Id })));
        CreateMap<Category, CategoryDetailDTO>();
        CreateMap<CategoryDetailDTO, GetByIdCategoryQueryResponse>();

        //for GetAllCatergory Query mapping
        CreateMap<List<CategoryDetailDTO>, GetAllCategoryQueryResponse>()
.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src));
        CreateMap<Category, GetAllCategoryQueryResponse>();

        CreateMap<Account, GetAllAccountQueryResponse>();
    }
}

