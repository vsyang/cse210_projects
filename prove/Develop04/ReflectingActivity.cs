public class ReflectingActivity : Activity
{
    private string[] _prompts = 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private string _randomReflectPrompt;
    
    private string[] _questions = 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private string _randomQuestions;
    private List<int> _askedQuestions = new List<int>();

    public ReflectingActivity(string name, string description, int duration): base(name, description, duration)
    {

    } 

    public string RandomReflectPrompt
    {
        get { return _randomReflectPrompt; }
    }
    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");  
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);

        DateTime startTimer = DateTime.Now;
        DateTime endTimer = startTimer.AddSeconds(_duration);

        while (DateTime.Now < endTimer)
        {
            if (DateTime.Now >= endTimer)
            {
                Console.WriteLine("Well done!");
                break;
            }

            GetRandomQuestion();
            DisplayQuestions();
       
        }

        DisplayEndingMessage();

    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        _randomReflectPrompt = _prompts[index];

        return _randomReflectPrompt;
    }

    public string GetRandomQuestion()
    {
        //make sure question gets asked once
        Random random = new Random();
        int index;

        do
        {
            index = random.Next(_questions.Length);

        }
        while (_askedQuestions.Contains(index));

        _askedQuestions.Add(index);
        _randomQuestions = _questions[index];

        return _randomQuestions;

    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"\nConsider the following prompt:\n\n  --- {_randomReflectPrompt} ---"); 
        Console.WriteLine();
        //Console.WriteLine("When you have something in mind, press enter to continue.");    


    }

    public void DisplayQuestions()
    {
        //Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        //Console.Write("\nYou may begin in: ");
        //ShowCountDown(5);
        Console.Write($"\n> {_randomQuestions}");
        ShowSpinner(9);

    }
}