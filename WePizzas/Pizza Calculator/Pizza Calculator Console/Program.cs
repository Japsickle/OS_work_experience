using System.Collections.Generic;

namespace Pizza_Calculator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaCalculator calculator = new PizzaCalculator();
            List<string> tempToppings = calculator.GetToppingsFor("dog food");



        }
    }
}
