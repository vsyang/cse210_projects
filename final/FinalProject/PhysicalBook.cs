public class PhysicalBook : Book
{
    private bool _isAvailable;
    public bool IsAvailable { get;}

    public PhysicalBook(string genre, string title, string author, string isbn, string type, bool isAvailable = true)
        : base(genre, title, author, isbn, type)
    {
        _isAvailable = isAvailable;
    }

    public bool CheckoutPhysicalBook(UserAccount userAccount, LibraryCatalog libraryCatalog)
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
        Console.WriteLine("The book has been checked out.");
    }

    public override void Return()
    {
        if (_isAvailable)
        {
            _isAvailable = true;
            Console.WriteLine($"'{Title}' has been returned.");
        }
        else
        {
            Console.WriteLine($"'{Title}' is not checked out.");
        }
    }

    public override string Representation(string fileName)
    {
        return $"{Genre} | {Title} | {Author} | {ISBN} | {Type}";
    }
}
