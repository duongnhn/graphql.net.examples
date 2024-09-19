using System.Security.Claims;

namespace CatalogExample;

public class GraphQLUserContext : Dictionary<string, object?>
{
    public ClaimsPrincipal? User { get; set; }
}
