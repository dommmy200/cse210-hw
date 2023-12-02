using System;

namespace Mindfulness {    
    class Program {
        static void Main(string[] args) {
            int choices = 0;
            while (choices != 4) {
                List<string> classNm = new() {
                    "Start breathing activity",
                    "Start reflection activity",
                    "Start listing activity",
                    "Quit"
                };
                List<string> describe = new() {
                    "The activity will help you relax by walking you through Breathing in and out slowly.\nClear your mind and focus on your breathing.",
                    "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.",
                    "This activity will help you reflect on the good things in your\nlife by having you list as many things as you can in a certain area."
                };
                Console.Clear();
                Console.WriteLine("Menu Options");
                int i = 0;
                foreach (string item in classNm) {
                    Console.WriteLine($"{i+1}. {item}");
                    i++;
                }
                Console.Write("Select a choice from the menu: ");
                // Converting null-state to not-null before dereferencing with "?"
                string choice = Console.ReadLine();
                // Checking if variable null-state is deferred
                if (choice is not null)
                    choices = int.Parse(choice);
                if (choices == 1) {
                    BreathingActivity breathingActivity = new BreathingActivity(classNm[0], describe[0]);
                    string className = Activity.FormatClassName(classNm[0]);
                    Activity.DrawDashAnimation(1);
                    breathingActivity.PlayBreathingActivity(className);
                } else if (choices == 2) {
                    ReflectionActivity reflectionActivity = new ReflectionActivity(classNm[1], describe[1]);
                    string className = Activity.FormatClassName(classNm[1]);
                    Activity.DrawDashAnimation(1);
                    reflectionActivity.ReflectionExercise(className);
                } else if (choices == 3) {
                    ListingActivity listingActivity = new ListingActivity(classNm[2], describe[2]);
                    string className = Activity.FormatClassName(classNm[2]);
                    Activity.DrawDashAnimation(1);
                    listingActivity.ListingExercise(className);
                } else if (choices == 4) {
                    // Quit the loop and exit the program
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
