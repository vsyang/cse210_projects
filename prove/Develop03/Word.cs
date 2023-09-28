//_text : string
//_isHidden : bool

//Hide() : void
//Show() : void
//IsHidden() : bool
//GetDisplayText() : string

public class Word
{
    private string _text;
    private bool _isHidden;
    public int OriginalLength{get; private set; }

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        OriginalLength = text.Length;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if(_isHidden)
        {
            return "_";
        }
        else
        {
            return _text;
        }

    }
}

