
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

        public Product? GetByName(string name)
        {
            foreach (Product product in _products)
            {
                if (string.Equals(product.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }
            return null;
        }

        public bool ChangeName(Product product, string newName)
        {
            newName = newName.Trim();
            if (string.IsNullOrEmpty(newName) || !_products.Contains(product))
            {
                return false;
            }

            foreach (Product existingProduct in _products)
            {
                if (existingProduct != product && string.Equals(existingProduct.Name, newName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                product.Rename(newName);
                return true;
            }

            return false;
        }


        public bool ChangePrice(Product product, decimal price)
        {
            if (!_products.Contains(product))
            {
                return false;
            }

            product.ChangePrice(price);
            return true;


        }

        public bool ChangeQuantity(Product product, int quantity)
        {
            if (!_products.Contains(product))
            {
                return false;
            }

            product.ChangeQuantity(quantity);
            return true;
        }
        public bool Remove(Product product)
        {
            return _products.Remove(product);
        }

        internal bool Remove(string name)
        {
            throw new NotImplementedException();
        }
    }


}
