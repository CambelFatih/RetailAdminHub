namespace RetailAdminHub.Application.Dto;

public class ProductDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<CategorySummaryDto> Categories { get; set; }
}

public class ProductSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
