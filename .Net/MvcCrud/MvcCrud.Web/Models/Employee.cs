namespace MvcCrud.Web.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public DateTime DateOfBirth { get; set; }




    }
}
