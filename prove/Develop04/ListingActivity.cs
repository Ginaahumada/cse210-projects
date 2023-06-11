using System;
using System.Collections.Generic;
using System.Diagnostics;
public class ListingActivity : Activity
{
    private string listingPrompt;
    private List<string> _usedPrompts = new List<string>();
    private List<string> _userList = new List<string>();

    private Stopwatch sw = new Stopwatch();
    private double lastFrame;
    public ListingActivity(string name, string description) : base(name, description)
    {
        List<string> prompt = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        SetListPrompts(prompt);
    }
    private void GetListingPrompt()
    {
        listingPrompt = base.GetRandomPrompt();
    }
    public void DisplayPrompt()
    {
        Console.WriteLine("List as many responses you can to the following prompt: \n");
        GetListingPrompt();
        Console.WriteLine($"--- {listingPrompt} ---\n");

    }
    public void RunActivity()
    {
        base.DisplayingStartingMessage();
        base.SetDuration();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        base.ShowSpinner();
        DisplayPrompt();
        base.CountDown();
        base.SetStartActivity();
        GetEntries(base.GetDuration());
        base.DisplayEndingMessage();
    }
    
    private double deltaTime()
    {
        TimeSpan ts = this.sw.Elapsed;
        double firstFrame = ts.TotalMilliseconds;
        double dt = firstFrame - lastFrame;
        this.lastFrame = ts.TotalMilliseconds;
        return dt;
    }
    public void GetEntries(int duration)
    {
        this.sw.Start();
        double acc = 0.0;
        List<string> buf = new List<string>();
        Console.WriteLine("");
        duration = duration * 1000;
        Console.Write("> ");
        while (acc <= duration)
        {
            acc += this.deltaTime();
            if (!Console.KeyAvailable)
            {
                continue;
            }
            ConsoleKeyInfo key = Console.ReadKey();
            
            if (key.Key == ConsoleKey.Enter)
            {
                
                Console.Write("\n> ");
                Console.Write("");
                _userList.Add("\n");
            }
            else
            {
                _userList.Add(key.KeyChar.ToString());
            }
        }
        this.sw.Reset();
        string userListStr = String.Join<string>("", _userList);
        string[] newUserList = userListStr.Split("\n");
        // If the user does not insert any characters, there is no sense in saving an empty string, so it should print 0 elements.
        // In case he only presses one character, e.g. an "A", it should be saved as 1 element.
        if(newUserList.Count() == 1)
        {
            if(newUserList[0] == "")
            {
                Console.WriteLine($"\nYou listed {0} items.");
            }
            else
            {
                Console.WriteLine($"\nYou listed {newUserList.Count()} items.");
            }
        }
        else
        {
            Console.WriteLine($"\nYou listed {newUserList.Count()} items.");
        }
    }

}