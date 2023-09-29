using AutoMapper;
using MediatR;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;
        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }
        async Task<GetByIdCategoryQueryResponse> IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>.Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetCategoryWithProductsAsync(request.Id);

            if (category == null)
            {
                throw new NotFoundProductException();
            }

            var categoryDto = _mapper.Map<CategoryDetailDTO>(category);
            return _mapper.Map<GetByIdCategoryQueryResponse>(categoryDto);
        }
    }
}
