using System;

namespace FinancialPrudence {
    public class ExpensesStatement : Statement {
        private Information _info = new();
        private Helper _helper1 = new();
        public ExpensesStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }
        // public override void GetStatement() {
        //     bool quit = false;
        //     while (quit) {
        //         // Display a message
        //         _info.DisplayIncomeInfo();
        //         Console.WriteLine("Enter name of expense: ");
        //         string expenseName = Console.ReadLine();
        //         Console.WriteLine("Enter description of expense: ");
        //         string description = Console.ReadLine();
        //         Console.WriteLine("Enter the amount of expense: ");
        //         float expenseSpent = float.Parse(Console.ReadLine());
        //         // Convert annual income to monthly income
        //         float expense = _helper1.GetMonthlyIncome(expenseSpent);
        //         //Append variables to helper list object
        //         _helper1.AddToExpensesList(expenseName, description, expense);
        //         // User quits (or continue) the loop
        //         quit = _helper1.QuitOrContinue();
        //     }
        // }
        // public override void SetStatementTotal(float amount) {
        //     _totalAmount += amount;
        // }
        // public override float GetTotal() {
        //     return _totalAmount;
        // }
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for ExpensesStatement objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}";
        }    
    }
}