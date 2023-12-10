using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        private float _totalAmount = 0;
        private static string _oldDate= "yyyy-MM-dd"; 
        public Statement(string name = "name", string description = "description", float amount = 0) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        public static void SetOldDate(string oldDate) {
            _oldDate = oldDate;
        }
        public static string GetOldDate() {
            return _oldDate;
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
        public void SetName(string name) {
            _name = name;
        }
        public void SetDescription(string description) {
            _description = description;
        }
        public void SetAmount(float amount) {
            _amount = amount;
        }
        public void SetStatementTotal(float amount) {
            _totalAmount += amount;
        }
        public float GetTotal() {
            return _totalAmount;
        }
        public string GetClassName() {
            var className = GetType().Name;
            return className;
        }
        public void GetStatement() {
            Console.Write("Enter name of statement: ");
            string name = Console.ReadLine();
            SetName(name);
            Console.Write("Enter description of statement: ");
            string description = Console.ReadLine();
            SetDescription(description);
            Console.Write("Enter the amount for statement: ");
            float incomeEarned = float.Parse(Console.ReadLine());
            // Convert annual income to monthly income
            float income = Helper.GetMonthlyIncome(incomeEarned);
            SetAmount(income);
            SetStatementTotal(income);
            }
        public abstract string SaveGoal();
        public abstract Statement SetStatement(Statement statement);
    }
}