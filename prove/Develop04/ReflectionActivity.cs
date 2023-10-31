using System;

namespace Mindfulness{
    public class ReflectionActivity : Activity{
        private string _statement2 = "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
        public void SetStatement2(string statement){
            _statement2 = statement;
        }
        public string GetStatement2(){
            return _statement2;
        }
        public ReflectionActivity(string className) : base(className){
            _className = className;
        }
        static private string GenerateReflection(){
            List<string> prompts = new(){
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless.",
                "Think of a time when you were humbled."
            };
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            // Run a script to prevent reselection of previously selected prompts.
            return prompts[index];
        }
        static private void GenerateReflectionSequence(int timing){
            List<string> sequence = new(){
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(timing);
            List<string> tempList = new List<string>();
            int i = 0;
            while (DateTime.Now < endTime){
                // Randomly select a question from "sequence List"
                Random rand = new Random();
                int index = rand.Next(sequence.Count);
                var selected = sequence[index];
                // Conditional statement to verify no randomly selected question is repeated
                if (tempList != null){
                    if (tempList.Contains(selected)){
                        continue;
                    } else {
                        tempList.Add(selected);
                    }
                } else {
                    tempList.Add(selected);
                }
                // Display selected question and play animation
                Console.Write($"> {selected}");
                Activity.RotateSlashAnimation(4);
                // Prevent "OutOfBound" error before the "while loop" ends
                if (i >= sequence.Count)
                    i = 0;
                i++;
            }
        }
        public void ReflectionExercise(string className){
            DisplayStartMessage(className);
            Console.WriteLine(GetStatement2());
            var duration = Activity.GetUserDuration();
            Console.Clear();
            Activity.GetReadyForExercise();
            Console.WriteLine($"Consider the following prompt:\n\n--- {GenerateReflection()} ---\n\n");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadKey();
            Console.Write("\n\nNow ponder on each of the following questions as they relate to this experience.\nYou may begin in: ");
            Activity.CountdownAnimation(5);
            Console.Clear();
            GenerateReflectionSequence(duration);
            Console.WriteLine();
            Activity.DisplayWellDoneMessage();
            Activity.DisplayEndMessage(duration, className);
        }
    }
}