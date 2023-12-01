using System;
using System.Globalization;
using System.IO.IsolatedStorage;

namespace FinancialPrudence {
    public class Helper {
        private Information _info = new();
        private Statement _incomeStatement = new IncomeStatement();
        private Statement _expenseStatement = new IncomeStatement();
        private FilesHandler _filesHandler = new FilesHandler();
        private Savings _savings = new Savings();
        private DebtManagement _debt = new DebtManagement(""); // Remove this string dummy later
        private List<Statement> _statementList = new List<Statement>();
        private bool quit = true;

        public Helper() {
        }
        // Possible duplicate: consider removing
        public List<Statement> GetList() {
            return _statementList;
        }
        // This is valid method
        public int GetStartPrompt() {
            string prompt = Console.ReadLine();
            int prompt1 = int.Parse(prompt);
            return prompt1;
        }
        // This is valid method
        public void GetStatements() {
            while (quit) {
                _info.DisplayIncomeExpensesInfo();
                int x = int.Parse(Console.ReadLine());
                IncomeOrExpenses(x);
                quit = QuitOrContinue();
            }
        }
        // This is valid method
        private void CallQuit(bool quit) {
            quit = false;
        }
        // This is valid method
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
        // This is valid method
        private float ConvertToMonthly(float amountEarned, int ans) {
            if (ans == 1) {
                float monthly = amountEarned/12;
                return monthly;
            } else {
                float monthly = amountEarned;
                return monthly;
            }
        }
        // This is valid method
        public float GetMonthlyIncome(float income) {
            _info.DisplayOneTwo();
            // Insert try-catch statement below before submission
            int oneAndTwo = int.Parse(Console.ReadLine());
            return ConvertToMonthly(income, oneAndTwo);
        }
        // Possible duplicate: consider removing the one above
        public List<Statement> GetListOfObjects() {
            return _statementList;
        }
        // May be commented out and replaced
        public float GetIncomeTotal() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            // float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            return expTotal;
        }
        // May be commented out and replaced
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
        // May be commented out and replaced
        // User input of set object properties
        public void CreateProperties(Statement objects) {
            objects.GetStatement();
        }
        // This is valid method
        // Method to break out of a while-loop 
        public bool QuitOrContinue() {
            _info.QuitContinueInfo();
            // Insert try-catch statement below before submission
            int quit = int.Parse(Console.ReadLine());
            if (quit == 1)
                return true;
            return false;
        }
       // May be commented out and replaced
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
        // This is valid method
        // Compute surplus or deficit amount
        public float GetSurplusOrDeficit() {
            float totalIncome = _incomeStatement.GetTotal();
            float totalExpenses = _expenseStatement.GetTotal();
            return totalIncome - totalExpenses;
        }
        // This is valid method
        private bool IsSurplus(float amount) {
            if (amount > 0)
                return true;
            return false;
        }
        // This is valid method
        public void StartPrudenceExercise(int x, bool quit) {
            switch (x) {
                case 1:
                // Create a new file and set income and expenses statements
                _filesHandler.CreateNewFile();
                GetStatements();
                ToSavingsOrDebtManagement();
                break;
                case 2:
                // Open an existing file and Check financial profile
                _filesHandler.OpenExistingFile();
                FineTuneFPrudence();
                break;
                case 3:
                // Check goals setting progress
                
                break;
                case 4:
                // Quit program
                CallQuit(quit);
                break;
            }
        }
        // May be commented out and replaced
        public void ToSavingsOrDebtManagement() {
            // List<Statement> listOfStatement = GetListOfObjects();
            // SetSurplusAndDeficitTotal(listOfStatement);
            float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            bool quit = true;
            // Check if income and/or expenses statements has zero total
            while (incTotal == 0 && expTotal == 0 || quit) {
                if (incTotal == 0 || expTotal == 0)
                    Console.WriteLine();
                    Console.WriteLine(@"You do not have either Income or Expenses
                                                    statements.");
                    Console.WriteLine();
                if (incTotal == 0) {
                    _incomeStatement.GetStatement();
                    incTotal = GetIncomeTotal();
                    QuitOrContinue();
                } else if (expTotal == 0) {
                    _expenseStatement.GetStatement();
                    expTotal = GetExpenseTotal();
                    QuitOrContinue();
                }
                QuitOrContinue();
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
        // This is valid method
        // This method is called by FineTuneFPrudence()
        private void UpdateStatementAndGoal(List<Statement> objList) {
            int count = 1;
            foreach (Statement objAndGoal in objList) {
                Console.WriteLine($"{count}. {objAndGoal.GetName()}, {objAndGoal.GetDescription()}, {objAndGoal.GetAmount()}");
                count++;
            }
            int sN = int.Parse(Console.ReadLine());
            var obj1 = objList[sN - 1];
            Console.WriteLine(@$"

            Please, input: 
            1. to delete this statement or goal,
            2. to update this income, expense or goal amount.
            
            ");
            int xy = int.Parse(Console.ReadLine());
            DeleteOrUpdate(objList, obj1, xy);
        }
        // This is still a valid method: do not comment out
        // This method is called by UpdateStatementAndGoal()
        private void DeleteOrUpdate(List<Statement> object1, Statement obj, int x) {
            if (x == 1) {
                foreach (Statement object2 in object1) {
                    if (object2 == obj) {
                        object1.Remove(obj);
                    }
                }
            } else if (x == 2) {
                foreach (Statement object2 in object1) {
                    if (object2 == obj) {
                        float amtOld = obj.GetAmount();
                        Console.Write($"Current amount is: {amtOld}. Enter new amount: ");
                        float amtNew = float.Parse(Console.ReadLine());
                        object2.SetAmount(amtNew);
                    }
                }
            }
        }
        // This is valid method
        // Call this method when saved goals needs fine tuning
        public void FineTuneFPrudence() {
            bool quit = true;
            while (quit) {
                List<Statement> incList = _incomeStatement.GetObjectList();
                List<Statement> expList = _expenseStatement.GetObjectList();
                if (incList.Count != 0 && expList.Count != 0) {
                    var difference =  GetSurplusOrDeficit();
                    // If true, manage the deficit by making more income
                    // or reducing expenses
                    if (difference <  0){
                        GetStatements();
                    } else {
                        var list = _savings.GetObjectList(); //Else, set goal from surplus
                        if (list.Count != 0) {
                            // Adjust the goals
                            UpdateStatementAndGoal(list);
                        } else {
                            _savings.GetStatement();
                        }
                    }
                // This file has either no income or expenses provided
                } else if (incList.Count == 0) {
                    _incomeStatement.GetStatement();
                } else {
                    _expenseStatement.GetStatement();
                }
                quit = QuitOrContinue();
            }

        }
    }
}