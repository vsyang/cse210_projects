public class UserInterface
{
    private Librarian librarian;
    private LibraryCatalog libraryCatalog;
    private UserAccountManager userAccountManager;
    private UserAccount currentUserAccount;
    

    public UserInterface()
    {
        // librarian = new Librarian(libraryCatalog);
        // libraryCatalog = new LibraryCatalog("AllBooks.txt"); 
        // userAccountManager = new UserAccountManager();  
    }

    public void Start()
    {   
        bool exit = false;
        while (!exit)
        {
            librarian = new Librarian(libraryCatalog);
            libraryCatalog = new LibraryCatalog("AllBooks.txt"); 
            userAccountManager = new UserAccountManager();  
            
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
                    Console.Write("Enter a username: ");
                    string newUsername = Console.ReadLine();
                    Console.Write("Enter a password: ");
                    string newPassword = Console.ReadLine();
                    //UserAccount userAccount = new UserAccount(newUsername, newPassword, 0, new List<string>(), new Dictionary<string, DateTime>());
                    userAccountManager.CreateUserAccount(newUsername, newPassword);
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
            LibrarianInterface();
        }
        else if (userAccountManager.ValidateUserAccount(username, password))
        {
            currentUserAccount = userAccountManager.GetUserAccountByUsername(username);
            Console.WriteLine($"Welcome back {username}!");
            NormalUserInterface();
        }
        else
        {
            Console.WriteLine("Incorrect username or password.");
        }
        return username;
    }

    public void LibrarianInterface()
    {
        Console.WriteLine();
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
                    librarian.RemoveBook();
                    break;

                case "3":
                    librarian.AddFine("", 0);
                    break;

                case "4":
                    librarian.RemoveFine("", 0);
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
        Console.WriteLine();
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


    public void NormalUserInterface()
    {
        Console.WriteLine();
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine("What to do today:");
            Console.WriteLine(" 1. Search for a book");
            Console.WriteLine(" 2. Borrow book");
            Console.WriteLine(" 3. Return book");
            Console.WriteLine(" 4. View fines/fees");
            Console.WriteLine(" 5. Return to main menu");
            Console.WriteLine("What would you like to do?");
            string normalUserInput = Console.ReadLine();

            switch (normalUserInput)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Here are the books at this library:");
                    libraryCatalog.LibraryCatalogList();
                    break;

                case "2":
                    Console.WriteLine();
                    Console.Write("Enter the title of the book you want to borrow: ");
                    string bookTitle = Console.ReadLine();

                    // Check if the checkout was successful
                    bool checkoutSuccess = currentUserAccount.CheckOutBook(bookTitle, libraryCatalog.Books, userAccountManager, currentUserAccount.Username);

                    if(checkoutSuccess)
                    {
                        userAccountManager.SaveUserAccounts();
                    }
                    break;

                case "3":
                    Console.WriteLine();
                    Console.WriteLine("Here are your books:");
                    if (currentUserAccount.Books.Count == 0)
                    {
                        Console.WriteLine("You haven't checked out any books.");
                    }
                    else
                    {
                        for (int i = 0; i < currentUserAccount.Books.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {currentUserAccount.Books[i]}");
                        }

                        // Ask the user to select a book to return
                        Console.Write("Enter the number of the book you want to return (or 0 to cancel): ");
                        if (int.TryParse(Console.ReadLine(), out int selectedBookIndex) && selectedBookIndex > 0 && selectedBookIndex <= currentUserAccount.Books.Count)
                        {
                            string selectedBookTitle = currentUserAccount.Books[selectedBookIndex - 1];

                            // Check if the return was successful
                            bool returnSuccess = currentUserAccount.ReturnBook(selectedBookTitle);
                            if (returnSuccess)
                            {
                                // Update the user's data and save it
                                currentUserAccount.Books.RemoveAt(selectedBookIndex - 1);
                                currentUserAccount.DueDates.Remove(selectedBookTitle);
                                userAccountManager.SaveUserAccounts();
                                Console.WriteLine($"You've successfully returned '{selectedBookTitle}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to return '{selectedBookTitle}'.");
                            }
                        }
                        else if (selectedBookIndex == 0)
                        {
                            Console.WriteLine("Return canceled.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid book number or 0 to cancel.");
                        }
                    }
                    break;

                case "4":
                    Console.WriteLine();
                    currentUserAccount.ViewFines();
                    break;

                case "5":
                    Console.WriteLine("\nThank you for visiting us!\nReturning to Main Menu");
                    quit = true;
                    break;
            }
        }
    }
}
