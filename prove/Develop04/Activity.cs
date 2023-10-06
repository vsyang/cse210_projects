public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.WriteLine("How many seconds would you like your session to be? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        ShowCountDown(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        ShowSpinner(3);
        Console.WriteLine("Well done!!\n");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
       // |/-\| 
       List<string> spinnerAnimation = new List<string>();
       spinnerAnimation.Add("|");
       spinnerAnimation.Add("/");
       spinnerAnimation.Add("-");
       spinnerAnimation.Add("\\");
       spinnerAnimation.Add("|");
       spinnerAnimation.Add("/");
       spinnerAnimation.Add("-");
       spinnerAnimation.Add("\\");

       foreach (string s in spinnerAnimation)
       {
        Console.Write(s);
        Thread.Sleep(500);
        Console.Write("\b \b");
       }

    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);            
            Console.Write("\b \b");

        }
    }
}
