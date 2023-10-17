
namespace RetailAdminHub.Domain.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public Guid InsertUserId { get; set; }
    public DateTime InsertDate { get; set; }
    public Guid UpdateUserId { get; set; }
    virtual public DateTime? UpdateDate { get; set; }
    public bool IsActive { get; set; }
}

