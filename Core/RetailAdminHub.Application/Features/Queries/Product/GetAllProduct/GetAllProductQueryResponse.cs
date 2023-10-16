using RetailAdminHub.Application.Dto;
namespace RetailAdminHub.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryResponse
{
    public int TotalProductCount { get; set; }
    public List<ProductDetailDto> Products { get; set; }
}
