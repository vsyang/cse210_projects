public class PhysicalBook : Book
{
    public PhysicalBook(string title, string author, string isbn) : base(title, author, isbn)
    {

    }
 
    public override void Checkout()
    {
        Console.WriteLine();
        //public override void Checkout(UserAccount user) //update status to checked out
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


// inherit from Book
// manage the circulation of physical books

//{
//}