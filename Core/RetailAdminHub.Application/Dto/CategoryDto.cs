namespace RetailAdminHub.Application.Dto;

public class CategoryDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<ProductSummaryDto> Products { get; set; }
}


public class CategorySummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}


