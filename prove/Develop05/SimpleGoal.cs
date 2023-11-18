using System;
using System.IO;

namespace EternalGoal {
    public class SimpleGoal : Goal {
        private bool _status;
        // SimpleGoal Constructor
        public SimpleGoal(string check, string goalName, string description, int point) : base(check, goalName,  description, point){
        }
        public void SetStatus() {
            _status = true;
        }
        public bool GetStatus() {
            return _status;
        }
        // Defines the listing structure for display on screen
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}]{GetGoalName()},({GetGoalDescription()})");
        }
        // Defines the template for storage on file 
        public override string SaveGoal() {
            string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()}, {GetStatus()} ";
            return goalStructure;
        }
        // Defines the goal recording process and display animation if set goal is achieved
        public override void RecordGoalEvent(HelperClass helper1) {
            bool boo = GetStatus();
            if (boo == false) {
                int point = GetPoint();
                helper1.AddPoints(point);
                SetStatus();
                UpdateCheck();
            }
        } 
    }
}
