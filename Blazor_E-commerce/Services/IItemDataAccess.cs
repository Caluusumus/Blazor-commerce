using Blazor_E_commerce.Models;

namespace Blazor_E_commerce.Services
{
    public interface IItemDataAccess
    {
        void AddItem(Item item);
        void DeleteItem(int id);
        Item? GetItem(int id);
        IEnumerable<Item> GetItems();
        void UpdateItem(Item item);
    }
}