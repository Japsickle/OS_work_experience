using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCypherProject
{
    public class Validator
    {
        private string word;
        //private int key;

        public Validator(string userInput)//, int shiftValue)
        {
            word = userInput;
            //key = shiftValue;
        }
        public bool Validate()
        {
            bool isValid = false;
            if (!word.Contains(" "))
            {
                isValid = true;
            }
            else if (word.Contains(" "))
            {
                Console.WriteLine("You need to input 1 word");
            }

            return isValid;
        }


    }






}
