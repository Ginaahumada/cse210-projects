public class ReflectingActivity : Activity
{
    private string reflectingPrompt;
    private List<string> _questions;
    private List<int> _usedQuestions = new List<int>();
    public ReflectingActivity(string name, string description) : base(name, description)
    {
        List<string> prompts = new List<string> 
        { 
            "Think of a time when you stood up for someone else.", 
            "Think of a time when you did something really difficult.", 
            "Think of a time when you helped someone in need.", 
            "Think of a time when you did something truly selfless." 
        };
        _questions = new List<string> 
        { 
            "Why was this experience meaningful to you?", 
            "Have you ever done anything like this before?", 
            "How did you get started?", 
            "How did you feel when it was complete?", 
            "What made this time different than other times when you were not as successful?", 
            "What is your favorite thing about this experience?", 
            "What could you learn from this experience that applies to other situations?", 
            "What did you learn about yourself through this experience?", 
            "How can you keep this experience in mind in the future?" 
        };
        base.SetListPrompts(prompts);
    }
    private void GetReflectinPrompt()
    {
        reflectingPrompt = base.GetRandomPrompt();
    }
    public string GetRandomQuestion()
    {
        Random rand = new Random();
        int randomNumber = rand.Next(_questions.Count);
        while(_usedQuestions.Contains(randomNumber))
        {
            randomNumber = rand.Next(_questions.Count);
        }
        string question = _questions[randomNumber];
        _usedQuestions.Add(randomNumber);
        return question;
    }
    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        GetReflectinPrompt();
        Console.WriteLine($"--- {reflectingPrompt} ---\n");
        Console.WriteLine("When you have something in mind, press ENTER to Continue.");
    }
    public void RunActivity()
    {
        base.DisplayingStartingMessage();
        base.SetDuration();
        Console.Clear();
        Console.WriteLine("Get ready ...");
        base.ShowSpinner();
        DisplayPrompt();
        Console.ReadKey();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        base.CountDown();
        Console.Clear();
        base.SetStartActivity();
        while (base.VerifyTime(base.GetStartActivity())) // loop until the time set by user has elapsed
        {
            if(_usedQuestions.Count() == _questions.Count())
            {
                Console.WriteLine("All the prompts were displayed");
                break;
            }
            DisplayQuestions();
            base.ShowSpinner(10);
        }
        base.DisplayEndingMessage();
    }
    public void DisplayQuestions()
    {
        Console.Write($"\n> {GetRandomQuestion()} ");
    }
}