using System;

namespace FinancialPrudence {
    public class Savings : Statement {
        private int _points;
       
        private int _totalPoints = 60;
        public Savings(string name = "name", string description = "description", float amount = 0) : base (name, description, amount) {
        }
        public int GetPoints() {
            return _points;
        }
        public void SetPoints(int points) {
            _points = points;
        }
        public int GetTotalPoints() {
            return _totalPoints;
        }
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for Savings objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}, {GetPoints()}{TimeManagement.GetToday()}, {GetOldDate()}";
        }
    } 
}