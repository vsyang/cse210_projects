using System.IO.Enumeration;

public class Journal
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