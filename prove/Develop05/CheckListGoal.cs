public class CheckListGoal : Goal
{
    private int _bonusPoint;
    private int _targetCount;
    private int _currentCount;
    private bool _completed;
    public CheckListGoal(string name, string description, int points, int bonusPoint, int targetCount) : base(name, description, points)
    {
        _bonusPoint = bonusPoint;
        _targetCount = targetCount;
        _currentCount = 0;
    }
    public CheckListGoal(string name, string description, int points, int bonusPoint, int targetCount, int currentCount, int earnPoints) : base(name, description, points, earnPoints)
    {
        _bonusPoint = bonusPoint;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }
    
    public override void DisplayGoal()
    {
        if(_currentCount == _targetCount)
        {
            Console.WriteLine($"[X] {base.GetNameGoal()} ({base.GetDescriptionGoal()}) -- Completed {_currentCount}/{_targetCount} times");
        }
        else
        {
            Console.WriteLine($"[ ] {base.GetNameGoal()} ({base.GetDescriptionGoal()}) -- Completed {_currentCount}/{_targetCount} times");
        }

    }
    public override void RecordEvent()
    {
        // if(_currentCount < _targetCount)
        // {
        //     _currentCount += 1;
        //     base.SetPoints();
        //     Console.WriteLine($"Congratulations! You have earned {base.GetPointsPerGoal()}");
        //     _completed = false;
        //     if(_completed != true)
        //     {
        //         _completed = true;
        //         base.SetBonusPoints(_bonusPoint);
        //         Console.WriteLine($"Congratulations! You have earned {_bonusPoint} bonus for completing the Goal");
        //     }

        // }
        if(!_completed)
        {
            _currentCount += 1;
            base.SetPoints();
            Console.WriteLine($"Congratulations! You have earned {base.GetPointsPerGoal()}");
            if(_currentCount == _targetCount)
            {
                base.SetBonusPoints(_bonusPoint);
                Console.WriteLine($"Congratulations! You have earned {_bonusPoint} bonus for completing the Goal");
                _completed = true;
            }

        }
        // else if(_currentCount == _targetCount)
        // {
        //     if(_completed != true)
        //     {
        //         _completed = true;
        //         base.SetBonusPoints(_bonusPoint);
        //         Console.WriteLine($"Congratulations! You have earned {_bonusPoint} bonus for completing the Goal");
        //     }
        // }
    }
    public override int GetBonusPoints()
    {
        return _bonusPoint;
    }
    public override int GetTargetCount()
    {
        return _targetCount;
    }
    public override int GetCurrentCount()
    {
        return _currentCount;
    }
    
}