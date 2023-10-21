public class LibraryCatalog
{
    private List<PhysicalBook> _physicalBook;
    private List<ElectronicBook> _electronicBook;
    private string _fileName;

    public LibraryCatalog(string fileName)
    {
        _physicalBook = new List<PhysicalBook>();
        _electronicBook = new List<ElectronicBook>();
        _fileName = fileName;
    }

    public void AddBook(string genre, string title, string author, string isbn, string type)
    {
        string _fileName = "AllBooks.txt";
        using (StreamWriter writer = File.AppendText(_fileName))
        {
            string bookData = $"{genre} | {title} | {author} | {isbn} | {type}";
            writer.WriteLine(bookData);
        }
        if (type == "Physical")
        {
            PhysicalBook physicalBook = new PhysicalBook(genre, title, author, isbn, type);
            _physicalBook.Add(physicalBook);
        }
        else if (type == "Electronic")
        {
            ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
            _electronicBook.Add(electronicBook);
        }
        else 
        {
            Console.WriteLine("Unsupported book type");
        }

    }

    public void LoadBooks(string fileName)
    {
        if(File.Exists(_fileName))
        {
            string _fileName = "AllBooks.txt";
            string[]lines = File.ReadAllLines(_fileName);
            foreach (string line in lines)
            {
                string[] data = line.Split('|');
                if (data.Length == 5)
                {
                    string genre = data[0];
                    string title = data[1];
                    string author = data[2];
                    string isbn = data[3];
                    string type = data[4];

                    if (type == "Physical")
                    {
                        PhysicalBook physicalBook = new PhysicalBook(genre, title, author, isbn, type);
                        _physicalBook.Add(physicalBook);
                    }

                    else if (type == "Electronic")
                    {
                        ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
                        _electronicBook.Add(electronicBook);
                    }
                }
            }                
        }
    }
    

    public void RemoveBook()
    {
        Console.WriteLine();
        Console.WriteLine("Library Catalog");

        // Display the list of books
        for (int i = 0; i < _physicalBook.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_physicalBook[i].Title} by {_physicalBook[i].Author} (Physical)");
        }

        for (int i = 0; i < _electronicBook.Count; i++)
        {
            Console.WriteLine($"{i + 1 + _physicalBook.Count}. {_electronicBook[i].Title} by {_electronicBook[i].Author} (Electronic)");
        }

        Console.Write("\nWhich book needs to be removed? Enter the number: ");
        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            if (selection > 0 && selection <= _physicalBook.Count + _electronicBook.Count)
            {
                // Subtract 1 to match the index
                int index = selection - 1;
                if (index < _physicalBook.Count)
                {
                    _physicalBook.RemoveAt(index);
                }
                else
                {
                    _electronicBook.RemoveAt(index - _physicalBook.Count);
                }

                // Update the "AllBooks.txt" file to reflect the changes
                UpdateLibraryFile();

                Console.WriteLine("The selected book has been removed from the library catalog.");
            }
            else
            {
                Console.WriteLine("Invalid book selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private void UpdateLibraryFile()
    {
        List<string> lines = _physicalBook.Select(book => $"{book.Genre} | {book.Title} | {book.Author} | {book.ISBN} | Physical").ToList();
        lines.AddRange(_electronicBook.Select(book => $"{book.Genre} | {book.Title} | {book.Author} | {book.ISBN} | Electronic"));

        File.WriteAllLines("AllBooks.txt", lines.ToArray());
    }



    public void Search()
    {

    }

}
