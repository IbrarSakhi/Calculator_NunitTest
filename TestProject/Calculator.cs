using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class Calculator
    {
        public int Add(int number1, int number2)
        {
            return (number1 + number2);
        }
        public int Subtract(int number1, int number2)
        {
            return (number1 - number2);
        }
        public int Multiply(int number1, int number2)
        {
            return (number1 * number2);
        }
        public int Divide(int number1, int number2)
        {
            return (number1 / number2);
        }
    }
}
