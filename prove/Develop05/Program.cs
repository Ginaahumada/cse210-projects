using System;

class Program
{
    static void Main(string[] args)
    {
        //Exceding Requirements
            //I decided to load the data from the file, including the points that the user has earned in a game, this allows the persistence of the data so that the user can play again.
            //I added some joy to the game, I added several levels of play that increases the bonuses according to the amount of total points. Example: Beginner (50 - 60 points) gets an incentive of 10 points, and these will increase according to the level and amount of points.

        int option = 0;
        bool bucle = true;
        GoalManager goals = new GoalManager();
        while(bucle)
        {
            Console.WriteLine("");
            goals.ShowScore();
            Console.WriteLine("\n    1.- Create New Goal.");
            Console.WriteLine("    2.- List Goals.");
            Console.WriteLine("    3.- Save Goals.");
            Console.WriteLine("    4.- Load Goals.");
            Console.WriteLine("    5.- Record Event.");
            Console.WriteLine("    6.- Quit.\n");

            Console.Write("Select a choice from the menu: ");
            try
            {
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                        int optionA = 0;
                        bool bucleA = true;
                        while(bucleA)
                        {
                            Console.WriteLine("The types of Goals are: ");
                            Console.WriteLine("   1.- Simple Goal");
                            Console.WriteLine("   2.- Eternal Goal");
                            Console.WriteLine("   3.- CheckList Goal");

                            Console.Write("Which type of goal would you like to create? ");
                            optionA = int.Parse(Console.ReadLine());

                            Console.Write("What is the name of your Goal? ");
                            string name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            string description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            int pointPerGoal = int.Parse(Console.ReadLine());

                            switch(optionA)
                            {
                                case 1:
                                    SimpleGoal simpleGoal = new SimpleGoal(name, description, pointPerGoal, false);
                                    goals.SaveGoal(simpleGoal);
                                    break;
                                case 2:
                                    EternalGoal eternalGoal = new EternalGoal(name, description, pointPerGoal);
                                    goals.SaveGoal(eternalGoal);
                                    break;
                                case 3:
                                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                                    int targetCount = int.Parse(Console.ReadLine());
                                    Console.Write("What is the bonus for acomplishing it that many times? ");
                                    int bonusPoint = int.Parse(Console.ReadLine());
                                    CheckListGoal checkListGoal = new CheckListGoal(name, description, pointPerGoal, bonusPoint, targetCount);
                                    goals.SaveGoal(checkListGoal);
                                    break;
                                default:
                                    break;
                            }
                            bucleA = false;
                        }
                        break;
                    case 2:
                        goals.ShowGoals();
                        break;
                    case 3:
                        goals.SaveGoalsInFile();
                        break;
                    case 4:
                        goals.LoadGoalsFromFile();
                        break;
                    case 5:
                        goals.ShowNameGoals();
                        Console.Write("Which goal did you accomplished? ");
                        int goalSelected = int.Parse(Console.ReadLine());
                        goals.RecordEvent(goalSelected);
                        break;
                    case 6:
                        bucle = false;
                        break;
                    default:
                        
                        break;
                }
            }
            catch (FormatException e)
            {
                
                Console.Write(e);
                Console.WriteLine("Press 'Enter'.");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}