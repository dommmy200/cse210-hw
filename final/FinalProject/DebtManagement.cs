using System;

namespace FinancialPrudence {
    public class DebtManagement {
        // private string _name;
        // private Information _info = new Information();
        private Helper _helper = new Helper();
        private Statement _statement1 = new IncomeStatement();
        // Debt management is done here by amount reduction or deletion
        // public DebtManagement(string name) {
        //     _name = name;
        // }
        private void ReduceDebt() {
            List<Statement> expenses = _helper.GetExpensesList();
            for (int i = 0; i < expenses.Count; i++) {
                Console.WriteLine($"{i+1}. {expenses[i].GetName()}");
            }
            int x = int.Parse(Console.ReadLine());
            // Information to reduce or delete expenses
            Information.ReduceOrDeleteInfo();
            int rOrD = int.Parse(Console.ReadLine());
            if (rOrD == 1) {
                // Expense amount reduction is done here
                Helper.ReduceAmount(expenses, rOrD);
            } else {
                expenses.RemoveAt(x-1);
            }
        }
        // Debt management is done here by increasing income
        // and expenses reduction or deletion
        private void IncreaseIncome(Statement statement) {
            statement.GetStatement();
            _helper.SaveToObjectList(statement);
        }
        // Select between Debt management and 
        public void ManageIncomeAndExpense() {
            bool quit = false;
            while (quit) {
                int num = Information.ReduceOrIncreaseInfo();
                switch (num) {
                    case 1:
                        ReduceDebt();
                        break;
                    case 2:
                        IncreaseIncome(_statement1);
                        break;
                    case 3:
                        quit = true;
                        break;
                }
            }
        }
    }
}