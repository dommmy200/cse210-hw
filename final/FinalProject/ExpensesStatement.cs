using System;

namespace FinancialPrudence {
    public class ExpensesStatement : Statement {
        Information info = new();
        Helper helper1 = new();
        private float _totalAmount;
        public ExpensesStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }
        public override void GetStatement() {
            bool quit = false;
            while (quit) {
                //Display a message
                info.DisplayIncomeInfo();
                Console.WriteLine("Enter name of expense: ");
                string expenseName = Console.ReadLine();
                Console.WriteLine("Enter description of expense: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter the amount of expense: ");
                float expenseSpent = float.Parse(Console.ReadLine());
                float expense = helper1.GetMonthlyIncome(expenseSpent);
                //Append variables to helper list object
                helper1.GetExpensesList(expenseName, description, expense);
                quit = helper1.QuitOrContinue();
            }
        }
        public override void SetStatementTotal(float amount) {
            _totalAmount += amount;
        }
        public override float GetTotal() {
            return _totalAmount;
        }
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
            
    }
}