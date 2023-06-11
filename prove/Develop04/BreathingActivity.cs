public class BreathingActivity : Activity
{
    private List<string>_messages;
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _messages = new List<string>
        {
            "Breath In...",
            "Now Breath Out..."
        };
    }
    public void RunActivity()
    {
        base.DisplayingStartingMessage();
        base.SetDuration();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        base.ShowSpinner();
        base.SetStartActivity();
        while (base.VerifyTime(base.GetStartActivity())) // loop until the time set by user has elapsed
        {
            BreathIn();
            Console.WriteLine("");
            BreathOut();
            Console.WriteLine("\n");
        }
        base.DisplayEndingMessage();

    }
    private void BreathIn()
    {
        Console.Write($"{_messages[0]} ");
        for (int i = 5; i > 0; i--) // loop to print a countdown to the terminal - 5 seconds
        {
            // 12 + 1 + 1   Breath In... 1
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); 
        }
    }
    private void BreathOut()
    {
        Console.Write($"{_messages[1]} ");
        for (int i = 6; i > 0; i--) 
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); 
        }
    }
}