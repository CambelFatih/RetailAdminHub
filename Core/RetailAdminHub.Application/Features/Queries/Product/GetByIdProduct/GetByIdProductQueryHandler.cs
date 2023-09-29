using RetailAdminHub.Application.Repositories;
using MediatR;
using P = RetailAdminHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Exceptions;
using AutoMapper;

namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetProductWithCategoriesAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundProductException();
            }
            var productDto = _mapper.Map<ProductDTO>(product);

            // Eğer gerekirse, ProductDTO'yu GetByIdProductQueryResponse'ye dönüştürün
            return _mapper.Map<GetByIdProductQueryResponse>(productDto);
        }

    }
}
