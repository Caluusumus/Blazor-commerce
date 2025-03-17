using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Blazor_E_commerce.Models;
using Blazor_E_commerce.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blazor_E_commerce.Components.Pages.CategoryPages;

public partial class UpdateCategory(ICategoryDataAccess categoryData, NavigationManager navigation)
{
    [Parameter]
    public int Id { get; set; }
    private EditContext _editContext { get; set; }
    private Category newCategory { get; set; }
    private string Name { get; set; }
    protected override void OnInitialized()
    {
        newCategory = categoryData.GetCategory(Id);
        _editContext = new EditContext(newCategory);
    }

    private void Update()
    {
        categoryData.UpdateCategory(newCategory);
        navigation.NavigateTo("/categories");
    }
}
