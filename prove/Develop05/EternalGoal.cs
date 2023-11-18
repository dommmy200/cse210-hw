using System;
using System.IO;

namespace EternalGoal {
    public class EternalGoal : Goal {
        // EternalGoal Constructor
        public EternalGoal(string check, string goalName, string description, int point) : base(check, goalName,  description, point){
        }
        // Defines the listing structure for display on screen
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}] {GetGoalName()},({GetGoalDescription()})");
        }
        // Defines the template for storage on file
        public override string SaveGoal() {
            string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()}";
            return goalStructure;
        }
        // Defines the goal recording process
        public override void RecordGoalEvent(HelperClass helper1) {
            int point = GetPoint();
            helper1.AddPoints(point);
            this.GetCheck();
        }
    }
}