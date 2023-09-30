//_reference : Reference
//_words : List<Word>

//Scripture(Reference: Reference, text: string)
// HideRandomWords(numberToHide : int) : void
//GetDisplayText() : string
//IsCompletelyHidden() : bool

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    //placing wordcount in scripture, because the scripture class is coordinating actions on whole string/scripture
    public int WordCount
    {
        get{return _words.Count(word => !word.IsHidden());}
    }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string [] words = text.Split(' ');
        
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i< numberToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            while(_words[randomIndex].IsHidden())
            {
                randomIndex = random.Next(_words.Count);
            }
            _words[randomIndex].Hide();
        }
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + Environment.NewLine;

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                string underscore = new string('_', word.OriginalLength);
                displayText += underscore + " ";
            }
            else
            {
                displayText += word.GetDisplayText() + " ";
            }
        }

        return displayText;
    }

    public void HideAllWords(int count)
    {
        for(int i = 0; i < count; i++)
        {
            if(i < _words.Count)
            {
                _words[i].Hide();
            }
        }
    }

    public void HideAllWords()
    {
        foreach (Word word in _words)
        {
            word.Hide();
        }
    }

}

