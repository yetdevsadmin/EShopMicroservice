namespace Basket.API.Models
{
    public class ShoppingCartItem
    {
        public int quantity { get; set; } = default;
        public string Color { get; set; } = default;
        public decimal price { get; set; } = default;
        public Guid productId { get; set; } = default;
        public string ProductName { get; set; } = default;
    }
}
