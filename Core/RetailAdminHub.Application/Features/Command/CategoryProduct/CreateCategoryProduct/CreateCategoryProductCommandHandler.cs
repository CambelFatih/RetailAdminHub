using MediatR;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Command.CategoryProduct.CreateCategoryProduct
{
    public class CreateCategoryProductCommandHandler : IRequestHandler<CreateCategoryProductCommandRequest, CreateCategoryProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateCategoryProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<CreateCategoryProductCommandResponse> Handle(CreateCategoryProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.ProductName,
                Stock = request.Stock,
                Price = request.Price
            };

            var categories = request.Categories.Select(c => new Domain.Entities.Category
            {
                Name = c.Name,
                Description = c.Description
            }).ToList();

            await _productWriteRepository.AddProductWithCategories(product, categories);

            // Burada oluşturulan ürünün ID'si veya herhangi bir bilgisi yanıt olarak döndürülebilir.
            return new CreateCategoryProductCommandResponse { ProductId = product.Id };
        }
    }
}
