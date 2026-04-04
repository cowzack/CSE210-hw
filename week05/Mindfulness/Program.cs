using System;

class Program
{ 
    static int totalActivities = 0; 
    
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
                totalActivities++;
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
                totalActivities++;
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
                totalActivities++;
            }
            else if (choice == "4")
            {
                Console.WriteLine($"\nYou completed {totalActivities} activities total. Goodbye!");
                break;
            }
        }
    }
}