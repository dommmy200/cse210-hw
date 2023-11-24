using System;

namespace FinancialPrudence {
    public class DebtManagement {
        private string _name;
        private Information _info = new Information();
        private Helper _help = new Helper();
        private Statement _statement1 = new IncomeStatement();
        // Debt management is done here by amount reduction or deletion
        public DebtManagement(string name) {
            _name = name;
        }
        private void ReduceDebt(Helper helper) {
            List<Statement> state = helper.GetListObj();
            for (int i = 0; i < state.Count; i++) {
                string type = state[i].GetType().Name;
                if (type.Contains("expenses")) {
                    Console.WriteLine($"{i+1}. {state[i].GetName()}");
                }
            }
            int x = int.Parse(Console.ReadLine());
            // Information to reduce or delete expenses
            _info.ReduceOrDeleteInfo();
            int rOrD = int.Parse(Console.ReadLine());
            if (rOrD == 1) {
                // Expense amount reduction is done here
                _help.ReduceAmount(state, rOrD);
            } else {
                state.RemoveAt(x-1);
            }
        }
        // Debt management is done here by increasing income
        // and expenses reduction or deletion
        private void IncreaseIncome(Statement statement) {
            statement.GetStatement();
        }
        // Select between Debt management and 
        public void ManageIncomeAndExpense() {
            bool quit = false;
            while (quit) {
                int num = _info.ReduceOrIncreaseInfo();
                switch (num) {
                    case 1:
                        ReduceDebt(_help);
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