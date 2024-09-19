using GraphQL.Types;

namespace CatalogExample.Schema;

public class ItemCreateInputType : InputObjectGraphType
{
    public ItemCreateInputType()
    {
        Name = "ItemInput";
        Field<NonNullGraphType<IntGraphType>>("id");
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("description");
    }
}
