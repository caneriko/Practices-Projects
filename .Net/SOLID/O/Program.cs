namespace O
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var salaryCalculator = new SalaryCalculator();

            Console.WriteLine($"Junior Salary: {salaryCalculator.Calculate(1500, new JuniorSalary())}");
            Console.WriteLine($"Mid Salary: {salaryCalculator.Calculate(1500, new MidSalary())}");
            Console.WriteLine($"Senior Salary: {salaryCalculator.Calculate(1500, new SeniorSalary())}");

        }
    }
}