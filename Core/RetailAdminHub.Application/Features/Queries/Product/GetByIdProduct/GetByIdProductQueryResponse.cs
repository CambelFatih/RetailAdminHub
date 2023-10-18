using RetailAdminHub.Application.Dto;
namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public List<CategorySummaryDto> Categories { get; set; } // CategoryDTO'yu kullanın
}
