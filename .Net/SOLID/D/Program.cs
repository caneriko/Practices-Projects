namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cooker = new FoodMachine(new Kebab());
            cooker.Make();
        }
    }



    public class Cake : IFood
    {
        public void Make()
        {
            Console.WriteLine("Cake is in the oven");
        }
    }

    public class Kebab : IFood
    {
        public void Make()
        {
            Console.WriteLine("kebab is on the grill");
        }
    }

    public interface IFood
    {
        void Make();
    }

    public class FoodMachine 
    {
        private readonly IFood _food;

        public FoodMachine(IFood food)
        {
            _food = food;
        }

        public void Make()
        {
            _food.Make();
        }
    }



}