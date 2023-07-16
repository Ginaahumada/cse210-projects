public class OutdoorGatherings : Events
{
    protected string _forecastWeather;
    public OutdoorGatherings(string eventType, string eventTitle, string description, DateTime datetime, Address address) : base (eventType, eventTitle, description, datetime, address)
    {

    }
    public override void ShowFullDetails()
    {
        Console.WriteLine("\n");
        base.StandardDetails();
        base.ShortDescription();
        Console.WriteLine($"Weather: {_forecastWeather}");
        Console.WriteLine("\n");
    }
    public void SetWeather(string weather)
    {
        _forecastWeather = weather;
    }
}