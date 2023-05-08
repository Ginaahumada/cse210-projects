using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();
        prompts.LoadingPrompts();
        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("       *Menu*");
            Console.WriteLine("1.- Adding an entry.");
            Console.WriteLine("2.- Display all the entries.");
            Console.WriteLine("3.- Saving a file.");
            Console.WriteLine("4.- Loading from a file.");
            Console.WriteLine("5.- Exit.");
            Console.Write("\nWhat would you like to do? ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Entry a = new Entry();
                    if (prompts._lines.Count() > 0)
                    {
                        prompts.ChossingRandomPrompts();
                        a._prompt = prompts._randomPrompt;
                        a._entry = Console.ReadLine();
                        journal.AddingEntry(a, prompts);
                    }
                    else
                    {
                        Console.WriteLine("All the prompts were displayed");

                    }
                    Console.Write("Press Enter....");
                    Console.ReadKey();
                    break;
                case 2:
                    journal.DisplayingAllTheEntries();
                    Console.ReadKey();
                    break;
                case 3:
                    journal.SavingToAFile();
                    Console.ReadKey();
                    break;
                case 4:
                    journal.LoadingFromAFile();
                    Console.ReadKey();
                    break;
                case 5:
                    exit = true;
                    break;
            }
        }

    }
}