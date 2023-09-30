using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[]lines = File.ReadAllLines("kjv.txt").Skip(5).Skip(7219 - 6).Skip((10258 - 7219 + 1) - 1).Skip(29567 - 28370).Skip((29898 - 29567 + 1) - 1).ToArray();
        
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

        string scriptureReference;
        string restOfScripture;
        
        if (parts.Length >= 3 && (parts[0] == "1" || parts[0] == "2" || parts[0] == "3"))
        {
            scriptureReference = parts[0] + " " + parts[1] + " " + parts[2];
            restOfScripture = string.Join(" ", parts, 3, parts.Length - 3);
        }
        else
        {
            scriptureReference = parts[0] + " " + parts[1];
            restOfScripture = string.Join(" ", parts, 2, parts.Length - 2);
        }
        
        
        restOfScripture = restOfScripture.Replace("¶", "").Replace("‹", "").Replace("›", "").Replace("[", "").Replace("]", "");

        Reference reference = new Reference(scriptureReference);
        Scripture scripture = new Scripture(reference, restOfScripture);

        int wordCount = scripture.WordCount;

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());

            if(scripture.IsCompletelyHidden())
            {
                quit = true;
            }    
            else  
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
                string user = Console.ReadLine();

                if(user.ToLower() == "quit")
                {
                    quit = true;
                }
                else
                {
                    scripture.HideRandomWords(3);
                    if(scripture.WordCount <= 2)
                    {
                        scripture.HideAllWords();
                    }
                }
            }        
        }
    }
}