public class Entry
{
    public string _entryText; // this will hold the user's journal entry
    public string _prompt = setPrompt();
    public string _date = SetDate();

    public Entry()
    {
        Console.Write(_prompt); // print the prompt
        _entryText = Console.ReadLine(); // get user text entry
        //listFiles._addEntry.Add(_entryText); // add entry to list in 'Files'
    }

    public Entry(string simple)
    {
        //skip the prompt and date because this is only used when loading a file
    }
    
    static string SetDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        return dateText;
    }

    static string setPrompt() // randomly choose a prompt for the new journal entry
    {
        string[] prompts = {"Who was the most interesting person I interacted with today? ","What was the best part of my day? ","How did I serve others today? ","How did I see the hand of the Lord in my life today? ","What was the strongest emotion I felt today? ","If I had one thing I could do over today, what would it be? ","List three things I did well today. ","I worried about ______ today and I can overcome it by _____. ","What did I learn today? ","Today I recognized _____ as a blessing in my life. "}; // list of entry choices
        Random randomGenerator = new Random(); // create a random number generator
        int number = randomGenerator.Next(0, 9); // will choose a list position to deliver a prompt
        string prompt = prompts[number];
        return prompt;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}, Prompt: {_prompt}, Entry: {_entryText}");
    }
}