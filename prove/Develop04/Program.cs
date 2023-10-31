using System;

namespace Mindfulness
{    
    class Program
    {
        static void Main(string[] args)
        {
            int choices = 0;
            while (choices != 4)
            {
                List<string> strings = new()
                {
                    "BreathingActivity",
                    "ReflectionActivity",
                    "ListingActivity",
                    "Quit"
                };
                Console.Clear();
                Console.WriteLine("Menu Options");
                int i = 0;
                foreach (string item in strings)
                {
                    Console.WriteLine($"{i+1}. {item}");
                    i++;
                }
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();
                choices = int.Parse(choice);
                if (choices == 1)
                {
                    BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity");
                    string className = breathingActivity.GetClassName();
                    breathingActivity.PlayBreathingActivity(className);
                } else if (choices == 2) 
                {
                    ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity");
                    string className = reflectionActivity.GetClassName();
                    reflectionActivity.ReflectionExercise(className);
                } else if (choices == 3)
                {
                    ListingActivity listingActivity = new ListingActivity("Listing Activity");
                    string className = listingActivity.GetClassName();
                    listingActivity.ListingExercise(className);
                } else if (choices == 4)
                {
                    // Quit the loop and exit the program
                    System.Environment.Exit(0);
                }
            }
        }
    }
}