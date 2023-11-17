using System;
using System.IO;

namespace EternalGoal {
    public class SimpleGoal : Goal {
        private bool _status;
        // private int _totalPoints;
        public SimpleGoal(string check, string goalName, string description, int point) : base(check, goalName,  description, point){
            _status = false;
        }
        public void SetStatus() {
            _status = true;
        }
        // public void SetStatusFalse() {
        //     _status = false;
        // }
        public bool GetStatus() {
            return _status;
        }
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}]{GetGoalName()},({GetGoalDescription()})");
        }
        public override string SaveGoal() {
            string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()}, {GetStatus()} ";
            return goalStructure;
        }
        // public override List<Goal> LoadGoal(Goal goal, HelperClass helper) {
            
            // string gName = parts[0];
                
            // // split the goal name into its components
            // string [] nameSplit = gName.Split(":");
            // var gN = nameSplit[1].Trim(); // goal name comes bundled and needs to be unbundled and trimmed
            
            // var gDescription = parts[1];
            // int gPoint = int.Parse(parts[2]);

            // // if (gName.Contains("SimpleGoal")) {
            // // Get the status of the object
            // var gStatus = parts[3];
            // SimpleGoal simple = new SimpleGoal("",gN, gDescription, gPoint);
            // // This part is necessary to ensure the original status is retained during loading
            // if (gStatus is not "true") {
            //     simple.SetStatusFalse();
            // }
            // HelperClass help = new HelperClass();
            // List<Goal> gList = helper.GetGoalsList();
            // return gList;
        // }
        public override void RecordGoalEvent(HelperClass helper1) {
            bool boo = GetStatus();
            if (boo == false) {
                int point = GetPoint();
                helper1.AddPoints(point);
                this.SetStatus();
                this.UpdateCheck();
            }
        } 
    }
}
