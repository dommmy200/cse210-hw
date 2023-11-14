using System;
using System.IO;

public class EternalGoal : Goal {
    public EternalGoal(string goalName, string description, int point) : base(goalName,  description, point){
    }
    public override void DisplaySubclassObjects(int serialNumber) {
        Console.WriteLine($"{serialNumber}. {GetGoalName()}, ({GetGoalDescription()})");
    }
    public override string SaveGoal() {
        string goalStructure = $@"{GetClassName()}: {GetGoalName()}, {GetGoalDescription()}, {GetPoint()}";
        return goalStructure;
    }
    public override string LoadGoal() {
        return "Load Goals";
    }
    public override void RecordGoalEvent(HelperClass helper1) {
        int point = GetPoint();
        helper1.AddPoints(point);
    }
}