public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetName()}";
    }

    public override string GetDetailsString()
    {
        return $"[∞] {base.GetDetailsString()}";
    }
}