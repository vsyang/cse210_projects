using System.Security.Cryptography.X509Certificates;

public class ListingActivity : BreathingActivity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration, int count, string prompts): base(name, description, duration)
    {
        _count = count;
        _prompts = prompts.Split('.').ToList();
    }

    public void Run()
    {
        for(int i = 0; i < _count; i++)
        {
            string randomPrompt = GetRandomPrompt();
            Console.WriteLine($"{i + 1}: {randomPrompt}");
        }
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomPrompt = _prompts[index];

    }

    public List<string> GetListFromUser()
    {
        List<string> userInputList = new List<string>();
    }
}