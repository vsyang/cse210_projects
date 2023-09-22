using System;

Journal journal = new Journal();
RandomPrompt promptGenerator = new RandomPrompt();

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
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("> ");
            string response = Console.ReadLine();
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
