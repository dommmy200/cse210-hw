using System;
using System.Globalization;
using System.IO.IsolatedStorage;

namespace FinancialPrudence {
    public class Helper {
        // private Information _info = new();
        private static Statement _incomeStatement = new IncomeStatement(); 
        private static Statement _expenseStatement = new ExpensesStatement();
        private static List<Statement> _incomeList = new List<Statement>(); 
        private static List<Statement> _expensesList = new List<Statement>();
        private static List<Statement> _savingsList = new List<Statement>(); 


        // private FilesHandler _filesHandler = new FilesHandler();
        private static Savings _savings = new Savings();
        private static DebtManagement _debt = new DebtManagement(); // Remove this string dummy later
        // private List<Statement> _statementList = new List<Statement>();
        // private string _name;
        // private bool quit = true;
        private static List<Statement> _allObjectsList = new List<Statement>();
        // private List<Statement> _allObjectsListX;
        public static List<Statement> GetAllObjectsList() {
            return _allObjectsList;
        }
        public static List<Statement> GetIncomeList() {
            return _incomeList;
        }
        public static List<Statement> GetExpensesList() {
            return _expensesList;
        }
        public static List<Statement> GetSavingsList() {
            return _savingsList;
        }
        public static void SetIncList(List<Statement> incObj) {
            _incomeList = incObj;
        }
        public static void SetExpList(List<Statement> expObj) {
            _expensesList = expObj;
        }
        public static void SetSavList(List<Statement> savObj) {
            _savingsList = savObj;
        }
        public static bool QuitOrContinue() {
            Information.QuitContinueInfo();
            // Insert try-catch statement below before submission
            int quit = int.Parse(Console.ReadLine());
            if (quit == 1)
                return true;
            return false;
        }
        public static void GetAndAddIncList() {
            _incomeStatement.GetStatement();
            _incomeList.Add(_incomeStatement);
        }
        public static void GetAndAddExpList() {
            _expenseStatement.GetStatement();
            _expensesList.Add(_expenseStatement);
        }

        // public Helper(string name = "helper") {
        //     _name = name;
        // }
        // public void SetList(List<Statement> statementList) {
        //     _statementList = statementList;
        // }

        // This is valid method
        public static int GetStartPrompt() {
            // Insert try-catch statement below before submission
            string prompt = Console.ReadLine();
            int prompt1 = int.Parse(prompt);
            return prompt1;
        }
        // This is valid method
        public void GetTwoStatements() {
            bool quit = true;
            while (quit) {
                Information.DisplayIncomeExpensesInfo();
                int x = int.Parse(Console.ReadLine());
                // IncomeOrExpenses(x);
                switch (x) {
                    case 1: 
                    GetAndAddIncList();
                    break;
                    case 2:
                    GetAndAddExpList();
                    break;
                    case 3:
                    quit = false;
                    break;
                }
            }
        }
        // This is not fully valid method
        // private void CallQuit() {
        //     quit = false;
        // }
        // This is valid method(|)
        // Switch between income and expenses for user input statements
        // public void IncomeOrExpenses(int x) {
        //     switch (x) {
        //         case 1:
        //         _incomeStatement.GetStatement();
        //         break;
        //         case 2:
        //         _expenseStatement.GetStatement();
        //         break;
        //     }
        // }

        // This is valid method(|)
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
        // public List<Statement> GetListOfObjects() {
        //     return _statementList;
        // }
        // This is valid method(|)
        public static float GetIncomeTotal() {
            var allObj = GetAllObjectsList();
            var incList = GetIncomeList();
            for (int i = 0; i < allObj.Count; i++) {
                if (allObj[i].GetType().Name == "IncomeStatement") {
                    incList.Add(allObj[i]);
                }
            }
            SetIncomeOrExpensesTotal(incList);
            float expTotal = _incomeStatement.GetTotal();
            return expTotal;
        }

        // This is valid method(|)
        public static float GetExpensesTotal() {
            var allObj = GetAllObjectsList();
            var incList = GetIncomeList();
            for (int i = 0; i < allObj.Count; i++) {
                if (allObj[i].GetType().Name == "ExpensesStatement") {
                    incList.Add(allObj[i]);
                }
            }
            SetIncomeOrExpensesTotal(incList);
            float expTotal = _expenseStatement.GetTotal();
            return expTotal;
        }
       // This is valid method(|)
        // Compute total for income and expenses
        public static void SetIncomeOrExpensesTotal(List<Statement> objectList) {
            foreach (Statement statement in objectList) {
                float amt = statement.GetAmount();
                statement.SetStatementTotal(amt);                    
            }
        }
        
        // This is valid method(|)
        // Compute surplus or deficit amount
        public static float GetSurplusOrDeficit() {
            float totalIncome = GetIncomeTotal();
            float totalExpenses = GetExpensesTotal();
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
        // public void StartPrudenceExercise() {
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
        // Note: This may not be valid method(X). Please, crosscheck!
        public static void ToSavingsOrDebtManagement() {
            float incTotal = _incomeStatement.GetTotal();
            float expTotal = _expenseStatement.GetTotal();
            bool quit = true;
            // Check if income and/or expenses statements has zero total
            while (quit) {
                if (incTotal.Equals(0f)) {
                    Console.WriteLine();
                    Console.Write(@"You have not made Income statements. ");
                    PressToContinue();
                     _incomeStatement.GetStatement();
                } else if (expTotal.Equals(0f)) {
                    Console.WriteLine();
                    Console.Write(@"You have not made Expenses statements. ");
                    PressToContinue();
                    _expenseStatement.GetStatement();
                } else {
                    quit = QuitOrContinue();
                }
                // Helper.QuitOrContinue();
            }
            // The difference between income and expenses is computed here
            float difference = GetSurplusOrDeficit();
            if (IsSurplus(difference)) {
                Information.SavingsNotice();
                PressToContinue();
                _savings.GetStatement();
            } else {
                Information.DeficitNotice();
                PressToContinue();
                _debt.ManageIncomeAndExpense();
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
            Console.WriteLine();
            foreach (Statement objAndGoal in objList) {
                Console.WriteLine($"{count}. {objAndGoal.GetName()}, {objAndGoal.GetDescription()}, (-{objAndGoal.GetAmount()}-)");
                count++;
            }
            Information.SelectAnyInfo();
            // Insert try-catch statement below before submission
            int sN = int.Parse(Console.ReadLine());
            var obj1 = objList[sN - 1];
            Console.WriteLine();
            Information.ReduceOrDeleteInfo();
            Console.WriteLine();
            // Insert try-catch statement below before submission
            int selected = int.Parse(Console.ReadLine());
            DeleteOrUpdate(objList, obj1, selected);
        }
        // This is valid method(|)
        // This method is called by UpdateStatementAndGoal()
        private static void DeleteOrUpdate(List<Statement> object1, Statement obj, int selected) {
            if (selected == 1) {
                // Delete the selected goal or statement
                for (int i = 0; i < object1.Count; i++) {
                    if (object1[i] == obj) {
                        object1.RemoveAt(i);
                        Information.RemoveObjectInfo(obj);
                        Console.WriteLine();
                        Information.PressToContinueInfo();
                    }
                }
            } else if (selected == 2) {
                // Make adjustment to the amount on the selected goal or statement
                for (int i = 0; i < object1.Count; i++) {
                    if (object1[i] == obj) {
                        float amtOld = object1[i].GetAmount();
                        // Console.Write($"Current amount is: {amtOld}. Enter new amount: ");
                        Information.AdjustAmountInfo(amtOld);
                        float amtNew = float.Parse(Console.ReadLine());
                        object1[i].SetAmount(amtNew);
                        _savings.SetPoints(_savings.ComputePoints(amtNew));
                    }
                }
            }
        }
        // This is valid method(|)
        // Call this method when saved goals needs fine tuning ie
        // adjusting the goals' amount
        public void FineTuneFinancialPrudence() {
            bool quit = true;
            while (quit) {
                List<Statement> incList = GetIncomeList();
                List<Statement> expList = GetExpensesList();
                // Treats the case where income and expenses lists are empty
                if (incList.Count != 0 && expList.Count != 0) {
                    var difference =  GetSurplusOrDeficit();
                    // If true, manage the deficit by making more income
                    // or reducing expenses
                    if (difference <  0){
                        GetTwoStatements();
                    } else {
                        var list = GetSavingsList(); //Else, set goal from surplus
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
                quit = QuitOrContinue();
            }
        
        }
    }
}