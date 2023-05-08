using System;

class Program
{
    static void Main(string[] args)
    {
        string[] menu = {"Write New Entry","Display Unsaved Entries","Load File","Display Loaded Entries","Save Entries","Quit Program"}; // list of entry choices
        //List<string> menu = new List<string>{"Write New Entry","Display Entries","Load File","Save Entries","Quit Program"}; // list of entry choices
        Console.WriteLine("Welcome To The Journal Program"); // print welcome message only at the start of the program
        bool runApp = true; // set main loop to run
        Files listFiles = new Files(); // create 'Files' object - do here because only one is created

        while (runApp) // begin main operation loop
        {
            Console.WriteLine("\nPlease Select One Of The Following Choices:"); // print user options to screen
            int x=1;
            foreach(string option in menu)
            {
                Console.WriteLine($"{x}. {option}");
                x++;
            }
            Console.Write("Your selection? ");
            int choice = int.Parse(Console.ReadLine()); // get user input
            switch (choice) // select  next step
            {
                case 1: // Write New Entry
                    Entry newEntry = new Entry(); // create new 'Entry' object - will choose a prompt and set the date
                    listFiles._addEntry.Add(newEntry); // add entry to list in 'Files'
                    break;
                case 2: // Display Unsaved Entries
                    listFiles.ShowEntries();
                    break;
                case 3: // Load File
                    listFiles.LoadFileNames(); // load and display available file names
                    Console.WriteLine("Please type the name of the file to load: "); // ask user to select the desired file
                    string selection = Console.ReadLine(); 
                    listFiles.LoadFile(selection);
                    break;
                case 4: // Display Previously Saved Entries
                    listFiles.ShowLoadedEntries();
                    break;
                case 5: // Save Entries
                    Console.WriteLine("Use one of the following existing files or type the name for a new file");
                    listFiles.LoadFileNames(); // load and display available file names
                    listFiles._saveFileName = Console.ReadLine(); // get user text entry
                    listFiles.WriteEntries();
                    break;
                case 6: // Quit Program
                    runApp = false;
                    break;
                default:
                    Console.WriteLine($"{choice} is not a valid entry.");
                    continue;
            }
        }
    }
}