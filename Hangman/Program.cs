using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string abc = "abcdefghijklmnopqrstuvwxyz";
            //char[] abc = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string[] wordlist = File.ReadAllLines(@"Wordlist.txt");
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(0, wordlist.Length);
            string word = wordlist[randomNumber];
            string stars = word;
            foreach (char i in stars)
            {
                stars = stars.Replace(i, '*');
            }
            Console.WriteLine(word);
            Console.WriteLine($"There are {word.Length} letters\n{stars}");
            int limbs = 6;
            while (limbs != 0)
            {
                switch (limbs)
                {
                    case 6:
                        Console.WriteLine("  +---+  \n  |   |\n      |\n      |\n      |\n      |\n      |\n=========");
                        break;
                    case 5:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n      |\n      |\n      |\n      |\n=========");
                        break;
                    case 4:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n  |   |\n      |\n      |\n      |\n=========");
                        break;
                    case 3:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|   |\n      |\n      |\n      |\n=========");
                        break;
                    case 2:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|\\  |\n      |\n      |\n      |\n=========");
                        break;
                    case 1:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n      |\n=========");
                        break;
                    case 0:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n      |\n=========");
                        break;
                    /*case 0:
                        Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|\\  |\n      |\n      |\n      |\n=========");
                        break;*/
                }
                Console.WriteLine("Take your guess -> ");
                string userGuess = Console.ReadLine();

                userGuess = userGuess.ToLower();
                Console.WriteLine(userGuess);
                char letter = userGuess[0];


                if (word.Contains(userGuess))
                {
                    for (int characterPosition = 0; characterPosition < word.Length; characterPosition++)
                    {
                        if (letter == word[characterPosition])
                        {
                            StringBuilder sb = new StringBuilder(stars);
                            sb[characterPosition] = letter;
                            stars = sb.ToString();
                        }
                    }
                    Console.WriteLine($"\n{stars}");
                    word = word.Replace(letter, ' ');
                    if (stars == wordlist[randomNumber])
                    {
                        break;
                    }
                }
                else if (!abc.Contains(letter))
                {
                    //string xyz = new string(abc);
                    Console.WriteLine(abc);
                    Console.WriteLine("That letter has already been chosen");
                    //abc = xyz;
                }
                else
                {
                    limbs--;
                    Console.WriteLine($"The man now has {limbs} limbs");
                }
                abc = abc.Replace(letter, ' ');
            }
            if (limbs == 0)
            {
                //Console.WriteLine("  +---+  \n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n      |\n=========");
                Console.WriteLine($"  +---+  \n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n      |\n=========\nYou Failed to guess the word -> {wordlist[randomNumber]}");
            }
            else
            {
                Console.WriteLine($"Success! \nYou guessed the word -> {wordlist[randomNumber]}");
            }
            Console.ReadLine();
        }


    }
}
