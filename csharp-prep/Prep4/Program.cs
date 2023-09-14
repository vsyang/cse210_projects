using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();
        int userInput =-1;
        
        while (userInput != 0)
        {
            Console.Write("Enter a list of numbers, type 0 when finished. ");
            string number = Console.ReadLine();
            userInput = int.Parse(number);

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        // Core requirement 1 sum or total
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}.");

        // Core requirement 2 average
        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"The average is: {average}.");

        // Core requirement 3 maximum
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The biggest number is: {max}.");


    }
}