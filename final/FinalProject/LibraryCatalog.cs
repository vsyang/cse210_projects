using System.IO.Enumeration;

public class LibraryCatalog
{
    private string _fileName;
    private List <Book> _books;
    public List<Book> Books
    {
        get { return _books; }
    }

    public LibraryCatalog(string fileName)
    {
        _books = new List<Book>();
        _fileName = fileName;
        LoadBooks();
    }

    public void AddBook(string genre, string title, string author, string isbn, string type)
    {
        string fileName = "AllBooks.txt";
        //File.WriteAllText(fileName, string.Empty);
        using (StreamWriter writer = File.AppendText(fileName))
        {
            string bookData = $"{genre} | {title} | {author} | {isbn} | {type}";
            writer.WriteLine(bookData);
        }
        if (type == "Physical")
        {
            PhysicalBook physicalBook = new PhysicalBook(genre, title, author, isbn, type);
            _books.Add(physicalBook);
            ;
        }
        else if (type == "Electronic")
        {
            ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
            _books.Add(electronicBook);
        }
        else 
        {
            Console.WriteLine("Unsupported book type");
        }
    }

    public void LoadBooks()
    {
        Console.WriteLine();
        _books.Clear();
        string fileName = "AllBooks.Txt";
        using (StreamReader inputFile = new StreamReader(fileName))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] bookData = line.Split ('|');

                if (bookData.Length < 2)
                {
                    continue;
                }

                string genre = bookData[0].Trim();
                string title = bookData[1].Trim();
                string author = bookData[2].Trim();
                string isbn = bookData[3].Trim();
                string type = bookData[4].Trim();

                Book newBook = null;
                if (type == "Physical")
                {
                    newBook = new PhysicalBook(genre, title, author, isbn, type);
                    _books.Add(newBook);
                }
                else if (type == "Electronic")
                {
                    newBook = new ElectronicBook(genre, title, author, isbn, type);
                    _books.Add(newBook);
                }
            }
        }
    }
    
    public void LibraryCatalogList()
    {
        Console.WriteLine();
        LoadBooks();
        for (int i = 0; i < _books.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_books[i].Title} by {_books[i].Author}");
        }        
    }

    public void UpdateLibraryFile()
    {
        List<string> lines = _books.Select(book => $"{book.Genre} | {book.Title} | {book.Author} | {book.ISBN} | {book.Type}").ToList();
        File.WriteAllLines(_fileName, lines);
    }

    // public void Search()
    // {

    // }

}
