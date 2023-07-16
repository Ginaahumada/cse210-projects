public abstract class Events
{
    private string _eventType;
    private string _eventTitle;
    private string _description;
    private DateTime _dateTime;
    private Address _address;
    public Events(string eventType, string eventTitle, string description, DateTime datetime, Address address)
    {
        _eventType = eventType;
        _eventTitle = eventTitle;
        _description = description;
        _dateTime = datetime;
        _address = address;
    }
    public void StandardDetails()
    {
        Console.WriteLine($"Title: {_eventTitle}\nDescription: {_description}\nDate: {_dateTime.ToShortDateString()}\nTime : {_dateTime.ToShortTimeString()}\nAddress: {_address.GetAddress()}");
    }
    public abstract void ShowFullDetails();
    public void ShortDescription()
    {
        Console.WriteLine($"Event Type: {_eventType}\nEvent Title: {_eventTitle}\nDate: {_dateTime.ToShortDateString()}");
    }
    public void GetEventType()
    {
        Console.WriteLine(_eventType);
    }

}