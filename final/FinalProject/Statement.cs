using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        public Statement(string name = "name", string description = "description", float amount = 0) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        // public string Name {get; set;}
        // public string Description {get; set;}
        // public float Amount {get; set;}
        public string GetName() {
            return _name;
        }
        public string GetDescription() {
            return _description;
        }
        public float GetAmount() {
            return _amount;
        }
        public void SetAmount(float amount) {
            _amount -= amount;
        }
        public string GetClassName() {
            var className = GetType().Name;
            return className;
        }
        public abstract string SaveGoal();
        public abstract Statement SetStatement(Statement statement);
        // consider renaming this method if not returning value: UserStatement()
        public abstract void GetStatement();
        public abstract void SetStatementTotal(float amount);
        public abstract float GetTotal();
    }
}