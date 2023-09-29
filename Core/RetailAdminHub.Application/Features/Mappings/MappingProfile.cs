using AutoMapper;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;
using RetailAdminHub.Application.Features.Queries.Product.CreateProduct;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RetailAdminHub.Domain.Entities.Product, ProductDetailDTO>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
            CreateMap<RetailAdminHub.Domain.Entities.Category, CategoryDTO>();
            CreateMap<ProductDetailDTO, GetByIdProductQueryResponse>();
            CreateMap<List<ProductDetailDTO>, GetAllProductQueryResponse>()
    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));
            CreateMap<RetailAdminHub.Domain.Entities.Product, ProductDTO>()
    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => new SummaryCategoryDTO { Id = c.Id })));
            CreateMap<Category, CategoryDetailDTO>();
            CreateMap<CategoryDetailDTO, GetByIdCategoryQueryResponse>();
        }
    }

}
