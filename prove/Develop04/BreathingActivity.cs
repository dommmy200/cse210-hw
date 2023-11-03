using System;

namespace Mindfulness {
    public class BreathingActivity : Activity {
        // BreathingActivity constructor
        public BreathingActivity(string className, string description) : base (className, description) {
            _className = className;
            _description = description;
        }
        // Method to play the breathing game
        public void PlayBreathingActivity(string clsName) {
            DisplayStartMessage(clsName);
            Console.WriteLine(Description);
            var duration = GetUserDuration();
            Console.Clear();
            GetReadyForExercise();
            BreathingExercise(duration);
            DisplayWellDoneMessage();
            DisplayEndMessage(duration, clsName);
        }
        // Local method that feeds "PlayBreathingActivity" method with the actual activity
        private void BreathingExercise(int secs) {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(secs);
            string [] strings = {
                "Breathe in...","Now breathe out..."
            };
            
            int i = 0;
            while (DateTime.Now < endTime) {
                Console.Write("Breathe in...");
                CountdownAnimation(5);
                Console.Write("Now breathe out...");
                CountdownAnimation(6);
                Console.WriteLine();

                if (i >= strings.Length)
                    i = 0;

                i++;
            }
            Console.WriteLine();
        }
    }
}