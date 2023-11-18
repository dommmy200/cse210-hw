using System;
using System.IO;
using System.Threading.Channels;

namespace EternalGoal {
    public class ChecklistGoal : Goal {
        private int _maximumCount;
        private int _bonus;
        private int _count;
        string[] _colorString = new string[10]{
                    "Blue", "Yellow", "Red", 
                    "Green", "Cyan", "Gray",
                    "DarkBlue","DarkGray", "DarkCyan", 
                    "DarkYellow"
                };
        // ChecklistGoal Constructor
        public ChecklistGoal(string check, string goalName, string description, int point,  int bonus, int maximumCount) : base(check, goalName,  description, point) {
            _bonus = bonus;
            _count = 0;
            _maximumCount = maximumCount;
        }
        // Defines the listing structure for display on screen
        public override void DisplaySubclassObjects(int serialNumber) {
            Console.WriteLine($"{serialNumber}. [{GetCheck()}]{GetGoalName()},({GetGoalDescription()}) --Completed: {GetCount()}/{GetMaximumCount()}");
        }
        public int GetBonus() {
            return _bonus;
        }
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
        // Defines the template for storage on file 
        public override string SaveGoal() {
        string goalStructure = $"{GetClassName()}:{GetGoalName()},{GetGoalDescription()},{GetPoint()},{GetBonus()},{GetMaximumCount()},{GetCount()}";
            return goalStructure;
        }
        // Defines the goal recording process and display animation if set goal is achieved
        public override void RecordGoalEvent(HelperClass helper1) {
            int count = GetCount() + 1;
            int maxCount = GetMaximumCount();
            if (count < maxCount) {
                int point = GetPoint();
                helper1.AddPoints(point);
                IncrementCount();
            } else if(count == maxCount) {

                Animation animation = new Animation(_colorString);

                int bonus = GetBonus();
                int point = GetPoint();
                
                helper1.AddPoints(point);
                helper1.AddBonus(bonus);
                IncrementCount();
                UpdateCheck();

                animation.AnimateShapes();
            }
        }
    }
}