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
        Books = new List<string>();
        DueDates = new Dictionary<string, DateTime>();
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

public class UserAccountManager
{
    private List<UserAccount> userAccounts;

    public UserAccountManager()
    {
        userAccounts = new List<UserAccount>();
        LoadUserAccounts();
    }

    private void LoadUserAccounts()
    {
        if (File.Exists("NormalUserAccounts.txt"))
        {
            string[] lines = File.ReadAllLines("NormalUserAccounts.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    string username = parts[0];
                    string password = parts[1];
                    if (decimal.TryParse(parts[2], out decimal fines))
                    {
                        // Extract the books and due dates data
                        List<string> books = new List<string>();
                        Dictionary<string, DateTime> dueDates = new Dictionary<string, DateTime>();

                        // Assuming the data format is: book1;dueDate1|book2;dueDate2|...
                        if (parts.Length >= 4)
                        {
                            string[] bookDuePairs = parts[3].Split('|');
                            foreach (string bookDuePair in bookDuePairs)
                            {
                                string[] bookDue = bookDuePair.Split(';');
                                if (bookDue.Length == 2)
                                {
                                    books.Add(bookDue[0]);
                                    if (DateTime.TryParse(bookDue[1], out DateTime dueDate))
                                    {
                                        dueDates[bookDue[0]] = dueDate;
                                    }
                                }
                            }
                        }

                        userAccounts.Add(new UserAccount(username, password, fines, books, dueDates));
                    }
                }
            }
        }
    }

    public void SaveUserAccounts()
    {
        // Save user accounts to a text file when needed.
        using (StreamWriter writer = new StreamWriter("NormalUserAccounts.txt"))
        {
            foreach (UserAccount user in userAccounts)
            {
                string booksAndDueDates = string.Join("|", user.Books.Select(book => $"{book};{user.DueDates[book]:yyyy-MM-dd}"));
                writer.WriteLine($"{user.Username} | {user.Password} | {user.Fines} | {booksAndDueDates}");
            }
        }
    }

    public void CreateUserAccount(string newUsername, string newPassword)
    {
        Console.WriteLine("Creating a new account...");
        UserAccount newUserAccount = new UserAccount(newUsername, newPassword, 0, new List<string>(), new Dictionary<string, DateTime>());
        userAccounts.Add(newUserAccount);
        SaveUserAccounts(); // Save user accounts after creating a new account.
        Console.WriteLine("User account created successfully.");
    }

    public UserAccount GetUserAccountByUsername(string username)
    {
        return userAccounts.Find(user => user.Username == username);
    }

    public bool ValidateUserAccount(string username, string password)
    {
        UserAccount user = GetUserAccountByUsername(username);
        
        if (user != null)
        {
            // Check if the provided password matches the stored password.
            if (user.Password == password)
            {
                return true;
            }
        }
        return false;
    }
}
