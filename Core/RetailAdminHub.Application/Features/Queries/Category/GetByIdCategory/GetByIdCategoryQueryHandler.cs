using AutoMapper;
using MediatR;
using RetailAdminHub.Application.DTOs.Product;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, ApiResponse<GetByIdCategoryQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;
        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }
        async Task<ApiResponse<GetByIdCategoryQueryResponse>> IRequestHandler<GetByIdCategoryQueryRequest, ApiResponse<GetByIdCategoryQueryResponse>>.Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetCategoryWithProductsAsync(request.Id);

            if (category == null)
            {
               return new ApiResponse <GetByIdCategoryQueryResponse> ("Record not found", false);
            }

            var categoryDto = _mapper.Map<CategoryDetailDTO>(category);
            return _mapper.Map<ApiResponse<GetByIdCategoryQueryResponse>>(categoryDto);
        }
    }
}
