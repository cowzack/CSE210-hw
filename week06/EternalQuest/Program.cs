using System;

/*
CREATIVITY:
- I added leveling system for every 1000 points it will level up
- I added displays player level as well 
*/

class Program
{
    static void Main(string[] args)
    {
    GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Create Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Quit");

            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1. Simple  2. Eternal  3. Checklist");
                    string type = Console.ReadLine();

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Description: ");
                    string desc = Console.ReadLine();

                    Console.Write("Points: ");
                    int pts = int.Parse(Console.ReadLine());

                    if (type == "1")
                        manager.AddGoal(new SimpleGoal(name, desc, pts));

                    else if (type == "2")
                        manager.AddGoal(new EternalGoal(name, desc, pts));

                    else if (type == "3")
                    {
                        Console.Write("Target count: ");
                        int target = int.Parse(Console.ReadLine());

                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());

                        manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    manager.DisplayGoals();
                    Console.Write("Which goal? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;

                case "4":
                    manager.DisplayScore();
                    break;

                case "5":
                    manager.Save("goals.txt");
                    break;

                case "6":
                    manager.Load("goals.txt");
                    break;

                case "7":
                    running = false;
                    break;
            }
        }
    }
}