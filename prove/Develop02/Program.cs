using System;
class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        Journal journal = new Journal();
        Generator prompts = new Generator();
        prompts.LoadingPrompts();
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("     MY JOURNAL APP\n");
            Console.WriteLine("          Menu\n");
            Console.WriteLine("1.- Adding an entry.");
            Console.WriteLine("2.- Display all the entries.");
            Console.WriteLine("3.- Loading from a file.");
            Console.WriteLine("4.- Saving a file.");
            Console.WriteLine("5.- Exit.");
            Console.Write("\nWhat would you like to do? ");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Entry entry = new Entry();
                        prompts.ChoosingRandomPrompts();
                        entry._prompt = prompts._randomPrompt;
                        journal.AddingEntry(entry, prompts);
                        Console.ReadKey();
                        break;
                    case 2:
                        journal.DisplayingAllTheEntries();
                        Console.ReadKey();
                        break;
                    case 3:
                        journal.LoadingFromAFile();
                        Console.ReadKey();
                        break;
                    case 4:
                        journal.SavingToAFile();
                        Console.ReadKey();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error!, Please enter an option in the Menu.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Write("Error! No letters are allowed to be entered in the Menu options.");
                Console.WriteLine("Press 'Enter'.");
                Console.ReadKey();
                Console.Clear();
            }

        }

    }
}