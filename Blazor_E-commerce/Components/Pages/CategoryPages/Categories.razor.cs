using Blazor_E_commerce.Models;
using Blazor_E_commerce.Services;


namespace Blazor_E_commerce.Components.Pages.CategoryPages;

    public partial class Categories(ICategoryDataAccess categoryData)
{
        private IEnumerable<Category> categories;

        protected override void OnInitialized()
        {
            categories = categoryData.GetCategories();
        }
    }

