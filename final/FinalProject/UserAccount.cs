public class UserAccount
{
    public string Username { get; }
    public string Password { get; }
    public decimal Fines { get; set; }
    public List<string> Books { get; set; }
    public Dictionary<string, DateTime> DueDates { get; set; } // Track due dates for checked-out books

    public UserAccount(string username, string password, decimal fines, List<string> books, Dictionary<string, DateTime> dueDates)
    {
        Username = username;
        Password = password;
        Fines = fines;
        Books = books;
        DueDates = dueDates;
    }

    // Method to check out a book
    public bool CheckOutBook(string bookTitle, DateTime dueDate)
    {
        // Check if the book is already checked out
        if (Books.Contains(bookTitle))
        {
            Console.WriteLine("You've already checked out this book.");
            return false;
        }

        // Check if the due date is valid (e.g., not in the past)
        if (dueDate < DateTime.Now)
        {
            Console.WriteLine("Invalid due date. Please select a future date.");
            return false;
        }

        Books.Add(bookTitle);
        DueDates[bookTitle] = dueDate;
        Console.WriteLine($"You've checked out '{bookTitle}' until {dueDate:yyyy-MM-dd}.");
        return true;
    }

    // Method to return a book
    public bool ReturnBook(string bookTitle)
    {
        // Check if the user has checked out the book
        if (!Books.Contains(bookTitle))
        {
            Console.WriteLine("You haven't checked out this book.");
            return false;
        }

        DateTime dueDate = DueDates[bookTitle];
        DateTime currentDate = DateTime.Now;

        Books.Remove(bookTitle);
        DueDates.Remove(bookTitle);
        Console.WriteLine($"You've successfully returned '{bookTitle}'.");

        return true;
    }

    // public void ApplyFine(decimal amount)
    // {
    //     if (amount < 0)
    //     {
    //         Console.WriteLine("Invalid fine amount.");
    //         return;
    //     }

    //     // Update the user's fines.
    //     Fines += amount;
    // }

    // Method to view fines
    public void ViewFines()
    {
        if (Fines == 0)
        {
            Console.WriteLine("You have no fines.");
        }
        else
        {
            Console.WriteLine($"Your current fines: ${Fines}");
        }
    }
}

