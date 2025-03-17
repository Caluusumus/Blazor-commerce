using Microsoft.AspNetCore.Components;
using Blazor_E_commerce.Services;

namespace Blazor_E_commerce.Components.Pages.CategoryPages;

public partial class DeleteCategory(ICategoryDataAccess categoryData)
{
    [Parameter]
    public int Id { get; set; }

    protected override void OnInitialized()
    {
        categoryData.DeleteCategory(Id);
    }
}
