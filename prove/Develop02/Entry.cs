public class Entry
{
    public string _entry;
    public DateTime _dateAndTime;
    public string _prompt;
    public void Display()
    {
        Console.WriteLine($"Date: {_dateAndTime} - Prompt: {_prompt}\n{_entry}");
    }
}