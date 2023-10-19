namespace RetailAdminHub.Domain.Base.Token;

public class JwtConfig
{
    public string Secret { get; set; } = "2A49DF37289D10E75308E22DD7C9C9B17826858F5DE3AF741A00B4B47C4C2353";
    public string Issuer { get; set; } = "RetailAdminHub";
    public string Audience { get; set; } = "RetailAdminHub";
    public int AccessTokenExpiration { get; set; }
}