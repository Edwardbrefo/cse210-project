public class ChecklistGoal : Goal
{
    private int _count = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _count++;
        int total = GetPoints();

        if (_count == _target)
        {
            total += _bonus;
        }

        return total;
    }

    public override string GetDisplayText()
    {
        string status = _count >= _target ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) -- Completed {_count}/{_target}";
    }
}
