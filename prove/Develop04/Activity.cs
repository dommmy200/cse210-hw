using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Mindfulness{
    public class Activity{
        protected int _duration;
        protected string _className;

        public void SetDuration(int duration){
            _duration = duration;
        }
        public int GetDuration(){
            return _duration;
        }
        public string GetClassName(){
            return _className;
        }
        static public void GetReadyForExercise(){
            Console.WriteLine("Get ready...");
            RotateSlashAnimation(6);
        }
        static public void CountdownAnimation(int count){
            for (int i = count; i >= 0; i--){
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
        public void DrawDotsAnimation(){
            for (int i = 5; i > 5; i--){
                Console.Write(".");
                Thread.Sleep(1000);
            }
        }
        static public void RotateSlashAnimation(int secs){
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(secs);

            string [] strings = {
                "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-"
            };
            
            int i = 0;
            while (DateTime.Now < endTime){
                Console.Write(strings[i]);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                if ( i >= strings.Length)
                    i = 0;
                i++;
            }
            Console.WriteLine();
        }
        public Activity(int duration, string className){
            _duration = duration;
            _className = className;
        }
        public Activity(string className){
            _className = className;
        }
        public void DisplayStartMessage(string className){
            Console.Clear();
            Console.WriteLine($"Welcome to the {className}\n");
        }
        static public int GetUserDuration(){
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            string duration = Console.ReadLine();
            return int.Parse(duration);
        }
        static public void DisplayWellDoneMessage(){
            Console.WriteLine("Well done!!");
            Activity.RotateSlashAnimation(5);
        }

        static public void DisplayEndMessage(int duration, string className){
            Console.WriteLine($"\nYou have completed another {duration} seconds of the {className}.");
            Activity.RotateSlashAnimation(5);
        }
    }
}