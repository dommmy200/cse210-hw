using System;
using System.IO;

namespace EternalGoal {
    public class EternalGoal : Goal {
        public EternalGoal(string check, string goalName, string description, int point) : base(check, goalName,  description, point){
        }
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}] {GetGoalName()},({GetGoalDescription()})");
        }
        public override string SaveGoal() {
            string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()}";
            return goalStructure;
        }
        // public override List<Goal> LoadGoal(Goal goal, HelperClass helper) {
            
            // string gName = parts[0];
                
            // // split the goal name into its components
            // string [] nameSplit = gName.Split(":");
            // var gN = nameSplit[1].Trim(); // goal name comes bundled and needs to be unbundled and trimmed
            
            // var gDescription = parts[1];
            // int gPoint = int.Parse(parts[2]);
            // // 
            // EternalGoal eternal = new EternalGoal("", gN, gDescription, gPoint);            
            // HelperClass help = new HelperClass();
            // help.AddGoalToList(eternal);
            // List<Goal> gList = helper.GetGoalsList();
            // return gList;
        // }
        public override void RecordGoalEvent(HelperClass helper1) {
            int point = GetPoint();
            helper1.AddPoints(point);
            this.GetCheck();
        }
    }
}