using System;

namespace Mindfulness{
    public class ListingActivity : Activity{
        private string _statement3 = "This activity will help you reflect on the good things in your\nlife by having you list as many things as you can in a certain area.";
        public void SetStatement3(string statement){
            _statement3 = statement;
        }
        public string GetStatement3(){
            return _statement3;
        }
        public ListingActivity(string className) : base(className){
            _className = className;
        }
        public void ListingExercise(string clsName){
            DisplayStartMessage(clsName);
            Console.WriteLine(GetStatement3());//Work on using a GetMethod to achieve this
            var duration = Activity.GetUserDuration();
            Console.Clear();
            Activity.GetReadyForExercise();
            Console.Write($"List as many prompts you can to the following prompt:\n--- {GenerateListing()} ---\nYou may begin in: ");
            Activity.CountdownAnimation(5);
            // Use a loop to grab user entry and count the number of entry to display:
            ResponseListing(duration);
            // "You listed {count} items"
            // DisplayEndMessage
            Console.WriteLine("Well done!!");
            Activity.RotateSlashAnimation(4);
            Activity.DisplayEndMessage(duration,clsName);
        }
    
        static private string GenerateListing(){
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
        private void ResponseListing(int duration){
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            List<string> strings = new List<string>();
            
            int count = 0;
            while (DateTime.Now < endTime){
                Console.Write(">");
                string response = Console.ReadLine();
                strings.Add(response);
                count++;
            }
            Console.WriteLine($"You listed {count} items.\n");
        }
    }
}