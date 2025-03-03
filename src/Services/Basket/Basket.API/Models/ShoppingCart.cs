﻿namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice => Items.Sum(i => i.price * i.quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart()
        {
        }

    }
}
