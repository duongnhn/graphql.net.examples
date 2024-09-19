using CatalogExample.Services;
using GraphQL;
using GraphQL.Types;

namespace CatalogExample.Schema;

public class CatalogQuery : ObjectGraphType<object>
{
    public CatalogQuery(IItemService itemService, IManifestService manifestService)
    {
        Name = "Query";
        Field<ListGraphType<ItemType>>("items").ResolveAsync(async context => await itemService.GetItemsAsync());

        Field<ListGraphType<ManifestType>>("manifests").ResolveAsync(resolve: async context => await manifestService.GetManifestsAsync());

        Field<ItemType>("item")
            .Argument<NonNullGraphType<StringGraphType>>("id", "id of the item")
            .ResolveAsync(
            resolve: async context => await itemService.GetItemByIdAsync(context.GetArgument<int>("id"))
        );

        Field<ManifestType>("manifest")
            .Argument<NonNullGraphType<StringGraphType>>("id", "id of the manifest")
            .ResolveAsync(
            resolve: async context => await manifestService.GetManifestByIdAsync(context.GetArgument<int>("id"))
        );
    }
}
