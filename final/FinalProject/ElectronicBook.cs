public class ElectronicBook : Book
{
    private bool _isAvailable;
    public ElectronicBook(string genre, string title, string author, string isbn, string type, bool isAvailable = false) : base(genre, title, author, isbn, type)
    {
        _isAvailable = isAvailable;
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


