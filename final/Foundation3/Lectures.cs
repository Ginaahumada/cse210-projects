public class Lectures : Events
{
    private string _speakerName;
    private int _limitedCapacity;
    public Lectures(string eventType, string eventTitle, string description, DateTime datetime, Address address) : base (eventType, eventTitle, description, datetime, address)
    {
        
    }
    public override void ShowFullDetails()
    {
        Console.WriteLine("\n");
        base.StandardDetails();
        base.ShortDescription();
        Console.WriteLine($"Speaker: {_speakerName}\nCapacity: {_limitedCapacity}");
        Console.WriteLine("\n");
    }
    public void SetSpeakerName(string speakerName)
    {
        _speakerName = speakerName;
    }
    public void SetCapacity(int limitedCapacity)
    {
        _limitedCapacity = limitedCapacity;
    }
}