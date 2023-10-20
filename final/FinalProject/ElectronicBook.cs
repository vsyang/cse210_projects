public class ElectronicBook : Book
{
    public ElectronicBook(string title, string author, string isbn) : base(title, author, isbn)
    {
        
    }

    public override void Checkout()
    {
        Console.WriteLine();
    }

    public override void Return()
    {

    }

    public override void Renew()
    {

    }

    public override void TurnInDate()
    {
        
    }
}


//inherit from Book
// manage the circulation of digital books

//{
//      public override void Checkout(UserAccount user) // control number of allowed downloads
//}