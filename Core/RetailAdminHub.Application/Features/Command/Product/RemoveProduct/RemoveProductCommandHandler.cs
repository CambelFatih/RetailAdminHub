using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, ApiResponse<RemoveProductCommandResponse>>
    {
        readonly IProductWriteRepository productWriteRepository;

        public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<ApiResponse<RemoveProductCommandResponse>> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await productWriteRepository.SoftDeleteById(request.ProductId, cancellationToken);
            return new ApiResponse<RemoveProductCommandResponse>(result);
        }
    }
}
