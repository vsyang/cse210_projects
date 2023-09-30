using System.ComponentModel;

public class ReflectingActivity :ListingActivity
{
    private List<string> _questions;

    public ReflectingActivity(string name, string description, int duration, string prompts, string questions): base( prompts)
    {
        _questions = questions.Split('.').ToList();
    } 

    public void Run()
    {

    }

    public string GetRandomPrompt()
    {

    }

    public string GetRandomQuestion()
    {

    }

    public void DisplayPrompt()
    {

    }

    public void DisplayQuestions()
    {

    }
}