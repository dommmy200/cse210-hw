// using System;
// using System.IO;
// using System.Linq;
using System.Globalization;
// using System.Collections.Generic;

namespace EternalGoal {
    public class HelperClass {
        private int _totalPoints;
        private List<Goal> _goalList = new List<Goal>();

        public HelperClass() {
            this.GetTotalPoints();
        }
        public void AddZero() {
            _totalPoints += 0;
        }
        public int GetTotalPoints() {
            return _totalPoints;
        }
        public void AddPoints(int point) {
            _totalPoints += point;
        }
        public void UpdateTotal(int total) {
            _totalPoints = total;
        }
        public void AddBonus(int bonus) {
            _totalPoints += bonus;
        }
        public void AddGoalToList(Goal goal) {
            _goalList.Add(goal);
        }
        public List<Goal> GetGoalsList() {
            return _goalList;
        }
        public void RewardGoalAchieved() {
            for (int i = 0; i < _goalList.Count; i++) {
                string goalName = _goalList[i].GetGoalName();
                Console.WriteLine($"{i+1}. {goalName}");
            }
            Console.Write("Select a goal to record: ");
            string x = Console.ReadLine();
            int selected = int.Parse(x != null ? x : "0");

            Goal goal = _goalList[selected-1];
            goal.RecordGoalEvent(helper1: this);
        }
        public void SaveGoalToFile() {
            Console.Write("Please, give the file a name? ");
            string filename = Console.ReadLine();
            string formattedFilename = FormatFileName(filename);
            // User input filename with, or without, extension is made valid
            var file = formattedFilename.Contains(".txt") ? formattedFilename : formattedFilename + ".txt";
            
            using(StreamWriter outPut = new StreamWriter(file)) {
                outPut.WriteLine(GetTotalPoints());
                Console.WriteLine();
                foreach (Goal goal in _goalList) {
                    string str = goal.SaveGoal();
                    outPut.WriteLine(str);
                }
            }
        }
        // Format filename to TitleCase
        // public string FormatFileName (string str) {
        //     TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        //     string titleCase = textInfo.ToTitleCase(str);
        //     return titleCase;
        // }
        // Necessary for splitting class name into components
        // public string FormatGoalName(Goal obj) {
        //     string secondPart = "Goal";
        //     string clsName = obj.GetType().Name;
        //     int index = clsName.IndexOf(secondPart);
        //     string firstPart = clsName[..index]; //string firstPart = clsName.Substring(0, index);
        //     return $"{firstPart} {secondPart}";
        // }
        public void RecreateAndLoadGoals() {
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            string formattedFilename = FormatFileName(filename);
            var file = formattedFilename.Contains(".txt") ? formattedFilename : formattedFilename + ".txt";
            
            string[] lines = File.ReadAllLines(file);
            
            // Update the total points when loading file to memory
            int updateTotal = int.Parse(lines[0]);
            this.UpdateTotal(updateTotal);
            
            // Skip the line holding the total points variable
            lines = lines.Skip(1).ToArray();
            
            // Iterate the rest of the lines in the file
            foreach (string line in lines) {
                string [] parts = line.Split(",");
                string gName = parts[0];
                
                // split the goal name into its components
                string [] nameSplit = gName.Split(":");
                var goalName1 = nameSplit[1].Trim(); // goal name comes bundled and needs to be unbundled and trimmed
                
                var gDescription = parts[1];
                int gPoint = int.Parse(parts[2]);

                if (gName.Contains("SimpleGoal")) {
                    // Get the string status of the object
                    var gStatus = parts[3];
                    // convert the string to Boolean for further processing
                    bool boo = Convert.ToBoolean(gStatus);
                    SimpleGoal simple = new SimpleGoal("", goalName1, gDescription, gPoint);
                    // This part is necessary to ensure the original status is retained during loading
                    if (boo is true) {
                        simple.UpdateCheck();
                    }
                    _goalList.Add(simple);
                } else if (gName.Contains("EternalGoal")) {
                    EternalGoal eternal = new EternalGoal("", goalName1, gDescription, gPoint);
                    _goalList.Add(eternal);
                    
                } else { // else the name is "ChecklistGoal" 
                    Animation animation = new Animation();
                    List<List<string>> animShape = animation.GetAnimation();
                    List<string> animColor = animation.GetColors();

                    int difference = int.Parse(parts[3]); // Difference is actually the bonus points
                    int mCount = int.Parse(parts[4]);
                    int count = int.Parse(parts[5]);
                    ChecklistGoal checklist = new ChecklistGoal("", goalName1, gDescription, gPoint, difference, mCount);
                    checklist.SetCount(count);
                    if (mCount == count) {
                        checklist.UpdateCheck();
                        for (int i = 0; i < animShape.Count; i++) {
                            List<string> animList = animShape[i];
                            animation.AnimateShapes(animList, animColor);
                        }
                    }
                    _goalList.Add(checklist);
                }
            }
        }
        // Format filename to TitleCase to accept mix cases of characters
        public string FormatFileName (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);
            return titleCase;
        }
    }
}