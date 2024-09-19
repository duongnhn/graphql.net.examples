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
        Field<ItemType>("createItem")
            .Argument<NonNullGraphType<ItemCreateInputType>>("item", "the item to create")
            .ResolveAsync(
            async context =>
            {
                var itemInput = context.GetArgument<ItemCreateInput>("item");
                var itemToCreate = new Item(itemInput.Id, itemInput.Name, itemInput.Description);
                return await itemService.CreateAsync(itemToCreate);
            }
        );

        Field<ManifestType>("createManifest")
            .Argument<NonNullGraphType<ManifestCreateInputType>>("manifest", "the manifest to create")
            .ResolveAsync(
            async context =>
            {
                var manifestInput = context.GetArgument<ManifestCreateInput>("manifest");
                var manifestToCreate = new Manifest(manifestInput.Id, manifestInput.Name, manifestInput.Description, manifestInput.ItemIds);
                return await manifestService.CreateAsync(manifestToCreate);
            }
        );
    }
}
