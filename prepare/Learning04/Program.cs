using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("");
        
        Assignment a1 = new Assignment("Vanessa Yang", "Calculus");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Veronica Livingston", "Addition", "2", "1-12");
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Victoria Kim", "Puppies", "Why You Shouldn't Cook Your Dog");
        Console.WriteLine(a3.GetWritingInformation());
    }
}