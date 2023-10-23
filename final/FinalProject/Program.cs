using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // LibraryCatalog libraryCatalog = new LibraryCatalog("AllBooks.txt");
        // Librarian librarian = new Librarian(libraryCatalog);
        UserInterface userInterface = new UserInterface();
        // UserAccountManager userAccountManager = new UserAccountManager();
        userInterface.Start();
    }
}
