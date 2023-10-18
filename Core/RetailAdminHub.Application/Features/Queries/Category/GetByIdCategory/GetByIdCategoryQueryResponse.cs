using RetailAdminHub.Application.Dto;

namespace RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;

public class GetByIdCategoryQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public List<ProductSummaryDto> Products { get; set; }  
}

