using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class Activity
{
    private string _nameActivity;
    private string _descriptionActivity;
    private int _durationActivity;
    private DateTime _startingActivity;
    private List<string> _prompts;
    

    public Activity(string name, string description)
    {
        _nameActivity = name;
        _descriptionActivity = description;
    }

    protected void SetListPrompts(List<string> prompts)
    {
        _prompts = prompts;
    }
    protected string GetRandomPrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        return prompt;
    }

    protected void DisplayingStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_nameActivity}\n\n{_descriptionActivity}\n");
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!!");
        ShowSpinner();
        Console.WriteLine($"\nYou have completed another {_durationActivity} seconds of the {_nameActivity}");
        ShowSpinner();
    }
    public void CountDown()
    {
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
    }
    public void CountDown(int start)
    {
        Console.Write("Timer: ");
        for (int i = start; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i < 10)
            {
                Console.Write("\b \b");
            }
            else
            {
                Console.Write("\b\b  \b\b");
            }

        }
    }

    protected void SetStartActivity()
    {
        _startingActivity = DateTime.Now;
    }
    protected DateTime GetStartActivity()
    {
        return _startingActivity;
    }
    protected void ShowSpinner()
    {
        int bucle = 0;
        List<string> caracthers = new List<string>()
        {
            "|","/","-","\\"
        };
        for(int i = 0; bucle < caracthers.Count() * 3; i++)
        {
            if(i == caracthers.Count())
            {
                i = 0;
            }
            Console.Write(caracthers[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            bucle++;
            
        }
        Console.WriteLine("");
    }
    protected void ShowSpinner(int t)
    {
        int bucle = 0;
        List<string> caracthers = new List<string>()
        {
            "|","/","-","\\"
        };
        for(int i = 0; bucle < caracthers.Count() * t; i++)
        {
            if(i == caracthers.Count())
            {
                i = 0;
            }
            Console.Write(caracthers[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            bucle++;
            
        }
        Console.WriteLine("");
    }
    protected void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session?  ");
        int seconds = int.Parse(Console.ReadLine());
        _durationActivity = seconds;
    }
    protected int GetDuration()
    {
        return _durationActivity;
    }
    protected bool VerifyTime(DateTime start)
    {
        // now = 06:44:02
        DateTime now = DateTime.Now;
        // start = 06:44:00
        DateTime endTime = start.AddSeconds(_durationActivity);
        //endtime = 06:44:30
        if(now > endTime)
        {
            return false;
        }
        return true;
    }
    
}