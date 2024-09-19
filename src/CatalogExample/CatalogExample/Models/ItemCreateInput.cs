namespace CatalogExample.Models;

public class ItemCreateInput
{
    public required string Name { get; set; }
    public int Id { get; set; }
    public required string Description { get; set; }
}
