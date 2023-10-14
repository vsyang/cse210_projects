using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class GoalManager
{
    private List<Goal> _goals;
    protected int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            //Console.Clear();
            Console.WriteLine();
            DisplayPlayerInfo(_score);
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalNames();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    exit = true;
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        
        Console.Write("Which type of goal would you like to create? ");
        string userCreate = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch(userCreate)
        {
            case "1": //SimpleGoal
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Simple goal created successfully.");
                Console.ResetColor();
                break;
            
            case "2": //EternalGoal
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Eternal goal created successfully.");
                Console.ResetColor();
                break;
            
            case "3": //ChecklistGoal
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                int amountCompleted = 0;
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, bonus, amountCompleted, target);
                _goals.Add(checklistGoal);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Checklist goal created successfully.");
                Console.ResetColor();
                break;
            
            default: //Invalid choice
                Console.WriteLine("Invalid choice. Which type of goal would you like to create?");
                return;            
        }

    }

    public void ListGoalNames()
    {
        Console.WriteLine();
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals. Please create some goals first.");
        }
        else
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                string completionStatus = _goals[i].IsComplete() ? "[X]" : "[ ]";
                //move this after . if it doesn't look right {completionStatus}
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

    }

    public void SaveGoals()
    {
        Console.WriteLine();
        string fileName = "AllGoals.txt";

        File.WriteAllText(fileName, string.Empty);
        using (StreamWriter outputFile = new StreamWriter(fileName, true))
        {
            outputFile.WriteLine($"Score - {_score}");
            foreach (Goal goal in _goals)
            {
                string goalType = goal.GetType().Name;
                string goalString = goal.GetStringRepresentation(fileName); // Pass the file name
                outputFile.WriteLine($"{goalType} - {goalString}");            
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Goals saved successfully.");
        Console.ResetColor();
    }

    public void LoadGoals()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Your goals have been loaded successfully.");
        Console.ResetColor();
        string fileName = "AllGoals.txt";
        using (StreamReader inputFile = new StreamReader(fileName))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] goalData = line.Split('-');

                if (goalData.Length < 2)
                {
                    continue;
                }

                string goalType = goalData[0].Trim();
                if (goalType == "Score")
                {
                    _score = int.Parse(goalData[1].Trim());
                    continue;
                }

                {
                    string name = goalData[1].Trim();
                    string description = goalData[2].Trim();
                    int points = int.Parse(goalData[3].Trim());


                    Goal newGoal = null;

                    if (goalType == "SimpleGoal")
                    {                    
                        bool isComplete = bool.Parse(goalData[4].Trim());
                        newGoal = new SimpleGoal(name, description, points, isComplete);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        newGoal = new EternalGoal(name, description, points);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int bonus = int.Parse(goalData[4].Trim());
                        int amountCompleted = int.Parse(goalData[5].Trim());
                        int target = int.Parse(goalData[6].Trim());
                        bool isComplete =bool.Parse(goalData[7].Trim());
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, bonus, amountCompleted, target, isComplete);
                        _goals.Add(checklistGoal);

                    }

                    if (newGoal != null)
                    {
                        _goals.Add(newGoal);
                    }
                }
            }            
        }
    }

public void RecordEvent()
{
    Console.WriteLine();

    if (_goals.Count == 0)
    {
        Console.WriteLine("You have no goals. Please create some goals first.");
    }
    else
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("\nWhich goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];
            int pointsEarned = selectedGoal.RecordEvent();

            if (pointsEarned > 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.ResetColor();
                _score += pointsEarned;
                selectedGoal.IsComplete();
            }
            else
            {
                Console.WriteLine("No points earned for this goal.");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
        }
    }
}


    public void DisplayPlayerInfo(int _score)
    {
        Console.WriteLine($"You have {_score} points.");
               //*make sure the total points shows on the DisplayPlayerInfo
    }


}
