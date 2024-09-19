namespace CatalogExample.Models;

public class ManifestCreateInput
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required List<int> ItemIds { get; set; }
}
