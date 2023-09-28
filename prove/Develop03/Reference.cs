//_book : string
//_chapter : int
//_verse : int
//_endVerse : int

//Possible getters and setters
//Reference(book: string, chapter:int, verse:int)
//Reference(book: string, chapter:int, startVerse:int, endVerse:int)
//GetDisplayText() : string

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if(_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_verse}  {_endVerse}";
        }
        else 
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}