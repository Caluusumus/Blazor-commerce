namespace Blazor_E_commerce.Models;

    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int totalPrice { get; set; }
        public decimal priceEach { get; set; }
    }
