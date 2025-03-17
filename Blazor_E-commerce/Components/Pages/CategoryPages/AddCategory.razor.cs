using Blazor_E_commerce.Models;
using Blazor_E_commerce.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blazor_E_commerce.Components.Pages.CategoryPages;
public partial class AddCategory(ICategoryDataAccess categoryDataAccess, NavigationManager navigation)
{
    private Category newCategory = new();
    private EditContext? _editContext { get; set; }
    protected override void OnInitialized()
    {
        _editContext = new EditContext(newCategory);
    }
    private void Save()
    {
        categoryDataAccess.AddCategory(newCategory);
        navigation.NavigateTo("/categories");
    }
}


