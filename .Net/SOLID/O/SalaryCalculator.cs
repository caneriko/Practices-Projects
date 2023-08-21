using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O
{
    public class SalaryCalculator
    {

        public decimal Calculate(decimal baseSalary, ICalculator calculator)
        {
            return calculator.Calculate(baseSalary);
        }

    }


    public interface ICalculator
    {
        decimal Calculate(decimal salary);
    }

    public class JuniorSalary : ICalculator
    {
        public decimal Calculate(decimal salary)
        {
            return salary*2 ;
        }
    }

    public class MidSalary : ICalculator
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 3;
        }
    }

    public class SeniorSalary : ICalculator
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 4;
        }
    }

}
