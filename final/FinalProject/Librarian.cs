public class Librarian
{
    private Dictionary<string, string> _librarian;
    private Dictionary<string, decimal> _userFines;
    private LibraryCatalog _libraryCatalog;


    public Librarian(LibraryCatalog libraryCatalog)
    {
            _libraryCatalog = libraryCatalog;
            _librarian = new Dictionary<string, string>()
        
        {
            {"Vanessa", "ILoveBooks"},
            {"Matty303", "HuntNFish"},
            {"LilyBoo", "SmartAndLovely"},
            {"MylaBaby", "BeautifulStrength"},
            {"JinuNatsu", "NeverLeaveMom"},
            {"test", "test"}
        };

        _userFines = new Dictionary<string, decimal>();
    }

    public bool IsLibrarian(string username, string password)
    {
        return _librarian.ContainsKey(username) && _librarian[username] == password;
    }

    public void AddFine(string username, decimal amount)
    {
        Console.WriteLine();
        Console.WriteLine("Which user to add Fine: ");
        
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

    public void AddBook(string genre, string title, string author, string isbn, LibraryCatalog catalog, string type)
    {
        {
            Console.Write("Genre: ");
            string _genre = Console.ReadLine();

            Console.Write("Title: ");
            string _title = Console.ReadLine();

            Console.Write("Author: ");
            string _author = Console.ReadLine();

            Console.Write("ISBN: ");
            string _isbn = Console.ReadLine();
            
            Console.Write("Is this book \n  1. Physical\n  2. Electronic\n  >");
            string addInput = Console.ReadLine();


            if (addInput == "1" || addInput == "2")
            {
                string _type = addInput == "1" ? "Physical" : "Electronic";
                _libraryCatalog.AddBook(genre, title, author, isbn, type);
                Console.WriteLine("New book has been added to the library catalog.");
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

    }

public void RemoveBook()
    {
        // Call LibraryCatalogList to display the library catalog
        _libraryCatalog.LibraryCatalogList();

        Console.WriteLine();
        Console.WriteLine("Library Catalog");

        // Display the list of books
        for (int i = 0; i < _libraryCatalog.Books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_libraryCatalog.Books[i].Title} by {_libraryCatalog.Books[i].Author}");
        }

        Console.Write("\nWhich book needs to be removed? Enter the number: ");
        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            if (selection > 0 && selection <= _libraryCatalog.Books.Count)
            {
                int index = selection - 1;
                _libraryCatalog.Books.RemoveAt(index);
                _libraryCatalog.UpdateLibraryFile();

                Console.WriteLine("The selected book has been removed from the library");
            }
            else
            {
                Console.WriteLine("Invalid book selection");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}

