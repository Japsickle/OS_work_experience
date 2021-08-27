using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Random number = new Random();
            int randomNumber = number.Next(1, 51);
            //Console.WriteLine(randomNumber);
            Console.WriteLine("Guess a random number from 1 to 50 -> ");
            int userNumber = Convert.ToInt32(Console.ReadLine());

            if (userNumber == randomNumber)
            {
                Console.WriteLine("Well done you guessed it");
            }
            else
            {
                Console.WriteLine($"You didn't guess the number because it was {randomNumber} \n You have 5 more tries -> ");
                int count = 4;
                while (count != 0)
                {
                    //Random number = new Random();
                    //randomNumber = number.Next (1, 51);
                    //Console.WriteLine(randomNumber);
                    Console.WriteLine("Guess a random number from 1 to 50 -> ");
                    userNumber = Convert.ToInt32(Console.ReadLine());

                    if (userNumber == randomNumber)
                    {
                        Console.WriteLine("Well done you guessed it");
                     
                        break;

                    }
                    else
                    {
                        Console.WriteLine($"You didn't guess the number because it was {randomNumber}");
                    }
                    count--;
                }
            }
            */

            //Sam's Code
            /*
            Random rnd = new Random();
            int num = rnd.Next(0, 100);

            int guess;
            int count = 5;

            do
            {
                Console.WriteLine("Please make a guess:");
                guess = int.Parse(Console.ReadLine());

                if (guess > num)
                    Console.WriteLine("Too High.");
                else if (guess < num)
                    Console.WriteLine("Too Low.");
            } while (guess != num && --count > 0);

            if (guess == num)
                Console.WriteLine("Correct!");
            else
                Console.WriteLine($"Game Over! The number was {num}")

            */










            Random number = new Random();
            int randomNumber = number.Next(1, 51);
            int count = 5;
            while (count != 0)
            {
                //Console.WriteLine(randomNumber); #For Debugging
                Console.WriteLine("Guess a random number from 1 to 50 -> ");
                int userNumber = Convert.ToInt32(Console.ReadLine());

                if (userNumber == randomNumber)
                {
                    Console.WriteLine("Well done you guessed it");
                    break;
                }
                else
                {
                    //Console.WriteLine($"The number was actually {randomNumber}");
                    Console.WriteLine($"You didn't guess the number");
                    if (userNumber < randomNumber)
                    {
                        Console.WriteLine("Too Low");
                    }
                    else if (userNumber > randomNumber)
                    {
                        Console.WriteLine("Too High");
                    }
                }
                count--;
            }

            if (count == 0)
            {
                Console.WriteLine($"The number was actually {randomNumber}");

            }







            Console.ReadLine();
        }
    }
}
