using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        //building an activity for each type.
        Running runningActivity = new Running(3.4, "06/11/23", 56);
        Bicyle bicycleActivity = new Bicyle(4.63,"06/11/23",33);
        Swimming swimmingActivity = new Swimming(10,"07/11/23",23);

        //Adding to the list
        activities.Add(runningActivity);
        activities.Add(bicycleActivity);
        activities.Add(swimmingActivity);

        //writing out to console by calling Activity GetSummary method
        Console.Clear();
        Console.WriteLine();
        foreach (Activity a in activities){
            Console.WriteLine(a.GetSummary());
        }
        Console.WriteLine();
    }
}