public class ListingActivity : Activity
{
    private int _count;
    private string[] _prompts = 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private string _randomPrompt;

    public ListingActivity(string name, string description, int duration, int count): base(name, description, duration)
    {
        _count = count;
    }

    public string RandomPrompt
    {
        get { return _randomPrompt; }
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTimer = DateTime.Now;
        DateTime endTimer = startTimer.AddSeconds(_duration);

        List<string> userInputList = new List<string>();
        int itemsListed = 0;

        //for(int i = 0; i < _count; i++)
        while (DateTime.Now < endTimer)
        {
            GetRandomPrompt();
            Console.WriteLine($"List as many responses you can to the following prompt:\n\n ---{_randomPrompt}---");
            Console.Write("\nYou may begin in: ");
            ShowCountDown(5);
            Console.WriteLine();


            DateTime currentTime = DateTime.Now;

            while (true)
            {
                Console.Write(">");
                string userInput = Console.ReadLine();
            

            userInputList.Add(userInput);
            itemsListed++;
            
                if (DateTime.Now >= endTimer)
                {
                    Console.WriteLine("Well done!!");
                    break;
                }
            }   
        }


        Console.WriteLine($"You Listed {itemsListed} items");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        _randomPrompt = _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> userInputList = new List<string>();
        while (true)
        {
            Console.Write("\n>");
            string userInput= Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                break;
            }
            
            userInputList.Add(userInput);            
        }

        return userInputList;
    }   
}