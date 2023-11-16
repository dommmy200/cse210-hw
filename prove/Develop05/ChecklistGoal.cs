using System;
using System.IO;
using System.Threading.Channels;

namespace EternalGoal {
    public class ChecklistGoal : Goal {
        private int _maximumCount;
        private int _bonus;
        private int _count;
        public ChecklistGoal(string check, string goalName, string description, int point, int bonus, int maximumCount) : base(check, goalName,  description, point) {
            _bonus = bonus;
            _count = 0;
            _maximumCount = maximumCount;
        }
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}]{GetGoalName()},({GetGoalDescription()}) --Completed: {GetCount()}/{GetMaximumCount()}");
        }
        public int GetBonus() {
            return _bonus;
        }
        // public int GetDifference() {
        //     int gBonus = GetBonus();
        //     int gPoint = GetPoint();
        //     return gBonus - gPoint;
        // }
        public int GetMaximumCount() {
            return _maximumCount;
        }
        public int GetCount() {
        return _count;
        }
        public void IncrementCount() {
            _count++;
        }
        public void SetCount(int count) {
            _count = count;
        }
        // public void SetStatus() {
        //     _status = true;
        // }
        // public bool GetStatus() {
        //     return _status;
        // }
        public override string SaveGoal() {
        string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()},{GetBonus()},{GetMaximumCount()},{GetCount()}";
            return goalStructure;
        }
        // public override List<Goal> LoadGoal(Goal goal, HelperClass helper) {
                
            // string gName = parts[0];
                
            // // split the goal name into its components
            // string [] nameSplit = gName.Split(":");
            // var gN = nameSplit[1].Trim(); // goal name comes bundled and needs to be unbundled and trimmed
            
            // var gDescription = parts[1];
            // int gPoint = int.Parse(parts[2]);

            // int difference = int.Parse(parts[3]); // Difference is actually the bonus points
            // int mCount = int.Parse(parts[4]);
            // int count = int.Parse(parts[5]);
            // ChecklistGoal checklist = new ChecklistGoal("", gN, gDescription, gPoint, difference, mCount);
            // checklist.SetCount(count);
            // if (mCount == count) {
            //     checklist.SetStatus();
            // }
            // HelperClass help = new HelperClass();
            // help.AddGoalToList(checklist);

        //     List<Goal> gList = helper.GetGoalsList();
        //     return gList;
        // }
        public override void RecordGoalEvent(HelperClass helper1) {
            int count = GetCount() + 1;
            int maxCount = GetMaximumCount();
            if (count < maxCount) {
                int point = GetPoint();
                helper1.AddPoints(point);
                IncrementCount();
            } else if(count == maxCount) {
                int bonus = GetBonus();
                int point = GetPoint();
                
                helper1.AddPoints(point);
                helper1.AddBonus(bonus);
                IncrementCount();
                //this.SetStatus();
                this.UpdateCheck();
            }
        }
    }
}