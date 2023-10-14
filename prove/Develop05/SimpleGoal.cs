public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if(!IsComplete())
        {
            _isComplete = true;
            return _points;
        }
        
        return 0;
        
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }
    public override string GetStringRepresentation(string fileName)
    {
        // Implement how to represent a SimpleGoal as a string.
        return $"{_name} - {_description} - {_points} - {_isComplete}";
    }
}
