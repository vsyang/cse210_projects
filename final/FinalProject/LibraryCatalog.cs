using System;
using System.IO;

public class LibraryCatalog
{
    // private List<PhysicalBook> _physicalBook;
    // private List<ElectronicBook> _electronicBook;
    private string _fileName;

    public LibraryCatalog(string fileName)
    {
        // _physicalBook = new List<PhysicalBook>();
        // _electronicBook = new List<ElectronicBook>();
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
        // if (type == "Physical")
        // {
        //     PhysicalBook physicalBook = new PhysicalBook(genre, title, author, isbn, type);
        //     AddBook(physicalBook);
        // }
        // else if (type == "Electronic")
        // {
        //     ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
        //     AddBook(electronicBook);
        // }
        // else 
        // {
        //     Console.WriteLine("Unsupported book type");
        // }

    }

    // public void AddBook(Book book)
    // {
    //     if (book is PhysicalBook)
    //     {
    //         _physicalBook.Add((PhysicalBook)book);
    //     }
    //     else if (book is ElectronicBook)
    //     {
    //         _electronicBook.Add((ElectronicBook)book);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Unsupported book type.");
    //     }
    // }

    public void LoadBooks()
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
                    }

                    else if (type == "Electronic")
                    {
                        ElectronicBook electronicBook = new ElectronicBook(genre, title, author, isbn, type);
                    }
                }
            }
                
        }
    }
    

    public void RemoveBook()
    {

    }

    public void Search()
    {

    }

}


// manages library collection
// add new books- AddBook()
// remove damaged books -RemoveBook()
// cataloging books- Search()