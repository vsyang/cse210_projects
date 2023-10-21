public class Librarian
{
    private string _username;
    private int _fines;
    private Dictionary<string, decimal> _userFines;// need to figure out how to charge user if they owe fines
    
    public Librarian()
    {
        //_username = username;
        //_fines = fines;
        _userFines = new Dictionary<string, decimal>();
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
    }

    public void AddBook(string genre, string title, string author, string isbn, LibraryCatalog catalog, string type)
    {
        // Book book;
        // if (isElectronic)
        // {
        //     book = new ElectronicBook(genre, title, author, isbn, type);
        // }
        // else
        // {
        //     book = new PhysicalBook(genre, title, author, isbn, type);
        // }
        // catalog.AddBook(book);
    }

}

