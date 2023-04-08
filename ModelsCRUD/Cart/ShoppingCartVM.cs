using System.Collections.Generic;
using BookStoreApp.Models;

namespace BookStoreApp.ModelsCRUD
{
    public class ShoppingCartVM
    {
        public IEnumerable<Cart> ListCarts { get; set; }
        public Order Order { get; set; }
    }
}