using CatalogExample.Models;
using CatalogExample.Services;
using GraphQL;
using GraphQL.Types;

namespace CatalogExample.Schema;

public class CatalogMutation : ObjectGraphType<object>
{
    public CatalogMutation(IItemService itemService, IManifestService manifestService)
    {
        Name = "Mutation";
        FieldAsync<ItemType>("createItem",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ItemCreateInputType>> { Name = "item", Description = "the item to create" }
            ),
            resolve: async context =>
            {
                var itemInput = context.GetArgument<ItemCreateInput>("item");
                var itemToCreate = new Item(itemInput.Id, itemInput.Name, itemInput.Description);
                return await itemService.CreateAsync(itemToCreate);
            }
        );

        FieldAsync<ManifestType>("createManifest",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ManifestCreateInputType>> { Name = "manifest", Description = "the manifest to create" }
            ),
            resolve: async context =>
            {
                var manifestInput = context.GetArgument<ManifestCreateInput>("manifest");
                var manifestToCreate = new Manifest(manifestInput.Id, manifestInput.Name, manifestInput.Description, manifestInput.ItemIds);
                return await manifestService.CreateAsync(manifestToCreate);
            }
        );
    }
}
