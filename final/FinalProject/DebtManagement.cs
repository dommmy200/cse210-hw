using System;

namespace FinancialPrudence {
    public static class DebtManagement {
        // private string _name;
        // private Information _info = new Information();
        // private Helper _helper1 = new();
        private static Statement _statement1 = new IncomeStatement();
        // Debt management is done here by amount reduction or deletion
        // public DebtManagement(string name) {
        //     _name = name;
        // }
        private static void ReduceDebt() {
            List<Statement> state = Helper.GetListOfObjects();
            for (int i = 0; i < state.Count; i++) {
                string type = state[i].GetType().Name;
                if (type.Contains("expenses")) {
                    Console.WriteLine($"{i+1}. {state[i].GetName()}");
                }
            }
            int x = int.Parse(Console.ReadLine());
            // Information to reduce or delete expenses
            Information.ReduceOrDeleteInfo();
            int rOrD = int.Parse(Console.ReadLine());
            if (rOrD == 1) {
                // Expense amount reduction is done here
                Helper.ReduceAmount(state, rOrD);
            } else {
                state.RemoveAt(x-1);
            }
        }
        // Debt management is done here by increasing income
        // and expenses reduction or deletion
        private static void IncreaseIncome(Statement statement) {
            statement.GetStatement();
        }
        // Select between Debt management and 
        public static void ManageIncomeAndExpense() {
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