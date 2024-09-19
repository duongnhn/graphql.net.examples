namespace CatalogExample.Models;

public class Manifest
{
    public Manifest(int id, string name, string description, List<int> itemIds)
    {
        Id = id;
        Name = name;
        Description = description;
        ItemIds = itemIds;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<int> ItemIds { get; set; }
}
