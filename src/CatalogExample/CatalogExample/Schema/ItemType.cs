using GraphQL.Types;
using CatalogExample.Models;

namespace CatalogExample.Schema;

public class ItemType : ObjectGraphType<Item>
{
    public ItemType()
    {
        Field(c => c.Id);
        Field(c => c.Name);
        Field(c => c.Description);
    }
}
