using System;
using System.IO;

public class SimpleGoal : Goal {
    private bool _status;
    // private int _totalPoints;
    public SimpleGoal(string goalName, string description, int point) : base(goalName,  description, point){
        _status = false;
    }
    public void SetStatus() {
        _status = true;
    }
    public void SetStatusFalse() {
        _status = false;
    }
    public bool GetStatus() {
        return _status; //you may not need this method eventually. Let's wait for drafting RewardPoints
    }
    public override void DisplaySubclassObjects(int serialNumber) {
        Console.WriteLine($"{serialNumber}. {GetGoalName()}, ({GetGoalDescription()})");
    }
    public override string SaveGoal() {
        string goalStructure = $@"{GetClassName()}: {GetGoalName()}, {GetGoalDescription()}, {GetPoint()}, {GetStatus()} ";
        return goalStructure;
    }
    public override string LoadGoal() {
        return "Load Goals";
    }
    public override void RecordGoalEvent(HelperClass helper1) {
        bool boo = GetStatus();
        if (boo == false) {
            int point = GetPoint();
            helper1.AddPoints(point);
            SetStatus();
        } else {
            Console.WriteLine("You have achieved your goal.");
        }
    }
}