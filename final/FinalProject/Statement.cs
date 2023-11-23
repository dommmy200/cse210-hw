using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        public Statement(string name, string description, float amount) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        public string GetName() {
            return _name;
        }
        public string GetDescription() {
            return _description;
        }
        public float GetAmount() {
            return _amount;
        }

        public abstract Statement SetStatement(Statement statement);
        public abstract void GetStatement();
        public abstract void SetStatementTotal(float amount);
        public abstract float GetTotal();
    }
}