using System;

namespace Mindfulness {
    public class ReflectionActivity : Activity {
        // The class constructor
        public ReflectionActivity(string className, string description) : base (className, description) {
            _className = className;
            _description = description;
        }
        // Method to generate just one random prompts for each round of the reflection exercise
        private static string GenerateReflection() {
            List<string> prompts = new() {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless.",
                "Think of a time when you were humbled."
            };
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            return prompts[index];
        }
        // Method containing list of questions to randomly select from without repeat
        private void GenerateReflectionSequence(int timing) {
            List<string> sequence = new() {
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
            while (DateTime.Now < endTime) {
                // Randomly select a question from "sequence List"
                Random rand = new Random();
                int index = rand.Next(sequence.Count);
                var selected = sequence[index];
                // Conditional statement to verify no randomly selected question is repeated
                if (tempList != null) {
                    if (tempList.Contains(selected)) {
                        continue;
                    } else {
                        tempList.Add(selected);
                    }
                } else {
                    if (selected is not null) {
                    tempList?.Add(selected);
                    }
                }
                // Display selected question and play animation
                Console.Write($"> {selected}");
                RotateSlashAnimation(4);
                // Prevent "IndexOutOfRangeException" from throwing before the "while loop" 
                // ends by resetting counter
                if (i >= sequence.Count)
                    i = 0;
                i++;
            }
        }
        // Method to play the reflection exercise through getting the input from the user
        public void ReflectionExercise(string className) {
            DisplayStartMessage(className);
            Console.WriteLine(Description);
            var duration = GetUserDuration();
            Console.Clear();
            GetReadyForExercise();
            Console.WriteLine($"Consider the following prompt:\n\n--- {GenerateReflection()} ---\n\n");
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadKey();
            Console.Write("\n\nNow ponder on each of the following questions as they relate to this experience.\nYou may begin in: ");
            CountdownAnimation(5);
            Console.Clear();
            GenerateReflectionSequence(duration);
            Console.WriteLine();
            DisplayWellDoneMessage();
            DisplayEndMessage(duration, className);
        }
    }
}