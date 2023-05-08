using System.IO;
public class Files // For handling file reads and saves
{
// create a list to hold new entries until save
    public List<Entry> _addEntry = new List<Entry>(); // create a list that new entries can be added into - created here so only one will be initialized
    public List<Entry> _loadedEntry = new List<Entry>(); // create a list that already saved entries can be added into
    public string _saveFileName;

    public void ShowEntries() // display entries that are unsaved - located here because the List it accesses is here
    {
        foreach (Entry i in _addEntry) // loop through the '_addEntry' list
        {
            i.Display(); // call the Entry 'Display' method to print each journal entry as the loop iterates
        }
    }

    public void ShowLoadedEntries() // display entries that have been loaded from a saved file
    {
        foreach (Entry i in _loadedEntry) // loop through the '_addEntry' list
        {
            i.Display(); // call the Entry 'Display' method to print each journal entry as the loop iterates
        }
    }

    public void LoadFile(string selection)
    {
        string[] loadedEntries = System.IO.File.ReadAllLines(selection); // read the file into an array
        foreach (string line in loadedEntries) // loop through array to place into current entries for display
            {
                string[] parts = line.Split(","); // split the string into component parts
                string simple = ""; // empty string is used to access the correct constructor method
                Entry loadedEntry = new Entry(simple); // create new object to hold values
                loadedEntry._date = parts[0];
                loadedEntry._prompt = parts[1];
                loadedEntry._entryText = parts[2];
                _loadedEntry.Add(loadedEntry); // add object into entries array
            }
    }
    
    public void LoadFileNames()
    {
        string[] lines = System.IO.File.ReadAllLines("filenames.txt"); // read available filenames for loading into an array
        Console.WriteLine("Available Files:");
        foreach (string line in lines)
        {
            Console.WriteLine($"{line}"); // print the name of each file that can be loaded
        }
    }

    public void WriteEntries()
    {
        bool fileExists = false;
        string fileName = _saveFileName;
        
        string[] lines = System.IO.File.ReadAllLines("filenames.txt"); // read existing filenames then check for current filename existence
        foreach (string line in lines)
        {
            if (line == _saveFileName)
            {
                fileExists = true; // current filename exists - do nothing
                break;
            }
        }

        if (!fileExists)
        {
            using (StreamWriter outputFile = new StreamWriter("filenames.txt")) // current filename doesn't exist - add to filenames.txt
            {
                foreach (string line in lines) // StreamWriter will overwrite file contents so use previously loaded contents to populate the file
                {
                    outputFile.WriteLine($"{line}");
                }
                outputFile.WriteLine($"{_saveFileName}"); // then add the newest filename
            }
        }

        string[] savedEntries = System.IO.File.ReadAllLines(_saveFileName); // read existing entries from file and prepare to rewrite them to prevent overwriting
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (string i in savedEntries) // loop through the 'savedEntries' list that is all the previously saved entries from the current file in use
            {
                outputFile.WriteLine($"{i}"); // print previous entries to the file since Streamwriter will overwrite the file contents
            }
            foreach (Entry i in _addEntry) // loop through the '_addEntry' list
            {
                outputFile.WriteLine($"{i._date}, {i._prompt}, {i._entryText}"); // print new entries to the file
            }
        }
        _addEntry.Clear(); // clear the List to prevent double-writing of entries
    }
}