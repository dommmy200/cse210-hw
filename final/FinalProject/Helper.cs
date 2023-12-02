using System;
using System.Globalization;
using System.IO.IsolatedStorage;

namespace FinancialPrudence {
    public static class Helper {
        // private Information _info = new();
        private static Statement _incomeStatement = new IncomeStatement(); 
        private static Statement _expenseStatement = new ExpensesStatement();
//         private FilesHandler _filesHandler = new FilesHandler();
        private static Savings _savings = new Savings();
//         private DebtManagement _debt = new DebtManagement(""); // Remove this string dummy later
//         private List<Statement> _statementList = new List<Statement>();
        // private string _name;
        private static bool quit = true;
        private static List<Statement> _statementList;

        public static bool QuitOrContinue() {
            Information.QuitContinueInfo();
            // Insert try-catch statement below before submission
            int quit = int.Parse(Console.ReadLine());
            if (quit == 1)
                return true;
            return false;
        }

        // public Helper(string name = "helper") {
        //     _name = name;
        // }

        // This is valid method
        public static int GetStartPrompt() {
            string prompt = Console.ReadLine();
            int prompt1 = int.Parse(prompt);
            return prompt1;
        }
        // This is valid method
        public static void GetTwoStatements() {
            while (quit) {
                Information.DisplayIncomeExpensesInfo();
                int x = int.Parse(Console.ReadLine());
                // IncomeOrExpenses(x);
                switch (x) {
                    case 1:
                    _incomeStatement.GetStatement();
                    break;
                    case 2:
                    _expenseStatement.GetStatement();
                    break;
                    case 3:
                    quit = false;
                    break;
                }
            }
        }
        // This is valid method
        // private static void CallQuit() {
        //     quit = false;
        // }
        // This is valid method(|)
        // Switch between income and expenses for user input statements
        // public static void IncomeOrExpenses(int x) {
        //     switch (x) {
        //         case 1:
        //         _incomeStatement.GetStatement();
        //         break;
        //         case 2:
        //         _expenseStatement.GetStatement();
        //         break;
        //     }
        // }
        public static void PressToContinue() {
            Information.PressToContinueInfo();
            Console.ReadKey();
            Console.Clear();
        }
        // This is valid method(|)
        private static float ConvertToMonthly(float amountEarned, int ans) {
            if (ans == 1) {
                float monthly = amountEarned/12;
                return monthly;
            } else {
                float monthly = amountEarned;
                return monthly;
            }
        }
        // This is valid method(|)
        public static float GetMonthlyIncome(float income) {

            Information.DisplayOneTwo();
            // Insert try-catch statement below before submission
            int oneAndTwo = int.Parse(Console.ReadLine());
            return ConvertToMonthly(income, oneAndTwo);
        }
        // This is valid method(|)
        public static List<Statement> GetListOfObjects() {
            return _statementList;
        }
        // This is valid method(|)
        public static float GetIncomeTotal() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            // float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            return expTotal;
        }
        // This is valid method(|)
        public static float GetExpenseTotal() {
            List<Statement> listOfStatement = GetListOfObjects();
            SetSurplusAndDeficitTotal(listOfStatement);
            float incTotal = _incomeStatement.GetTotal();
            // float expTotal = _expenseStatement.GetTotal();
            return incTotal;
        }
       // This is valid method(|)
        // Compute total for income and expenses
        public static void SetSurplusAndDeficitTotal(List<Statement> statements) {
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
        // This is valid method(|)
        // Compute surplus or deficit amount
        public static float GetSurplusOrDeficit() {
            float totalIncome = _incomeStatement.GetTotal();
            float totalExpenses = _expenseStatement.GetTotal();
            return totalIncome - totalExpenses;
        }
        // This is valid method(|)
        private static bool IsSurplus(float amount) {
            if (amount > 0)
                return true;
            return false;
        }
        // Note: The method below has been transferred to Program.cs for now 

        // The first method to call for selection of the prudence exercise
        // public static void StartPrudenceExercise() {
        //     string prompt = Console.ReadLine();
        //     int prompt1 = int.Parse(prompt);
        //     switch (prompt1) {
        //         case 1:
        //         Console.WriteLine($"{prompt1}");
        //         // Create a new file and set income and expenses statements
        //         // _filesHandler.CreateNewFile();
        //         // GetStatements();
        //         // ToSavingsOrDebtManagement();
        //         break;
        //         case 2:
        //         Console.WriteLine($"{prompt1}");
        //         // Open an existing file and Check financial profile
        //         // _filesHandler.OpenExistingFile();
        //         // FineTuneFPrudence();
        //         break;
        //         case 3:
        //         Console.WriteLine($"{prompt1}");
        //         // Check goals setting progress
        //         break;
        //         // case 4:
        //         // Console.WriteLine($"{prompt1}");
        //         // // Quit program
        //         // quit = Helper.QuitOrContinue();
        //         // break;
        //     }
        // }
        // This is valid method(|)
        public static void ToSavingsOrDebtManagement() {
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
                    Helper.QuitOrContinue();
                } else if (expTotal == 0) {
                    _expenseStatement.GetStatement();
                    expTotal = GetExpenseTotal();
                    Helper.QuitOrContinue();
                }
                Helper.QuitOrContinue();
            }
            // The difference between income and expenses is computed here
            float difference = GetSurplusOrDeficit();
            if (IsSurplus(difference)) {
                _savings.GetStatement();
            } else {
                DebtManagement.ManageIncomeAndExpense();
            }
        }
        // May be commented out and replaced(X)
        public static void ReduceAmount(List<Statement> state, int x) {
            Console.WriteLine($"{state[x-1].GetAmount()}");
            Console.Write($"Reduce this amount by: ");
            float amt = float.Parse(Console.ReadLine());
            state[x-1].SetAmount(amt);
        }
        // This is valid method(|)
        // This method is called by FineTuneFPrudence()
        private static void UpdateStatementAndGoal(List<Statement> objList) {
            int count = 1;
            foreach (Statement objAndGoal in objList) {
                Console.WriteLine($"{count}. {objAndGoal.GetName()}, {objAndGoal.GetDescription()}, {objAndGoal.GetAmount()}");
                count++;
            }
            int sN = int.Parse(Console.ReadLine());
            var obj1 = objList[sN - 1];
            Information.ReduceOrDeleteInfo();
            int xy = int.Parse(Console.ReadLine());
            Helper.DeleteOrUpdate(objList, obj1, xy);
        }
        // This is valid method(|)
        // This method is called by UpdateStatementAndGoal()
        private static void DeleteOrUpdate(List<Statement> object1, Statement obj, int x) {
            if (x == 1) {
                // Delete the selected goal or statement
                foreach (Statement object2 in object1) {
                    if (object2 == obj) {
                        object1.Remove(obj);
                    }
                }
            } else if (x == 2) {
                // Make adjustment to the amount on the selected goal or statement
                foreach (Statement object2 in object1) {
                    if (object2 == obj) {
                        float amtOld = obj.GetAmount();
                        Console.Write($"Current amount is: {amtOld}. Enter new amount: ");
                        float amtNew = float.Parse(Console.ReadLine());
                        obj.SetAmount(amtNew);
                        _savings.SetPoints(Savings.ComputePoints(amtNew));
                    }
                }
            }
        }
        // This is valid method(|)
        // Call this method when saved goals needs fine tuning ie
        // adjusting the goals' amount
        public static void FineTuneFinancialPrudence() {
            bool quit = true;
            while (quit) {
                List<Statement> incList = _incomeStatement.GetObjectList();
                List<Statement> expList = _expenseStatement.GetObjectList();
                // Treats the case where income and expenses lists are empty
                if (incList.Count != 0 && expList.Count != 0) {
                    var difference =  GetSurplusOrDeficit();
                    // If true, manage the deficit by making more income
                    // or reducing expenses
                    if (difference <  0){
                        GetTwoStatements();
                    } else {
                        var list = _savings.GetObjectList(); //Else, set goal from surplus
                        if (list.Count != 0) {
                            // Adjust the goals
                            UpdateStatementAndGoal(list);
                        } else {
                            _savings.GetStatement();
                        }
                    }
                } else if (incList.Count == 0) {
                    // Treats the case where income list is empty
                    _incomeStatement.GetStatement();
                } else {
                    // Treats the case where expenses list is empty
                    _expenseStatement.GetStatement();
                }
                quit = Helper.QuitOrContinue();
            }

        }
    }
}