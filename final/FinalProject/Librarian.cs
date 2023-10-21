public class Librarian
{
    private Dictionary<string, string> _librarian;
    private Dictionary<string, decimal> _userFines;


    public Librarian()
    {
            _librarian = new Dictionary<string, string>()
        
        {
            {"Vanessa5280", "ILoveBooks"},
            {"Matty303", "HuntNFish"},
            {"LilyBoo", "SmartAndLovely"},
            {"MylaBaby", "BeautifulStrength"},
            {"JinuNatsu", "NeverLeaveMom"},
        };

        _userFines = new Dictionary<string, decimal>();
    }

    public bool IsLibrarian(string username, string password)
    {
        return _librarian.ContainsKey(username) && _librarian[username] == password;
    }

    public void AddFine(string username, decimal amount)
    {
        if (_userFines.ContainsKey(username))
        {
            _userFines[username] += amount;
        }
        else
        {
            _userFines[username] = amount;
        }
        Console.WriteLine($"Fine of ${amount} added to {username}'s account.");
    }

    public void RemoveFine(string username, decimal amount)
    {
        if (_userFines.ContainsKey(username))
        {
            _userFines[username] -= amount;
            if (_userFines[username] < 0)
            {
                _userFines[username] = 0; // Fines cannot be negative
            }
            Console.WriteLine($"Fine of ${amount} removed from {username}'s account.");
        }
        else
        {
            Console.WriteLine($"{username} does not have any fines.");
        }
    }

    // You can add more methods here for librarian-specific actions.


    public void AddBook(string genre, string title, string author, string isbn, LibraryCatalog catalog, string type)
    {
        if (type == "Physical")
        {
            PhysicalBook physicalBook = new PhysicalBook(genre, title, author, isbn, type);
            catalog.AddBook(genre, title, author, isbn, type);
        }
        else if (type == "Electronic")
        {
            ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
            catalog.AddBook(genre, title, author, isbn, type);
        }
        else
        {
            Console.WriteLine("Unsupported book type");
        }
    }

    public void RemoveBook()
    {
        
    }
}

