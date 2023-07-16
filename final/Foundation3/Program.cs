using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("______________________________________________________________________________________");
        string eventType = "Lectures";
        string eventTitle = "Puma Party";
        string description = "Party with friends";
        DateTime datetime = DateTime.Parse("11/02/2023");
        string speakerName = "Gina Ahumada";
        int capacity = 60;
        Address address = new Address("Jaime Roldos y 35 ava", "Quevedo", "Los Rios", "Ecuador");
        Lectures eventLectures = new Lectures(eventType, eventTitle, description, datetime, address);
        eventLectures.SetSpeakerName(speakerName);
        eventLectures.SetCapacity(capacity);
        eventLectures.StandardDetails();
        eventLectures.ShowFullDetails();
        eventLectures.ShortDescription();
        Console.WriteLine("______________________________________________________________________________________");
        eventType = "Receptions";
        eventTitle = "Wedding";
        description = "Bryan & Mishell Wedding's";
        datetime = DateTime.Parse("19/01/2024");
        int rsvp = 100;
        address = new Address("St 35, 5N", "Salt Lake", "Utah", "USA");
        Receptions reception = new Receptions(eventType, eventTitle, description, datetime, address);
        reception.SetRsvp(rsvp);
        reception.StandardDetails();
        reception.ShowFullDetails();
        reception.ShortDescription();
        Console.WriteLine("______________________________________________________________________________________");
        eventType = "Outdoor Gathering";
        eventTitle = "Party Outside";
        description = "Emerson's Party";
        datetime = DateTime.Parse("20/02/2024");
        string weather = "86°";
        address = new Address("George st, 2T", "Oregon", "New York", "USA");
        OutdoorGatherings outdoorEvent = new OutdoorGatherings(eventType, eventTitle, description, datetime, address);
        outdoorEvent.SetWeather(weather);
        outdoorEvent.StandardDetails();
        outdoorEvent.ShowFullDetails();
        outdoorEvent.ShortDescription();
        Console.WriteLine("______________________________________________________________________________________");
    }
}