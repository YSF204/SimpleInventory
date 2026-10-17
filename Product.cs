namespace Simple_Inventory_Management_System
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, decimal Price, int quantity)
        {
            this.Name = name;
            this.Price = Price;
            this.Quantity = quantity;
        }
        public void Rename(string name)
        {
            Name = name;
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }
        public void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Quantity: {Quantity}";
        }

    }

}
