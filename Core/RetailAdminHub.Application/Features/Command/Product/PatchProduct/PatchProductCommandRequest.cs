using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Product.PatchProduct;

public class PatchProductCommandRequest : IRequest<ApiResponse<PatchProductCommandResponse>>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public JsonPatchDocument<PatchProductCommandRequest> PatchDocument { get; set; }
}
