using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RetailAdminHub.Application.Repositories;

namespace RetailAdminHub.Application.Features.Queries.Product.CreateProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        async Task<GetAllProductQueryResponse> IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>.Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalProductCount = _productReadRepository.GetAll(false).Count();

            var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate,
                }).ToList();

            // Create a new GetAllProductQueryResponse instance with property setters
            var response = new GetAllProductQueryResponse
            {
                Products = products,
                TotalProductCount = totalProductCount
            };

            return await Task.FromResult(response);
        }
    }
}
