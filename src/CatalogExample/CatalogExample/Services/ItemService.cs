using System.Reactive.Linq;
using System.Reactive.Subjects;
using CatalogExample.Models;

namespace CatalogExample.Services;

public class ItemService : IItemService
{
    private readonly IList<Item> _items;

    public ItemService()
    {
        _items = new List<Item>();
        _items.Add(new Item(1, "item1", "this is description for item1."));
        _items.Add(new Item(2, "item2", "this is description for item2."));
        _items.Add(new Item(3, "item3", "this is description for item3."));
        _items.Add(new Item(4, "item4", "this is description for item4."));
    }

    public Task<Item> GetItemByIdAsync(int id)
    {
        return Task.FromResult(_items.Single(x => x.Id == id));
    }

    public Task<IEnumerable<Item>> GetItemsAsync()
    {
        return Task.FromResult(_items.AsEnumerable());
    }

    public Task<IEnumerable<Item>> GetItemsByIdsAsync(List<int> ids)
    {
        return Task.FromResult(_items.Where(item => ids.Contains(item.Id)));
    }

    public Task<Item> CreateAsync(Item item)
    {
        _items.Add(item);
        return Task.FromResult(item);
    }
}

public interface IItemService
{
    Task<Item> GetItemByIdAsync(int id);
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<IEnumerable<Item>> GetItemsByIdsAsync(List<int> ids);
    Task<Item> CreateAsync(Item item);
}
