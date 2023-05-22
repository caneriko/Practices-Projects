using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
    }
}
