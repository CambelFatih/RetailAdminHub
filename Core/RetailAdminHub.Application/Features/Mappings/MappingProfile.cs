using AutoMapper;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
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
            CreateMap<RetailAdminHub.Domain.Entities.Product, ProductDTO>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

            CreateMap<RetailAdminHub.Domain.Entities.Category, CategoryDTO>();
            CreateMap<ProductDTO, GetByIdProductQueryResponse>();
        }
    }

}
