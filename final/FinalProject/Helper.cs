using System;
using System.Globalization;

namespace FinancialPrudence {
    public class Helper {
        Information info = new();
        Statement incomeStatement = new IncomeStatement();
        Statement expenseStatement = new IncomeStatement();
        private List<Statement> _statement = new List<Statement>();
        public void GetStatements(int oneAndTwo) {
            switch (oneAndTwo) {
                case 1:
                    Console.WriteLine("Create Financial Prudence Goals");
                    incomeStatement.GetStatement();
                    expenseStatement.GetStatement();
                    break;
                case 2:
                    Console.WriteLine("Assess Financial Prudence Plan");
                    break;
            }
        }
        public float ConvertToMonthly(float amountEarned, int ans) {
            if (ans == 1) {
                float monthly = amountEarned/12;
                return monthly;
            } else {
                float monthly = amountEarned;
                return monthly;
            }
        }
        public float GetMonthlyIncome(float income) {
            info.DisplayOneTwo();
            // Insert try-catch statement below before submission
            int oneAndTwo = int.Parse(Console.ReadLine());
            return ConvertToMonthly(income, oneAndTwo);
        }
        public List<Statement> GetListObj() {
            return _statement;
        }
        // Format filename to TitleCase to accept mix cases of characters
        public string ToLowerCase (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToLower(str);
            return titleCase;
        }
        public int GetStartPrompt() {
            string prompt = Console.ReadLine();
            int prompt1 = int.Parse(prompt);
            return prompt1;
        }
        public bool QuitOrContinue() {
            info.QuitContinueInfo();
            // Insert try-catch statement below before submission
            int quit = int.Parse(Console.ReadLine());
            if (quit == 2)
                return true;
            return false;
        }
        // Find how to polymorph GetIncomeList() and GetExpensesList() before submission
        public void GetIncomeList(string name, string description, float amount) {
            Statement income = new IncomeStatement(name, description, amount);
            _statement.Add(income);
        } 
        public void GetExpensesList(string name, string description, float amount) {
            Statement expenses = new ExpensesStatement(name, description, amount);
            _statement.Add(expenses);
        } 
    }
}