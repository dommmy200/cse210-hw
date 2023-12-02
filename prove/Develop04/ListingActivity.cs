using System;

namespace Mindfulness {
    public class ListingActivity : Activity {
        // Constructor for the class object instantiation
        public ListingActivity(string className, string description) : base (className, description) {
            _className = className;
            _description = description;
        }
        // Get user duration and call private methods for generating and exercising
        public void ListingExercise(string clsName) {
            DisplayStartMessage(clsName);
            Console.WriteLine(Description);
            var duration = GetUserDuration();
            Console.Clear();
            GetReadyForExercise();
            Console.Write($"List as many prompts you can to the following prompt:\n\n--- {GenerateListing()} ---\n\nYou may begin in: ");
            CountdownAnimation(5);
            ResponseListing(duration);
            Console.WriteLine("Well done!!");
            RotateSlashAnimation(4);
            DisplayEndMessage(duration,clsName);
        }
        // Method for random generation of prompt questions
        private static string GenerateListing() {
            List<string> prompts = new(){
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            // Run a script to prevent reselection of previously selected prompts(Stretch Exercise).
            return prompts[index];
        }
        // Method to get user duration and play the exercise in a "while-loop"
        private static void ResponseListing(int duration){
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);
            List<string> strings = new List<string>();
            int count = 0;
            while (DateTime.Now < endTime) {
                Console.Write(">");
                // Address "Possible null" assignment with "?".
                string response = Console.ReadLine();
                if (response is not null) {
                    strings.Add(response);
                }
                count++;
            }
            Console.WriteLine($"You listed {count} items.\n");
        }
    }
}