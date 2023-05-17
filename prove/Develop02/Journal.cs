using System.IO;
using Microsoft.VisualBasic.FileIO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _filename;
    public void AddingEntry(Entry a, Generator b)
    {
        a._dateAndTime = DateTime.Now;
        if (b._lines.Count() > 0)
        {
            a._entry = Console.ReadLine();
            if (a._entry.Length > 0)
            {
                if (a._entry.Contains(","))
                {
                    a._entry = $"\"{a._entry}\"";
                }
                _entries.Add(a);
                b.EliminateDuplicatedPrompts();
                Console.Write("Info: Entry added!, ");
            }
            else
            {
                Console.WriteLine("Info: The entry is empty so it was not entered.");
            }
            Console.Write("Press 'Enter'");
        }
    }
    public void DisplayingAllTheEntries()
    {
        if (_entries.Count() > 0)
        {
            Console.Clear();
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        else
        {
            Console.WriteLine("Info: No entries to display");
        }
        Console.Write("Press 'Enter'");
    }
    public void SavingToAFile()
    {
        if (_entries.Count() > 0)
        {
            Console.Clear();
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
        }
        else
        {
            Console.WriteLine("Info: No entries to save");
        }
        Console.Write("Press 'Enter'");
    }
    public void LoadingFromAFile()
    {
        Console.WriteLine("What is the filename?");
        _filename = Console.ReadLine();
        try
        {
            List<string[]> lines = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(_filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",", "\t");

                while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    lines.Add(row);
                }
            }
            foreach (string[] row in lines)
            {
                Entry entry = new Entry();
                entry._dateAndTime = DateTime.Parse(row[0]);
                entry._prompt = row[1];
                entry._entry = row[2];
                entry.Display();
            }
        }
        catch (FileNotFoundException)
        {
            Console.Write($"Info: {_filename} file name does not exist, ");
        }
        Console.Write("\nPress 'Enter'");
    }
}