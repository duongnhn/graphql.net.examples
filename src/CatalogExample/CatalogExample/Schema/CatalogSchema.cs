using GraphQL.Instrumentation;

namespace CatalogExample.Schema;

public class CatalogSchema : GraphQL.Types.Schema
{
    public CatalogSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetService<CatalogQuery>() ?? throw new InvalidOperationException();
        Mutation = provider.GetService<CatalogMutation>() ?? throw new InvalidOperationException();
        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
