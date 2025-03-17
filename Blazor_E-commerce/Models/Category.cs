namespace Blazor_E_commerce.Models;

    public class Category
    {
    public int categoryId { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; }
    public bool status { get; set; } = false;
    }

