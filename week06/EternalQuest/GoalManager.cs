using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        int points = _goals[index].RecordEvent();
        _score += points;
        Console.WriteLine($"You earned {points} points!");
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void Save(string file)
    {
        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void Load(string file)
    {
        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);

        _goals.Clear();

        foreach (string line in lines)
        {
            Console.WriteLine(line); // simplified loading
        }
    }
}