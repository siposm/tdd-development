using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_tdd
{
    public class TooBigInputException: Exception
    {
        public TooBigInputException(string msg) : base(msg) { }
    }

    public class ZeroDivisionException : Exception
    {
        public ZeroDivisionException(string msg) : base(msg) { }
    }

    public class Calculator
    {
        public List<string> History { get; private set; }

        public Calculator()
        {
            this.History = new List<string>();
        }

        public int Addition(int a, int b)
        {
            if (a > 1000 || b > 1000)
                throw new TooBigInputException("[ERR] One of the inputs was too big.");
            else
            {
                this.History.Add($"addition ({a},{b})");
                return a + b;
            }
        }

        public double Division(int a, int b)
        {
            if (b == 0)
                throw new ZeroDivisionException("[ERR] Can't divide by zero.");
            else
            {
                this.History.Add($"division ({a},{b})");
                return (double)a / b;
            }
        }

        public void ClearMemory()
        {
            this.History.RemoveRange(0, this.History.Count);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
