using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.PatchProduct;

public class PatchProductCommandRequest : IRequest<ApiResponse<PatchProductCommandResponse>>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; }
    public float Price { get; set; }
    public JsonPatchDocument<PatchProductCommandRequest> PatchDocument { get; set; } = new JsonPatchDocument<PatchProductCommandRequest>();
}
