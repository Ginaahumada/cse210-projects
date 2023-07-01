using System.IO;
using System.Globalization;
public class GoalManager
{
    private List<Goal> _goals;
    private int _totalPoints;

    protected List<string> _levels;
    protected List<int> _levelsPerPoints;


    public GoalManager()
    {
        _goals = new List<Goal>();

        _levels = new List<string>{
            "Beginner", "Ninja", "Profesional", "Elite", "Pro+"
        };
        _levelsPerPoints = new List<int>{
            0, 1000, 5000, 10000, 50000
        };
    }
    public void SetBonusLevels(int number)
    {
        _totalPoints += number;
    }
    public void AssignLevels()
    {
        if(_totalPoints >= _levelsPerPoints[0] & _totalPoints <= _levelsPerPoints[1])
        {
            Console.WriteLine($"Level: {_levels[0]}.");
        }
        else if(_totalPoints > _levelsPerPoints[1] & _totalPoints <= _levelsPerPoints[2])
        {
            Console.WriteLine($"Level: {_levels[1]}.");
            Console.WriteLine($"You have received 5 points. You will receive 5 additional points as long as you are at {_levels[1]} level.");
            SetBonusLevels(5);
            Console.WriteLine($"You now have {_totalPoints} points");
        }
        else if(_totalPoints > _levelsPerPoints[2] & _totalPoints <= _levelsPerPoints[3])
        {
            Console.WriteLine($"Level: {_levels[2]}.");
            Console.WriteLine($"You have received 10 points. You will receive 10 additional points as long as you are at {_levels[2]} level.");
            SetBonusLevels(10);
            Console.WriteLine($"You now have {_totalPoints} points");
        }
        else
        {
            Console.WriteLine($"Level: {_levels[3]}.");
            Console.WriteLine($"You have received 15 points. You will receive 15 additional points as long as you are at {_levels[3]} level.");
            SetBonusLevels(15);
            Console.WriteLine($"You now have {_totalPoints} points");
        }
        Console.WriteLine("");
    
    }
    public void RecordEvent(int posGoal)
    {
        if(_goals.Count > 0)
        {
            _goals[posGoal - 1].RecordEvent();
        }
        else
        {
            Console.WriteLine("You cannot record an event because you have not entered _goals. \nWe recommend that you enter at least 1.");
        }
    }
    public void ShowGoals()
    {
        int cont = 1;
        Console.WriteLine("The goals are: ");
        foreach(Goal goal in _goals)
        {
            Console.Write($"{cont}. ");
            goal.DisplayGoal();
            cont++;
        }
        Console.Write("Press Enter to continue... ");
        Console.ReadKey();
    }
    public void ShowNameGoals()
    {
        int cont = 1;
        Console.WriteLine("The goals are: ");
        foreach(Goal goal in _goals)
        {
            Console.Write($"{cont}. ");
            Console.WriteLine(goal.GetNameGoal());
            cont++;
        }
    }
    public void ShowScore()
    {
        _totalPoints = 0;
        foreach(Goal goal in _goals)
        {
            _totalPoints += goal.GetEarnedPoints();
        }
        Console.WriteLine($"You have {_totalPoints} points");
        AssignLevels();
        
    }
    public void SaveGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void SaveGoalsInFile()
    {
        Console.Write("What is the filename for the goal file? ");

        string filename = Console.ReadLine();

        if(filename != "")
        {
            List<string> goals = new List<string>();
            foreach(Goal goal in _goals)
            {
                goals.Add(GetStringRepresentation(goal));
            }
            using(StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_totalPoints);
                foreach(string goal in goals)
                {
                    outputFile.WriteLine(goal);
                }
            }
        }
        // Ya esta la parte de obtener los string
        // foreach(string goal in goals)
        // {
        //     Console.WriteLine(goal);
        // }
        
        //Queda pendiente la parte del guardado en un archivo de texto
    }
    public void LoadGoalsFromFile()
    {
        //Read the name of the file
        Console.Write("What is the filename for the goal file? ");

        string filename = Console.ReadLine();

        try
        {
            string[] lines = System.IO.File.ReadAllLines(filename);

            if(lines.Count() > 0)
            {
                _totalPoints = int.Parse(lines[0]);

                _goals = new List<Goal>();

                for(int i = 1; i < lines.Count();i++)
                {
                    string[] line = lines[i].Split(",");

                    string typeObject = line[0];

                    string nameGoal = line[1];
                    string descriptionGoal = line[2];
                    int pointPerGoal = int.Parse(line[3]);
                    int pointsEarneds = int.Parse(line[line.Count()-1]);

                    switch (typeObject)
                    {
                        case "SimpleGoal":
                            bool check = Convert.ToBoolean(line[4]);
                            //SimpleGoal simpleGoal = new SimpleGoal(nameGoal, descriptionGoal, pointPerGoal, check);
                            SimpleGoal simpleGoal = new SimpleGoal(nameGoal, descriptionGoal, pointPerGoal, check, pointsEarneds);
                            _goals.Add(simpleGoal);
                        break;
                        case "EternalGoal":
                            //EternalGoal eternalGoal = new EternalGoal(nameGoal, descriptionGoal, pointPerGoal);
                            EternalGoal eternalGoal = new EternalGoal(nameGoal, descriptionGoal, pointPerGoal, pointsEarneds);
                            _goals.Add(eternalGoal);
                        break;
                        case "CheckListGoal":
                            int bonusPoint = int.Parse(line[4]);
                            int targetCount = int.Parse(line[5]);
                            int currentCount = int.Parse(line[6]);
                            //CheckListGoal checkListGoal = new CheckListGoal(nameGoal, descriptionGoal, pointPerGoal, bonusPoint, targetCount, currentCount);
                            CheckListGoal checkListGoal = new CheckListGoal(nameGoal, descriptionGoal, pointPerGoal, bonusPoint, targetCount, currentCount, pointsEarneds);
                            _goals.Add(checkListGoal);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The entered file is empty.");
            }
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("The file does not exist");
        }

    }
    public string GetStringRepresentation(Goal objectGoal)
    {
        string typeObject = objectGoal.GetType().ToString();

        string nameGoal = objectGoal.GetNameGoal();
        string descriptionGoal = objectGoal.GetDescriptionGoal();
        int pointsPerGoal = objectGoal.GetPointsPerGoal();
        int pointsEarneds = objectGoal.GetEarnedPoints();

        string infoObject = "";

        switch(typeObject)
        {
            case "SimpleGoal":
                string check = objectGoal.GetChecked().ToString();
                // infoObject = $"{typeObject}, {nameGoal}, {descriptionGoal}, {pointsPerGoal}, {pointsEarneds}, {check}";
                infoObject = $"{typeObject},{nameGoal},{descriptionGoal},{pointsPerGoal},{check},{pointsEarneds}";
                break;
            case "EternalGoal":
                infoObject = $"{typeObject},{nameGoal},{descriptionGoal},{pointsPerGoal},{pointsEarneds}";
                break;
            case "CheckListGoal":
                string bonusPoint = objectGoal.GetBonusPoints().ToString();
                string targetCount = objectGoal.GetTargetCount().ToString();
                string currentCount = objectGoal.GetCurrentCount().ToString();
                //string completed = objectGoal.Completed().ToString();
                infoObject = $"{typeObject},{nameGoal},{descriptionGoal},{pointsPerGoal},{bonusPoint},{targetCount},{currentCount},{pointsEarneds}";
                break;
        }
        return infoObject;
    }
}