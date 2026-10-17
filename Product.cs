using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Inventory_Management_System
{
    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        public Product(string name , decimal Price , int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

    }
}
