using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            
            //found this while using Google: https://www.w3schools.com/cs/cs_switch.php#gsc.tab=0
            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string prompt = RandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    Console.WriteLine();
                    journal.AddEntry(new JournalEntry(DateTime.Now, prompt, response));
                    break;

                case "2":
                    // Display the journal
                    journal.DisplayEntries();
                    break;

                case "3":
                    // Save the journal to a file
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalEntry(saveFileName);
                    break;

                case "4":
                    // Load the journal from a file
                    Console.WriteLine("Enter a filename to load:");
                    Console.Write("> ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalEntry(loadFileName);
                    break;
                    // Ponder: would it be easier to have a pre-existing folder to save and load from so user just has to save and load without entering a filename?
                case "5":
                    // Quit
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static string RandomPrompt()
    {
        // List of prompts:
        List<string> prompts = new List<string>
        {
            "Who did you converse with today?",
            "What did you daydream about?",
            "What is the meal plan for today?",
            "How did you make today special?",
            "If you could travel anywhere, who would you take and why?",
            "How are you keeping up with your goals?",
            "What style did you choose today and why?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalEntry(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"Date: {entry.Date}");
                outputFile.WriteLine($"Prompt: {entry.Prompt}");
                outputFile.WriteLine($"Response: {entry.Response}");
                outputFile.WriteLine();
            }
        }
        Console.WriteLine("Journal entry saved.");
    }

    public void LoadJournalEntry(string fileName)
    {
        //makes sure we start with an empty list before loading entries to avoid confusion
        //read this on https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.clear?view=net-7.0
        //watched A LOT of youtube videos as well
        entries.Clear();
        using (StreamReader inputFile = new StreamReader(fileName))
        {
            string line;
            JournalEntry currentEntry = null;

            while ((line = inputFile.ReadLine()) != null)
            {
                if (line.StartsWith("Date: "))
                {
                    currentEntry = new JournalEntry(DateTime.Parse(line.Substring(6)), "", "");
                }
                else if (line.StartsWith("Prompt: "))
                {
                    currentEntry.Prompt = line.Substring(8);
                }
                else if (line.StartsWith("Response: "))
                {
                    currentEntry.Response = line.Substring(10);
                    entries.Add(currentEntry);
                }
            }
        }
        Console.WriteLine("Journal entry has been loaded. Select 2 to display.");
        Console.WriteLine();
    }
}
