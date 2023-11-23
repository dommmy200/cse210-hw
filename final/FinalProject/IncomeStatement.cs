using System;

namespace FinancialPrudence {
   
    public class IncomeStatement : Statement {
        Information info = new();
        Helper helper1 = new();
        public IncomeStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }
        public override void GetStatement() {
            bool quit = false;
            while (quit) {
                //Display a message
                info.DisplayIncomeInfo();
                Console.WriteLine("Enter name of income: ");
                string incomeName = Console.ReadLine();
                Console.WriteLine("Enter description of income: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter the amount of income: ");
                float incomeEarned = float.Parse(Console.ReadLine());
                float income = helper1.GetMonthlyIncome(incomeEarned);
                
                //Append variables to helper list object
                helper1.GetIncomeList(incomeName, description, income);
                quit = helper1.QuitOrContinue();
            }
        }
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        
    }
}