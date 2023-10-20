public abstract class Book
{
    private string _title;
    private string _author;
    private string _isbn;

    public Book(string title, string author, string isbn)
    {
        _title = title;
        _author = author;
        _isbn = isbn;
    }

    public abstract void Checkout();

    public abstract void Return();

    public abstract void Renew();
    public abstract void TurnInDate();
}


    
    // abstract class
// properties = title, author, isbn
// methods = Checkout(), Return(), Renew()


//ie:
//public abstract class Book
//{
//  public abstract void CheckOut(UserAccount user) //handle process of book being checked out
//}