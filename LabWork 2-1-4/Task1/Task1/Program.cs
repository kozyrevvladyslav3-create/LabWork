using System.Security.Cryptography;

namespace Task1
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
    class Customer
    {
        public int CardNumber { get; private set; }
        public int Money { get; private set; }
        public int ItemsBought { get; private set; }
        public int MoneySpent { get; private set; }
        public Customer(Random rnd)
        {
            CardNumber = rnd.Next(1, 1001);
            Money = rnd.Next(1000, 10001);
            ItemsBought = 0;
            MoneySpent = 0;
        }
        public void BuyProduct(Product product)
        {
            product.Quantity--;
            this.Money -= product.Price;
            this.MoneySpent += product.Price;
            this.ItemsBought++;
        }
    }
    class Store
    {
        private List<Product> _products = new List<Product>();
        private List<Customer> _customers = new List<Customer>();
        private int _totalProfit = 0;
        private Random _rnd = new Random();
        public void CreateProducts()
        {
            string[] productNames = { "Ноутбук", "Смартфон", "Навушники", "Клавіатура", "Мишка"};

            foreach (var name in productNames)
            {
                int price = _rnd.Next(500, 3001);
                int quantity = _rnd.Next(2, 21);
                _products.Add(new Product(name, price, quantity));
            }
        }
        public void CreateCustomers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _customers.Add(new Customer(_rnd));
            }
        }
        public void StartSimulation()
        {
            while (HasAvailableProducts() && HasCapableCustomers())
            {
                foreach (var customer in _customers)
                {
                    var affordableProducts = _products
                        .Where(p => p.Quantity > 0 && p.Price <= customer.Money)
                        .ToList();

                    if (affordableProducts.Count > 0)
                    {
                        Product chosenProduct = affordableProducts[_rnd.Next(affordableProducts.Count)];

                        customer.BuyProduct(chosenProduct);
                        _totalProfit += chosenProduct.Price;

                        Console.WriteLine($"Покупець картка {customer.CardNumber} купив '{chosenProduct.Name}' за {chosenProduct.Price}");
                    }
                }
            }
        }
        private bool HasAvailableProducts()
        {
            return _products.Any(p => p.Quantity > 0);
        }
        private bool HasCapableCustomers()
        {
            var availableProducts = _products.Where(p => p.Quantity > 0).ToList();
            if (availableProducts.Count == 0) return false;
            int minPrice = availableProducts.Min(p => p.Price);
            return _customers.Any(c => c.Money >= minPrice);
        }
        public void DisplayResults()
        {
            Console.WriteLine($"\nЗагальний прибуток магазину: {_totalProfit}");
            if (_customers.Count == 0) return;
            var maxItemsCustomer = _customers.OrderByDescending(c => c.ItemsBought).First();
            var maxSpentCustomer = _customers.OrderByDescending(c => c.MoneySpent).First();
            Console.WriteLine($"Картка покупця, що купив макс. кількість товарів ({maxItemsCustomer.ItemsBought}): {maxItemsCustomer.CardNumber}");
            Console.WriteLine($"Картка покупця, що витратив найбільше грошей ({maxSpentCustomer.MoneySpent}): {maxSpentCustomer.CardNumber}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.CreateProducts();
            Console.WriteLine("Введіть кількість покупців у системі: ");
            int customerCount = Convert.ToInt32(Console.ReadLine());
            store.CreateCustomers(customerCount);
            store.StartSimulation();
            store.DisplayResults();
        }
    }
}