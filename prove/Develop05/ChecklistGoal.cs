public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int points, int bonus, int amountCompleted, int target, bool isComplete = false) : base (name, description, points)
    {
        _amountCompleted = amountCompleted;//how many times its been done
        _target = target;//target is for how many times to do it
        _bonus = bonus;//if they've completely finished
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (IsComplete())
        {
            _isComplete = true;
            return _bonus + _points;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        
        return _amountCompleted == _target; 
    }

    public override string GetDetailsString()
    {
        
        return $"{(_isComplete ? "[X]" : "[ ]")} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        // * return back up if it doesn't look right
    }

    public override string GetStringRepresentation(string fileName)
    {
        return $"{_name} - {_description} - {_points} - {_bonus} - {_amountCompleted} - {_target} - {IsComplete()}"; 
    }
}
