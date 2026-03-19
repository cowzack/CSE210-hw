using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    class Entry
    {
        public DateTime Date;
        public string Prompt;
        public string Text;

        public Entry(string prompt, string text)
        {
            Date = DateTime.Now;
            Prompt = prompt;
            Text = text;
        }

        public void Display()
        {
            Console.WriteLine("Date: " + Date.ToString("yyyy-MM-dd"));
            Console.WriteLine("Prompt: " + Prompt);
            Console.WriteLine("Entry: " + Text);
            Console.WriteLine("-------------------------");
        }

        public string Serialize()
        {
            return $"{Date:yyyy-MM-dd HH:mm:ss}|{Prompt}|{Text}";
        }

        public static Entry Deserialize(string line)
        {
            var parts = line.Split('|');
            if (parts.Length != 3) return null;

            var entry = new Entry(parts[1], parts[2]);
            entry.Date = DateTime.Parse(parts[0]);
            return entry;
        }
    }

    static List<Entry> entries = new List<Entry>();
    static List<string> prompts = new List<string>
    {
        "What made you happy today?",
        "Describe a challenge you overcame recently.",
        "Write about someone who inspires you.",
        "What are you grateful for?",
        "Reflect on a recent mistake and lesson learned."
    };
    static Random rand = new Random();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    SaveJournal(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    LoadJournal(Console.ReadLine());
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.\n");
                    break;
            }
        }
    }

    static void AddEntry()
    {
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your entry: ");
        string text = Console.ReadLine();

        entries.Add(new Entry(prompt, text));
        Console.WriteLine("Entry added!\n");
    }

    static void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }

        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    static void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.Serialize());
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    static void LoadJournal(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            Entry entry = Entry.Deserialize(line);
            if (entry != null) entries.Add(entry);
        }
        Console.WriteLine($"Journal loaded from {filename}\n");
    }
}