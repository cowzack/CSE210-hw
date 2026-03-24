using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("|");
        return new Entry
        {
            _date = parts[0],
            _prompt = parts[1],
            _response = parts[2]
        };
    }
}