public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        //since it's eternal, it is never complete but find a way for user to still get their points
        return false;
    }

    public override string GetStringRepresentation(string fileName)
    {
        //
        return $"{_name} - {_description} - {_points}";
    }
}
