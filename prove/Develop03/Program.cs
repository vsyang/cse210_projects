using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[]lines = File.ReadAllLines("kjv.txt");
        List<string> scriptures = new List<string>();
        foreach (string line in lines)
        {
            scriptures.Add(line);
        }
               
        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        string selectedScripture = scriptures[randomIndex];

        //split whole string to seperate scripture reference from verse
        string[] parts = selectedScripture.Split(' ');
        string scriptureReference = parts[0] + " " + parts[1];
        string restOfScripture = string.Join(" ", parts, 2, parts.Length - 2);

        Reference reference = new Reference(scriptureReference);
        Scripture scripture = new Scripture(reference, restOfScripture);

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            //Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
            //string user = Console.ReadLine();

            if(scripture.IsCompletelyHidden())
            {
                quit = true;
            }    
            else  
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
                string user = Console.ReadLine();

                if(user.ToLower() == "quit")
                {
                    quit = true;
                }
                else
                {
                    scripture.HideRandomWords(1);
                }
            }        
        }
    }
}