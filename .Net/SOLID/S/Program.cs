using System.Xml.Linq;

namespace S
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new ProductRepository();
            var presenter = new ProductPresenter();
            presenter.WriteToConsole(repo.GetProducts());
        }
    }

    public class Product
    {
        public  int Id { get; set; }

        public string Name { get; set; }


    }


    public class ProductRepository
    {
        private List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product() { Id = 1, Name="Iphone14Pro"},
                new Product() { Id = 2, Name="GalaxyS23"},
                new Product() { Id = 3, Name="NokiaX30"}
            };
        }


        public List<Product> GetProducts()
        {
            return products;
        }

        public void Create(Product product)
        {
            Console.WriteLine("new item saved");
        }

        public void Delete(int id)
        {
            Console.WriteLine("item has been deleted");
        }

    }

    public class ProductPresenter
    {
        public void WriteToConsole(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"Id: {item.Id} - Name: {item.Name}");
            }
        }
    }

}