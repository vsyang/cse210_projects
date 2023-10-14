public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public string Name
    {
        get {return _name; }
    }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    //This method should do whatever is necessary for each specific kind of goal, such as marking a simple goal complete and adding to the number of times a checklist goal has been completed. It should return the point value associated with recording the event (keep in mind that it may contain a bonus in some cases if a checklist goal was just finished, for example).
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    //This method should return details of goal that could be shown in a list; should include [ ]
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_name} ({_description})";
       //     *move back if it doesn't look right*
    }

    public abstract string GetStringRepresentation(string fileName);
    //this method should provide all of the details of a goal in a way that is easy to save to a file and then load later.
}
