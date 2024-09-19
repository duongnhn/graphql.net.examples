using CatalogExample.Services;
using GraphQL;
using GraphQL.Types;

namespace CatalogExample.Schema;

public class CatalogQuery : ObjectGraphType<object>
{
    public CatalogQuery(IItemService itemService, IManifestService manifestService)
    {
        Name = "Query";
        FieldAsync<ListGraphType<ItemType>>("items", resolve: async context => await itemService.GetItemsAsync());

        FieldAsync<ListGraphType<ManifestType>>("manifests", resolve: async context => await manifestService.GetManifestsAsync());

        FieldAsync<ItemType>("item",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the item" }
            ),
            resolve: async context => await itemService.GetItemByIdAsync(context.GetArgument<int>("id"))
        );

        FieldAsync<ManifestType>("manifest",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the manifest" }
            ),
            resolve: async context => await manifestService.GetManifestByIdAsync(context.GetArgument<int>("id"))
        );
    }
}
