public class RandomPrompt
{
    private List<string> _prompts;

    public RandomPrompt()
    {
        _prompts = new List<string>
        {
            "Who did you converse with today?",
            "What did you daydream about?",
            "What is the meal plan for today?",
            "How did you make today special?",
            "If you could travel anywhere, who would you take and why?",
            "How are you keeping up with your goals?",
            "What style did you choose today and why?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}