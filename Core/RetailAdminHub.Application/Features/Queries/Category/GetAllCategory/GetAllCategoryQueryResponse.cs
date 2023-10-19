using RetailAdminHub.Application.Dto;
namespace RetailAdminHub.Application.Features.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = "";
    public DateTime InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<ProductSummaryDto> Products { get; set; }=new List<ProductSummaryDto>();
}

