using System;
using Microsoft.VisualBasic;

namespace Mindfulness{
    public class BreathingActivity : Activity{
        // private string _ownName;
        private string _statement1 = "The activity will help you relax by walking you through Breathing in and out slowly.\nClear your mind and focus on your breathing.";


        public void SetStatement1(string statement){
            _statement1 = statement;
        }
        public string GetStatement1(){
            return _statement1;
        }
        public BreathingActivity(string className) : base (className){
            _className = className;
        }
        public BreathingActivity(string statement, string className) : base (className){
            _statement1 = statement;
        }
        public void PlayBreathingActivity(string clsName){
            DisplayStartMessage(clsName);
            Console.WriteLine(GetStatement1());
            var duration = Activity.GetUserDuration();
            Console.Clear();
            Activity.GetReadyForExercise();
            BreathingActivity.BreathingExercise(duration);
            Activity.DisplayWellDoneMessage();
            Activity.DisplayEndMessage(duration, clsName);
        }
        static private void BreathingExercise(int secs){
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(secs);
            string [] strings = {"Breathe in...","Now breathe out..."};
            
            int i = 0;
            while (DateTime.Now < endTime){
                Console.Write("Breathe in...");
                Activity.CountdownAnimation(4);
                Console.Write("Now breathe out...");
                Activity.CountdownAnimation(6);
                Console.WriteLine();

                if ( i >= strings.Length)
                    i = 0;

                i++;
            }
            Console.WriteLine();
        }
    }
}