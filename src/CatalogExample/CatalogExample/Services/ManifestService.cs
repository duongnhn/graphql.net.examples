using CatalogExample.Models;

namespace CatalogExample.Services;

public class ManifestService : IManifestService
{
    private readonly IList<Manifest> _manifests;

    public ManifestService()
    {
        _manifests = new List<Manifest>();
        _manifests.Add(new Manifest(12, "manifest12", "this is description for manifest12", new List<int> { 1, 2 }));
        _manifests.Add(new Manifest(34, "manifest34", "this is description for manifest34", new List<int> { 3, 4 }));
    }

    public Task<Manifest> GetManifestByIdAsync(int id)
    {
        return Task.FromResult(_manifests.Single(x => x.Id == id));
    }

    public Task<IEnumerable<Manifest>> GetManifestsAsync()
    {
        return Task.FromResult(_manifests.AsEnumerable());
    }

    public Task<Manifest> CreateAsync(Manifest manifest)
    {
        _manifests.Add(manifest);
        return Task.FromResult(manifest);
    }
}

public interface IManifestService
{
    Task<Manifest> GetManifestByIdAsync(int id);
    Task<IEnumerable<Manifest>> GetManifestsAsync();
    Task<Manifest> CreateAsync(Manifest manifest);
}
