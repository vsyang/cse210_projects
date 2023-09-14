using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        // *Use static for all functions*
        // ✓1. DisplayWelcome - Displays the message, "Welcome to the Program!"
        // ✓2. PromptUserName - Asks for and returns the user's name (as a string)
        // ✓3. PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
        // ✓4. SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
        // ✓5. DisplayResult - Accepts the user's name and the squared number and displays them.
        DisplayWelcomeMessage();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int NumberSquared = SquareNumber(number);

        DisplayResult(name, NumberSquared);

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Program");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        
        static int SquareNumber(int number)
        {
            int NumberSquared = number * number;
            return NumberSquared;
        }

        static void DisplayResult(string name, int NumberSquared)
        {
            Console.WriteLine($"{name}, the square of your number is {NumberSquared}.");
        }

    }
}