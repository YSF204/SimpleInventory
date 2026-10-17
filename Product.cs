using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Inventory_Management_System
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal Price, int quantity)
        {
            this.Name = name;
            this.Price = Price;
            this.Quantity = quantity;
        }

    }
}
