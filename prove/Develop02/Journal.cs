using System.IO;
public class Journal
{
    // public List<Job> _jobs = new List<Job>();
    public List<Entry> _entries = new List<Entry>();
    public DateTime _dateAndTime = new DateTime();
    public string _filename;

    
    public void AddingEntry(Entry a, PromptGenerator b)
    {
        a._dateAndTime = DateTime.Now;
        if (a._entry.Contains(","))
        {
            string lineWithComas = $"'{a._entry}'";
            a._entry = lineWithComas;
        }
        
        _entries.Add(a);
        Console.WriteLine("Entry added!");
    }
    public void DisplayingAllTheEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.Write("Press Enter....");
    }
    public void SavingToAFile()
    {
        Console.WriteLine("What is the filename?");
        _filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            Console.WriteLine($"\nSaving entries in the file.....\n");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._dateAndTime},{entry._prompt},{entry._entry}");
            }
        }
        Console.Write("Press Enter....");
    }
    public void LoadingFromAFile()
    {
        //the Journal display method could iterate through all Entry objects and call the Entry display method.
        Console.WriteLine("What is the filename?");
        _filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(_filename);
        Console.WriteLine($"\nReading the file....\n");
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            Entry entry = new Entry();
            entry._dateAndTime = DateTime.Parse(parts[0]);
            entry._prompt = parts[1];
            entry._entry = parts[2];

            Console.WriteLine($"Date: {entry._dateAndTime} - Prompt: {entry._prompt}\n{entry._entry}");

        }
        Console.Write("Press Enter....");
    }
}