using System;

class Program
{
    static void Main(string[] args)
    {
       Reference ref1 = new Reference("John", 11, 35);
        Scripture scripture = new Scripture(ref1, "Jesus wept");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());

            if (scripture.AllHidden())
                break;

            Console.WriteLine("\nPress Enter or type 'quit':");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideWords(1); // hide 1 word at a time (better for short verse)
        }
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");
        foreach (string p in parts)
        {
            _words.Add(new Word(p));
        }
    }

    public void HideWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int index = _rand.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string Display()
    {
        string result = _reference.Display() + " - ";

        foreach (Word w in _words)
        {
            result += w.Display() + " ";
        }

        return result;
    }

    public bool AllHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string Display()
    {
        return _book + " " + _chapter + ":" + _verse;
    }
}

class Word
{
    private string _text;
    private bool _hidden = false;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string Display()
    {
        if (_hidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
