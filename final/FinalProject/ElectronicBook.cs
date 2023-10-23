public class ElectronicBook : Book
{
    private bool _isAvailable;
    public bool IsAvailable { get; }
    public ElectronicBook(string genre, string title, string author, string isbn, string type, bool _isAvailable = true) : base(genre, title, author, isbn, type)
    {
        _isAvailable = IsAvailable;
    }

    public bool CheckoutElectronicBook(UserAccount userAccount, LibraryCatalog libraryCatalog)
    {
        if (_isAvailable)
        {
            // Attempt to check out the book from the library catalog.
            if (libraryCatalog.CheckoutBook(Title, userAccount))
            {
                _isAvailable = false;
                Console.WriteLine($"'{Title}' has been checked out by {userAccount.Username}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, '{Title}' is already checked out.");
            }
        }
        else
        {
            Console.WriteLine($"Sorry, '{Title}' is already checked out.");
        }
        return false;
    }
    public override void Checkout()
    {
        Console.WriteLine();
        Console.WriteLine("Electronic book has been checked out.");
        Console.WriteLine("You can access it on your device.");
    }

    public override void Return()
    {
        Console.WriteLine();
        Console.WriteLine("Electronic book has been returned.");
    }

    public override string Representation(string fileName)
    {
        return $"{_genre} | {_title} | {_author} | {_isbn} | {_type}";
    }
}
