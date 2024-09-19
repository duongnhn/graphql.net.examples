using GraphQL.Types;

namespace CatalogExample.Schema;

public class ManifestCreateInputType : InputObjectGraphType
{
    public ManifestCreateInputType()
    {
        Name = "ManifestInput";
        Field<NonNullGraphType<IntGraphType>>("id");
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("description");
        Field<NonNullGraphType<ListGraphType<IntGraphType>>>("itemIds");
    }
}
