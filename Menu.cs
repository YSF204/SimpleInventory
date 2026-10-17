namespace Simple_Inventory_Management_System
{
    public class Menu
    {
        private readonly Inventory _inventory;
        public Menu(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Edit a product");
                Console.WriteLine("4. Delete a product");
                Console.WriteLine("5. Search for a product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        EditProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }

            }
        }



        private void AddProduct()
        {
            Console.WriteLine("Add product Name : ");
            string name = (Console.ReadLine() ?? "").Trim();
            if (name == "")
            {
                Console.WriteLine("The name cannot be empty.");
                return;
            }

            if (_inventory.Exists(name))
            {
                Console.WriteLine("A product with the same name already exists.");
                return;
            }

            decimal price = ReadPrice();
            int quantity = ReadQuantity();

            Product product = new Product(name, price, quantity);

            if (_inventory.Add(product))
            {
                Console.WriteLine("Product Added");
            }
            else
            {
                Console.WriteLine("A product with the same name already exists.");
            }
        }

        private decimal ReadPrice()
        {
            while (true)
            {
                Console.WriteLine("Price : (Press Enter for 0)");
                string input = Console.ReadLine() ?? "";
                if (input == "")
                {
                    return 0;
                }
                if (decimal.TryParse(input, out decimal price) && price >= 0)
                {
                    return price;
                }
                Console.WriteLine("Invalid price. Please enter a valid non-negative number.");
            }
        }

        private int ReadQuantity()
        {
            while (true)
            {
                Console.WriteLine("Quantity : (Press Enter for 0)");
                string input = Console.ReadLine() ?? "";
                if (input == "")
                {
                    return 0;
                }
                if (int.TryParse(input, out int quantity) && quantity >= 0)
                {
                    return quantity;
                }
                Console.WriteLine("Invalid quantity. Please enter a valid non negative integer.");
            }
        }

        private void ViewAllProducts()
        {
            IReadOnlyList<Product> products = _inventory.GetAll();
            if (products.Count == 0)
            {
                System.Console.WriteLine("No products in the inventory.");
                return;
            }
            foreach (Product product in products)
            {
                System.Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        private void EditProduct()
        {
            Console.Write("Enter the product name: ");
            string name = (Console.ReadLine() ?? "").Trim();

            Product? product = _inventory.GetByName(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine("1. Change name");
            Console.WriteLine("2. Change price");
            Console.WriteLine("3. Change quantity");
            Console.WriteLine("4. Cancel");
            Console.Write("Choose what to edit: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine() ?? "";
                    if (_inventory.ChangeName(product, newName))
                    {
                        Console.WriteLine($"Name updated to {newName}.");
                    }
                    else
                    {
                        Console.WriteLine("That name is empty or already in use.");
                    }
                    break;

                case "2":
                    _inventory.ChangePrice(product, ReadPrice());
                    Console.WriteLine("Price updated.");
                    break;

                case "3":
                    _inventory.ChangeQuantity(product, ReadQuantity());
                    Console.WriteLine("Quantity updated.");
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void DeleteProduct ()
        {
            System.Console.WriteLine("Enter the product name to delete: ");
            string name = (Console.ReadLine() ?? "").Trim();
            Product? product = _inventory.GetByName(name);

            if (product != null && _inventory.Remove(product))
            {
                System.Console.WriteLine("Product deleted.");
            }
            else
            {
                System.Console.WriteLine("Product not found.");
            }
        }
    
        private void SearchProduct()
        {
            System.Console.WriteLine("Enter the product name to search: ");
            string name = (Console.ReadLine() ?? "").Trim();
            Product? product = _inventory.GetByName(name);

            if (product != null)
            {
                System.Console.WriteLine($"Found product: Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            else
            {
                System.Console.WriteLine("Product not found.");
            }
        }    
    }
}
