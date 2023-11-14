using System;
using System.IO;
using System.Threading.Channels;

namespace EternalGoal {
public class ChecklistGoal : Goal {
    private int _maximumCount;
    private int _bonus;
    private int _count;
    private bool _status;
    public ChecklistGoal(string goalName, string description, int point, int bonus, int maximumCount) : base(goalName,  description, point) {
        _bonus = bonus;
        _count = 1;
        _maximumCount = maximumCount;
        _status = false;
    }
    public override void DisplaySubclassObjects(int serialNumber) {
        Console.WriteLine($"{serialNumber}. {GetGoalName()}, ({GetGoalDescription()}) --Completed: {GetCount()-1}/{GetMaximumCount()}");
    }
    public int GetBonus() {
        int i = GetPoint();
        return _bonus + i;
    }
    public int GetDifference() {
        int gBonus = GetBonus();
        int gPoint = GetPoint();
        return gBonus - gPoint;
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
    public void SetStatus() {
        _status = true;
    }
    public bool GetStatus() {
        return _status;
    }
    public override string SaveGoal() {
    string goalStructure = $@"{GetClassName()}: {GetGoalName()}, {GetGoalDescription()}, {GetPoint()}, {GetDifference()}, {GetMaximumCount()}, {GetCount()}, {GetStatus()}";
        return goalStructure;
    }
    public override string LoadGoal() {
        return "Load Goals";
    }
    public override void RecordGoalEvent(HelpClass helper1) {
        int count = GetCount();
        int maxCount = GetMaximumCount();
        if (count < maxCount) {
            int point = GetPoint();
            helper1.AddPoints(point);
            IncrementCount();
        } else if(count == maxCount) {
            bool boo = GetStatus();
            if (boo == false) {
                int bonus = GetBonus();
                helper1.AddPoints(bonus);
                SetStatus();
            }
        }
    }
    
}
}