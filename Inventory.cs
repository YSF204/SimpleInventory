
namespace Simple_Inventory_Management_System
{
    public class Inventory
    {

        private readonly List<Product> _products = new List<Product>();

        public bool Exists(string name)
        {
            foreach (Product existingProduct in _products)
            {
                if (string.Equals(existingProduct.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Add(Product product)
        {
            foreach (Product existingProduct in _products)
            {
                if (string.Equals(existingProduct.Name, product.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            _products.Add(product);
            return true;
        }

        public IReadOnlyList<Product> GetAll()
        {
            return _products.AsReadOnly();
        }
    }


}
