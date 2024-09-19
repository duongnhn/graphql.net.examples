using CatalogExample.Schema;
using CatalogExample.Services;
using GraphQL;
using GraphQL.SystemTextJson;
using Microsoft.Extensions.Options;

namespace CatalogExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IManifestService, ManifestService>();

            services.AddGraphQL(b => b
                .AddSchema<CatalogSchema>()
                .AddSystemTextJson()
                //.AddValidationRule<InputValidationRule>()
                .AddGraphTypes(typeof(CatalogSchema).Assembly)
                .UseMemoryCache()
                .UseApolloTracing(options => options.RequestServices!.GetRequiredService<IOptions<CatalogExample.GraphQLSettings>>().Value.EnableMetrics));

            services.Configure<CatalogExample.GraphQLSettings>(Configuration.GetSection("GraphQLSettings"));
            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();
            services.AddControllersWithViews()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new InputsJsonConverter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseWebSockets();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
