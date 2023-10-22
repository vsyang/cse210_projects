public abstract class Book
{
    protected string _genre;
    protected string _title;
    protected string _author;
    protected string _isbn;
    protected string _type;
    public string Genre
    {
        get { return _genre; }
    }
    public string Title
    {
        get { return _title; }
    }
    public string Author
    {
        get { return _author; }
    }
    public string ISBN
    {
        get { return _isbn; }
    }
    public string Type
    {
        get {return _type; }
    }

    


    public Book(string genre, string title, string author, string isbn, string type)
    {
        _genre = genre;
        _title = title;
        _author = author;
        _isbn = isbn;
        _type = type;
    }

    public abstract void Checkout();

    public abstract void Return();

    public abstract void TurnInDate();
    
    public abstract string Representation(string fileName);
}

