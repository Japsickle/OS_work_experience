using System;
using System.Collections.Generic;

namespace Pizza_Calculator_Console
{
    public class PizzaCalculator
    {

        public List<string> GetToppingsFor(string userInput)
        {
            string userInputLower = userInput.ToLower();

            if (userInputLower != "hawaiian" && userInputLower!= "greek" && userInputLower != "margarita")
            {
                string message = $"{userInput} is not on the menu";
                throw new Exception(message); 
            }



            List<string> toppings = new List<string>();
            toppings.Add("Cheese");
            toppings.Add("Tomato");


            if (userInputLower == "hawaiian")
            {
                toppings.Add("Pineapple");
                toppings.Add("Ham");
            }
            else if (userInputLower == "greek")
            {
                toppings.Add("Olives");
                toppings.Add("Feta");
                toppings.Add("Rocket");
            }
            return toppings;
        }
    }
}
