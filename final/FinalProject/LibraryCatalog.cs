public class LibraryCatalog
{
    private List<PhysicalBook> _physicalBooks;
    private List<ElectronicBook> _electronicBooks;

    public LibraryCatalog()
    {
        _physicalBooks = new List<PhysicalBook>();
        _electronicBooks = new List<ElectronicBook>();
    }
}


// manages library collection
// add new books- AddBook()
// remove damaged books -RemoveBook()
// cataloging books- Search()