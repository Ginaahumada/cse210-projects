public abstract class Goal
{
    // Esta clase esta encargada de guardar la informacion de cada meta
    //
    protected string _nameGoal;
    protected string _descriptionGoal;
    protected int _pointsPerGoal;
    protected int _pointsEarneds;

    public Goal(string name, string description, int points)
    {
        _nameGoal = name;
        _descriptionGoal = description;
        _pointsPerGoal = points;
    }
    public Goal(string name, string description, int points, int pointsEarneds)
    {
        _nameGoal = name;
        _descriptionGoal = description;
        _pointsPerGoal = points;
        _pointsEarneds = pointsEarneds;
    }
    
    // protected virtual void DisplayGoal()
    // {
    //     Console.WriteLine($"{_nameGoal} {_descriptionGoal}");
    // }
    public string GetNameGoal()
    {
        return _nameGoal;
    }
    public string GetDescriptionGoal()
    {
        return _descriptionGoal;
    }
    protected void SetPoints()
    {
        _pointsEarneds += _pointsPerGoal;
    }
    protected void SetBonusPoints(int points)
    {
        _pointsEarneds += points;
    }
    public int GetEarnedPoints()
    {
        return _pointsEarneds;
    }
    public int GetPointsPerGoal()
    {
        return _pointsPerGoal;
    }
    public abstract void DisplayGoal();
    public abstract void RecordEvent();
    protected virtual void IsComplete()
    {

    }
    public virtual bool GetChecked()
    {
        return true;
    }
    public virtual int GetBonusPoints()
    {
        return 1;
    }
    public virtual int GetTargetCount()
    {
        return 1;
    }
    public virtual int GetCurrentCount()
    {
        return 1;
    }
    public virtual bool Completed()
    {
        return true;
    }

}