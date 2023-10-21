public class UserInterface
{
    private Dictionary<string, string> _userAccount;
    private Librarian librarian;
    private LibraryCatalog libraryCatalog;
    

    public UserInterface()
    {
        _userAccount = new Dictionary<string, string>();
        librarian = new Librarian();
        libraryCatalog = new LibraryCatalog("AllBooks.txt");        
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            libraryCatalog.LoadBooks("AllBooks.txt");

            Console.WriteLine();
            Console.WriteLine("Welcome to the Library!");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Sign In");
            Console.WriteLine(" 2. Create An Account");
            Console.WriteLine(" 3. Exit");
            Console.WriteLine("Select a choice from the menu: ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                SignIn();
                break;

                case "2":
                //CreateAccount();
                break;

                case "3":
                exit = true;
                break;


            }
        }
    }

    private string SignIn()
    {        
        Console.WriteLine();
        
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (librarian.IsLibrarian(username, password))
        {
            Console.WriteLine();
            Console.WriteLine($"Welcome back {username}!");
            LibrarianInterface(username);
        }
        else if (_userAccount.ContainsKey(username) && _userAccount[username] == password)
        {
            Console.WriteLine($"Welcome back {username}!");
            NormalUserInterface();
        }
        else
        {
            Console.WriteLine("Incorrect username or password.");
        }
        return username;
    }

    public void LibrarianInterface(string username)
    {
        Console.WriteLine(username);
        bool quit = false;
        while (!quit)
        {

            Console.WriteLine();
            Console.WriteLine("Librarian Menu Options:");
            Console.WriteLine(" 1. Add book to library catalog");
            Console.WriteLine(" 2. Remove book from library catalog");
            Console.WriteLine(" 3. Add fine to user account");
            Console.WriteLine(" 4. Remove fine on user account");
            Console.WriteLine(" 5. Back to main menu");
            Console.WriteLine("Select a choice from the menu: ");

            string librarianInput = Console.ReadLine();
            
            switch (librarianInput)
            {
                case "1":
                    AddBook();
                    break;

                case "2":
                    RemoveBook();
                    break;

                case "3":
                    //AddFine();
                    break;

                case "4":
                    //RemoveFine();
                    break;

                case "5":
                    Console.WriteLine("Returning to main menu");
                    quit = true;
                    break;            
            }
        }
    }

    public void AddBook()
    {
        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        
        Console.Write("Is this book \n  1. Physical\n  2. Electronic\n  >");
        string addInput = Console.ReadLine();


        if (addInput == "1" || addInput == "2")
        {
            string type = addInput == "1" ? "Physical" : "Electronic";
            libraryCatalog.AddBook(genre, title, author, isbn, type);
            Console.WriteLine("New book has been added to the library catalog.");
        }

        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void RemoveBook()
    {
        libraryCatalog.RemoveBook();
    }


    public void NormalUserInterface()
    {
        Console.WriteLine();
        Console.WriteLine("");
    }

}

