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

    public bool CheckOutBook(string _title, List<Book> libraryCatalog, UserAccountManager userManager, string username)
    {
        // Check if the book exists in the library catalog
        Book bookToCheckout = libraryCatalog.FirstOrDefault(book => book.Title == _title);

        if (bookToCheckout == null)
        {
            Console.WriteLine("The book you requested is not available in the library catalog.");
            return false;
        }

        // Check if the book is already checked out
        if (Books.Contains(_title))
        {
            Console.WriteLine("You've already checked out this book.");
            return false;
        }

        // Calculate the due date based on book type
        DateTime dueDate;

        if (bookToCheckout is PhysicalBook)
        {
            dueDate = DateTime.Now.AddDays(10);
        }
        else if (bookToCheckout is ElectronicBook)
        {
            dueDate = DateTime.Now.AddDays(14);
        }
        else
        {
            Console.WriteLine("Unsupported book type.");
            return false;
        }

        Books.Add(_title);
        DueDates[_title] = dueDate;

        // Format the due date
        string newDateFormat = dueDate.ToString("MM-dd-yyyy");

        Console.WriteLine($"You've checked out '{_title}'\nReturn book by {newDateFormat}.");

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

        return true;
    }

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
