using System;
using System.IO;

namespace EternalGoal {
    public abstract class Goal {
        // private string _goalType;
        private string _goalName;
        private string _description;
        private string _check = "";
        private int _point;
        // private bool _status = false;
        // HelperClass helper1 = new HelperClass();

        public Goal(string goalName, string description, int point) {
            // _goalType = goalType;
            _goalName = goalName;
            _description = description;
            _point = point;
        }
        // Returns the class name of the corresponding goal object
        public string GetClassName() {
            var className = GetType().Name;
            return className;
        }
        // This method may not be necessary
        // public string GetGoalType() {
        //     return _goalType;
        // }
        // Returns the corresponding user-defined goal name
        public string GetGoalName() {
            return _goalName;
        }
        // This method may not be necessary
        public string GetCheck() {
            return _check = "X";
        }
        // Returns the corresponding user-defined goal description
        public string GetGoalDescription() {
            return _description;
        }
        public int GetPoint() {
            return _point;
        }
        public abstract void DisplaySubclassObjects(int x);
        public abstract string LoadGoal();
        public abstract string SaveGoal();
        public abstract void RecordGoalEvent(HelpClass helper1);
    }
}