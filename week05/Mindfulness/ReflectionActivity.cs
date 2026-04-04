using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone.",
        "Think of a time you were selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful?",
        "How did you feel?",
        "What did you learn?",
        "Would you do it again?",
        "What made it special?"
    };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This helps you reflect on strength and resilience.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Reflect on this...");
        ShowSpinner(4);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("\n" + question);
            ShowSpinner(5);
        }

        EndMessage();
    }
}