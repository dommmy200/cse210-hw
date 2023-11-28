using System;
using System.Globalization;
using System.IO.IsolatedStorage;

namespace FinancialPrudence {
    public class Helper {
        private Information _info = new();
        private Statement _incomeStatement = new IncomeStatement();
        private Statement _expenseStatement = new IncomeStatement();
        private Savings _savings = new Savings();
        private DebtManagement _debt = new DebtManagement(""); // Remove this string dummy later
        private List<Statement> _statementList = new List<Statement>();
        private bool quit = true;

        public Helper() {
        }
        public List<Statement> GetList() {
            return _statementList;
        }
        public void GetStatements() {
            while (quit) {
                _info.DisplayIncomeExpensesInfo();
                int x = int.Parse(Console.ReadLine());
                IncomeOrExpenses(x);
                quit = QuitOrContinue();
            }
        }
        private void CallQuit(bool quit) {
            quit = false;
        }
        // Switch between income and expenses for user input statements
        public void IncomeOrExpenses(int x) {
            switch (x) {
                case 1:
                _incomeStatement.GetStatement();
                break;
                case 2:
                _expenseStatement.GetStatement();
                break;
            }
        }
        private float ConvertToMonthly(float amountEarned, int ans) {
            if (ans == 1) {
                float monthly = amountEarned/12;
                return monthly;
            } else {
                float monthly = amountEarned;
                return monthly;
            }
        }
        public float GetMonthlyIncome(float income) {
            _info.DisplayOneTwo();
            // Insert try-catch statement below before submission
            int oneAndTwo = int.Parse(Console.ReadLine());
            return ConvertToMonthly(income, oneAndTwo);
        }
        public List<Statement> GetListOfObjects() {
            return _statementList;
        }
        public float GetIncomeTotal() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            // float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            return expTotal;
        }
        public float GetExpenseTotal() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            float incTotal = _incomeStatement.GetTotal();
            // float expTotal = _expenseStatement.GetTotal();
            return incTotal;
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
        // Method to break out of a while-loop 
        public bool QuitOrContinue() {
            _info.QuitContinueInfo();
            // Insert try-catch statement below before submission
            int quit = int.Parse(Console.ReadLine());
            if (quit == 1)
                return true;
            return false;
        }
        // Compute total for income and expenses
        public void SetSurplusAndDeficitTotal(List<Statement> statements) {
            foreach (Statement statement in statements) {
                string objectName = statement.GetType().Name;
                float amt = statement.GetAmount();
                if (objectName.Contains("incomeStatement")) {
                    statement.SetStatementTotal(amt);
                } else if (objectName.Contains("expensesStatement")) {
                    statement.SetStatementTotal(amt);                    
                }
            }
        }
        // Compute surplus or deficit amount
        public float GetSurplusOrDeficit() {
            float totalIncome = _incomeStatement.GetTotal();
            float totalExpenses = _expenseStatement.GetTotal();
            return totalIncome - totalExpenses;
        }
        private bool IsSurplus(float amount) {
            if (amount > 0)
                return true;
            return false;
        }
        public void StartPrudenceExercise(int x, bool quit) {
            switch (x) {
                case 1:
                // GetStatement
                GetStatements();
                break;
                case 2:
                // Check financial profile
                ToSavingsOrDebtManagement();
                break;
                case 3:
                // Record Achievement
                break;
                case 4:
                // Quit program
                CallQuit(quit);
                break;
            }
        }
        public void ToSavingsOrDebtManagement() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            // Check if income and/or expenses statements has zero total
            while (incTotal == 0 || expTotal == 0) {
                Console.WriteLine("Please, populate either Income or Expenses or both.");
                if (incTotal == 0) {
                    _incomeStatement.GetStatement();
                    incTotal = GetIncomeTotal();
                } else if (expTotal == 0) {
                    _expenseStatement.GetStatement();
                    expTotal = GetExpenseTotal();
                }
            }
            // The difference between income and expenses is computed here
            float difference = GetSurplusOrDeficit();
            if (IsSurplus(difference)) {
                _savings.GetStatement();
            } else {
                _debt.ManageIncomeAndExpense();
            }
        }
        public void ReduceAmount(List<Statement> state, int x) {
            Console.WriteLine($"{state[x-1].GetAmount()}");
            Console.Write($"Reduce this amount by: ");
            float amt = float.Parse(Console.ReadLine());
            state[x-1].SetAmount(amt);
        }
        // Find how to polymorph GetIncomeList() and GetExpensesList() before submission
        public void AddToIncomeList(string name, string description, float amount) {
            Statement income = new IncomeStatement(name, description, amount);
            var helperList = GetList();
            helperList.Add(income);
        } 
        public void AddToExpensesList(string name, string description, float amount) {
            Statement expenses = new ExpensesStatement(name, description, amount);
            var helperList = GetList();
            helperList.Add(expenses);
        } 
    }
}