using GraphQL.Types;
using CatalogExample.Models;
using CatalogExample.Services;

namespace CatalogExample.Schema;

public class ManifestType : ObjectGraphType<Manifest>
{
    public ManifestType(IItemService itemService)
    {
        Field(m => m.Id);
        Field(m => m.Name);
        Field(m => m.Description);
        Field(m => m.ItemIds);
        Field<ListGraphType<ItemType>>("items").ResolveAsync(resolve: async context => await itemService.GetItemsByIdsAsync(context.Source.ItemIds));
    }
}
