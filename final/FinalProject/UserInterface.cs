using System.Collections.Generic;

public class UserInterface
{
    private Dictionary<string, string> _userAccount;
    private Dictionary<string, string> _librarian;

    public UserInterface()
    {
        _userAccount = new Dictionary<string, string>();
        _librarian = new Dictionary<string, string>()
        
        {
            {"Vanessa5280", "ILoveBooks"},
            {"Matty303", "HuntNFish"},
            {"LilyBoo", "SmartAndLovely"},
            {"MylaBaby", "BeautifulStrength"},
            {"JinuNatsu", "NeverLeaveMom"},
        };
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
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

    private void SignIn()
    {        
        Console.WriteLine();
        
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (_librarian.ContainsKey(username) && _librarian[username] == password)
        {
            Console.WriteLine("Welcome back *Librarian*!");
            LibrarianInterface();
        }
        else if (_userAccount.ContainsKey(username) && _userAccount[username] == password)
        {
            Console.WriteLine("Welcome back *User*!");
            NormalUserInterface();
        }
        else
        {
            Console.WriteLine("Incorrect username or password.");
        }
    }

    public void LibrarianInterface()
    {
        Console.WriteLine();
        Console.WriteLine("");
    }

    public void NormalUserInterface()
    {
        Console.WriteLine();
        Console.WriteLine("");
    }

}




//*user*
//Search()
//Borrow()
//Renew()
//Return()
//CheckFines()

//*librarian*
// AddBook()
// RemoveBook()
// FinesCalculator()



