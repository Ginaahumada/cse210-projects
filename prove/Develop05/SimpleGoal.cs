public class SimpleGoal : Goal
{
    private bool _checked;
    public SimpleGoal(string name, string description, int points, bool check) : base(name, description, points)
    {
        _checked = check;
    }
    public SimpleGoal(string name, string description, int points, bool check, int earnPoints) : base(name, description, points, earnPoints)
    {
        _checked = check;
    }
    public override bool GetChecked()
    {
        return _checked;
    }
    protected override void IsComplete()
    {
        _checked = true;
    }
    public override void DisplayGoal()
    {
        if(_checked == true)
        {
            Console.WriteLine($"[X] {base.GetNameGoal()} ({base.GetDescriptionGoal()})");
        }
        else
        {
            Console.WriteLine($"[ ] {base.GetNameGoal()} ({base.GetDescriptionGoal()})");
        }

    }
    public override void RecordEvent()
    {
        if(_checked != true)
        {
            base.SetPoints();
            Console.WriteLine($"Congratulations! You have earned {base.GetPointsPerGoal()}");
            IsComplete();
        }
        else
        {
            Console.WriteLine("Goal Already Completed!");
        }
    }
}