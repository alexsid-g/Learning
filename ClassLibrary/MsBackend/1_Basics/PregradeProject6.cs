namespace ClassLibrary.MsBackend.Basics;

/// <summary>
/// To complete this challenge, you will need to create a console application where users can manage product stock. 
/// Users should be able to add new products, update stock, and remove products.
/// Some key features include:
/// - Add new products with name, price, and stock quantity.
/// - Update stock when products are sold or restocked.
/// - View all products and their stock levels.
/// - Remove products from inventory.
/// </summary>
public class PregradeProject6
{
    static void Main(string[] args)
    {
        var service = new Inventory();
        service.Run();
    }

    public class Product 
    { 
        public string Name = string.Empty;
        public double Price;
        public int StockQty;
    }

    public class Inventory
    {
        private List<Product> _products = new();
        public void Run()
        {
            Console.WriteLine("Inventory application.");
            while (true)
            {
                var cmd = GetInput<string>("Choose your command [1. View, 2. Add, 3. Update, 4. Remove,     ]:");
                switch (cmd)
                {
                    case "1": // View
                        View(); break;
                    case "2": // Add 
                        Add(); break;
                    case "3": // Update
                        Update(); break;
                    case "4": // Remove
                        Remove(); break;
                    default: return;
                }
            }
        }

        public void View()
        {
            Console.WriteLine("Products list:");
            if (_products.Count == 0)
            {
                Console.WriteLine("Empty");
            }

            var i = 1;
            foreach (var item in _products)
                Console.WriteLine($"{i++} {item.Name} - ${item.Price} [{item.StockQty}]");
        }

        public void Add()
        {
            var name = GetInput<string>("Enter product Name:");
            var price = GetInput<double>("Enter product Price:");
            var qty = GetInput<int>("Enter product Qty:");

            _products.Add(new Product {
                Name = name,
                Price = price,
                StockQty = qty
            });
        }

        public void Update()
        {
            var id = GetInput<int>("Enter product No. to update:") - 1;
            if (id >= 0 && id < _products.Count)
            {
                var qty = GetInput<int>("Enter product Qty:");

                _products[id].StockQty = qty;
                Console.WriteLine($"Product qty updated: {qty}");
            }
            else 
            {
                Console.WriteLine("Invalid product No.");
            }
        }

        public void Remove()
        {
            var id = GetInput<int>("Enter product No. to remove:") - 1;
            if (id >= 0 && id < _products.Count)
            {
                var p = _products[id];
                _products.RemoveAt(id);
                Console.WriteLine($"Product {p.Name} removed");
            }
            else 
            {
                Console.WriteLine("Invalid product No.");
            }
        }

        private static T GetInput<T>(string message)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (typeof(T).Name.ToLower().Equals("string")) return (T)(input as object);
            return (T)Convert.ChangeType(input, typeof(T));
        }
    } 

}
