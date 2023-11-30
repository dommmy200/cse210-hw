using System;

namespace FinancialPrudence {
   
    public class IncomeStatement : Statement {
        private Information _info = new();
        private Helper _helper1 = new();
        public IncomeStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }
        // public override void GetStatement() {
        //     bool quit = true;
        //     while (quit) {
        //         // Display a message
        //         _info.DisplayIncomeInfo();
        //         Console.WriteLine("Enter name of income: ");
        //         string incomeName = Console.ReadLine();
        //         Console.WriteLine("Enter description of income: ");
        //         string description = Console.ReadLine();
        //         Console.WriteLine("Enter the amount of income: ");
        //         float incomeEarned = float.Parse(Console.ReadLine());
        //         // Convert annual income to monthly income
        //         float income = _helper1.GetMonthlyIncome(incomeEarned);
        //         //Append variables to list object
        //         _helper1.AddToIncomeList(incomeName, description, income);
        //         // User quits (or continue) the loop
        //         quit = _helper1.QuitOrContinue();
        //     }
        // }

        // consider renaming this method if not returning value: PassStatement()
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for IncomeStatement objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}";
        }
    }
}