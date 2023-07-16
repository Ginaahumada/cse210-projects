public class Receptions : Events
{
    private int _rsvp;
    public Receptions(string eventType, string eventTitle, string description, DateTime datetime, Address address) : base (eventType, eventTitle, description, datetime, address)
    {
        _rsvp = 0;
    }
    public void SetRsvp(int quantity)
    {
        _rsvp = quantity;
    }
    public override void ShowFullDetails()
    {
        Console.WriteLine("\n");
        base.StandardDetails();
        base.ShortDescription();
        Console.WriteLine($"RSVP: {_rsvp}");
        Console.WriteLine("\n");
    }

}