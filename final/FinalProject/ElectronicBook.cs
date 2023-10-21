public class ElectronicBook : Book
{
    public ElectronicBook(string genre, string title, string author, string isbn, string type) : base(genre, title, author, isbn, type)
    {
        
    }

    public override void Checkout()
    {
        Console.WriteLine();
        Console.WriteLine("Book has been checked out.");
    }

    public override void Return()
    {
        Console.WriteLine();
        Console.WriteLine("Book has been returned.");
    }

    public override void Renew()
    {
        Console.WriteLine();
        Console.WriteLine("Book has been renewed");
    }

    public override void TurnInDate()
    {
        Console.WriteLine();
        Console.WriteLine("Book due by *date 3 weeks from checkout date*");   
    }

        public override string Representation(string fileName)
    {
        return $"{_genre} | {_title} | {_author} | {_isbn} | {_type}";
    }
}


