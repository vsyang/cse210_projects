public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration):base(name, description, duration)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTimer = DateTime.Now;
        //when starting from today

        DateTime endTimer = startTimer.AddSeconds(_duration);

        //random generator for random seconds per breathe-in and breathe-out
        Random random = new Random();

        //for (int i = 0; i < _duration; i ++)
        while (DateTime.Now < endTimer)
        {
            //create a new variable datetime
            //create conditions to match up with user duration
            int breatheIn = 0, breatheOut = 0;
            if (_duration > 5)
            {
                breatheIn = random.Next(4, 6);
                breatheOut = random.Next(4, 6);

                Console.Write("\nBreathe in...");
                ShowCountDown(breatheIn);

                Console.Write("\nBreathe out...");
                ShowCountDown(breatheOut);
            }
            
            else
            {
                Console.Write("\nBreathe in...");
                ShowCountDown(3);
                Console.Write("\nBreathe out...");
                ShowCountDown(2);
            }

            _duration -= (breatheIn + breatheOut);
            
        }
        
        DisplayEndingMessage();

    }

}
