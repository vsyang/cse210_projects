public class Librarian
{
    private Dictionary<string, string> _librarian;
    private Dictionary<string, decimal> _userFines;
    private LibraryCatalog _libraryCatalog;
    private FinesCalculator finesCalculator;
    private UserAccountManager userAccountManager;


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
        finesCalculator = new FinesCalculator();
        userAccountManager = new UserAccountManager();
    }

    public bool IsLibrarian(string username, string password)
    {
        return _librarian.ContainsKey(username) && _librarian[username] == password;
    }

    public void AddFine(string username, decimal amount)
    {
        Console.WriteLine();
        Console.WriteLine("Enter the username of the customer to add a fine: ");
        string input = Console.ReadLine();

        // Look for the user in the user accounts managed by the UserAccountManager.
        UserAccount userAccount = userAccountManager.GetUserAccountByUsername(input);

        if (userAccount != null)
        {
            // Calculate the fine - don't have time to be fancy so only charging for lost books
            decimal fine = finesCalculator.CalculateLostBookFine(amount);
            
            //userAccount.ApplyFine(amount);
            userAccountManager.AddUserFine(input, fine);

            Console.WriteLine($"Fine of ${fine} added to {input}'s account for a lost book.");
        }
        else
        {
            Console.WriteLine($"{input} not found. No fine added.");
        }
    }

    public void RemoveFine(string username, decimal amount)
    {
        Console.WriteLine();
        Console.WriteLine("Enter the username of the customer to add a fine: ");
        string input = Console.ReadLine();

        // Look for the user in the user accounts managed by the UserAccountManager.
        UserAccount userAccount = userAccountManager.GetUserAccountByUsername(input);

        if (userAccount != null)
        {
            amount -= 13;
            userAccountManager.RemoveUserFine(input, amount);

            // Ensure fines are non-negative.
            if (userAccount.Fines < 0)
            {
                userAccount.Fines = 0;
            }
            Console.WriteLine($"Fine of ${amount} removed from {input}'s account.");
        }
        else
        {
            Console.WriteLine($"{input} does not have any fines.");
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
