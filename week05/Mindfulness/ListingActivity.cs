using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who do you appreciate?",
        "What are your strengths?",
        "Who have you helped?",
        "Who are your heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "List as many positive things as you can.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);

        Console.WriteLine("\nGet ready...");
        ShowCountdown(5);

        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        EndMessage();
    }
}