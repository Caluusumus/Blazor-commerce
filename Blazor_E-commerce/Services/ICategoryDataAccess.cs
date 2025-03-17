using Blazor_E_commerce.Models;

namespace Blazor_E_commerce.Services
{
    public interface ICategoryDataAccess
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<Category> GetCategories();
        Category? GetCategory(int id);
        void UpdateCategory(Category category);
    }
}