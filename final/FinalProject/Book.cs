public abstract class Book
{
    protected string _genre;
    protected string _title;
    protected string _author;
    protected string _isbn;
    protected string _type;

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

    public abstract void Renew();
    public abstract void TurnInDate();
    public abstract string Representation(string fileName);
}


    
    // abstract class
// properties = title, author, isbn
// methods = Checkout(), Return(), Renew()


//ie:
//public abstract class Book
//{
//  public abstract void CheckOut(UserAccount user) //handle process of book being checked out
//}