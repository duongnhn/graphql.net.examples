using GraphQL.Instrumentation;
namespace CatalogExample.Schema;

public class CatalogSchema : GraphQL.Types.Schema
{
    public CatalogSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetService<CatalogQuery>() ?? throw new InvalidOperationException("Something is wrong with Query.");
        Mutation = provider.GetService<CatalogMutation>() ?? throw new InvalidOperationException("Something is wrong with Mutation.");
        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}
