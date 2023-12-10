using System;
using System.Globalization;
using System.IO.IsolatedStorage;

namespace FinancialPrudence {
    public class Helper {
        private Statement _incomeStatement = new IncomeStatement(); 
        private Statement _expenseStatement = new ExpensesStatement();
        private List<Statement> _incomeList = new List<Statement>(); 
        private List<Statement> _expensesList = new List<Statement>();
        private List<Statement> _savingsList = new List<Statement>(); 
        private static Savings _savings = new Savings();
        // private static DebtManagement _debt = new DebtManagement(); 
        private static List<Statement> _allObjectsList = new List<Statement>();
        public static List<Statement> GetAllObjectsList() {
            return _allObjectsList;
        }
        public List<Statement> GetIncomeList() {
            return _incomeList;
        }
        public void AddToIncomeList(IncomeStatement income) {
            _incomeList.Add(income);
        }
        public void AddToExpensesList(ExpensesStatement expenses) {
            _incomeList.Add(expenses);
        }
        public List<Statement> GetExpensesList() {
            return _expensesList;
        }
        public List<Statement> GetSavingsList() {
            return _savingsList;
        }
        public void SetIncList(List<Statement> incObj) {
            _incomeList = incObj;
        }
        public void SetExpList(List<Statement> expObj) {
            _expensesList = expObj;
        }
        public void SetSavList(List<Statement> savObj) {
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
        public static int GetStartPrompt() {
            // Insert try-catch statement below before submission
            string prompt = Console.ReadLine();
            int prompt1 = int.Parse(prompt);
            return prompt1;
        }
        // To get income and expenses statements
        public void GetTwoStatements() {
            bool quit = true;
            while (quit) {
                Information.DisplayIncomeExpensesInfo();
                int x = int.Parse(Console.ReadLine());
                // IncomeOrExpenses(x);
                switch (x) {
                    case 1: 
                    _incomeStatement.GetStatement();
                    SaveToObjectList(_incomeStatement);
                    break;
                    case 2:
                    _expenseStatement.GetStatement();
                    SaveToObjectList(_expenseStatement);
                    break;
                    case 3:
                    quit = false;
                    break;
                }
            }
        }
        // Used in uploading files to memory
        public void SaveToObjectList(Statement instance) {
            if (instance.GetType().Name == "IncomeStatement") {
                var iList = GetIncomeList();
                iList.Add(instance);
            } else if (instance.GetType().Name == "ExpensesStatement") {
                var iList = GetExpensesList();
                iList.Add(instance);
            } else {
                var iList = GetSavingsList();
                iList.Add(instance);
            }
        }

        // Pause and ask to continue
        public static void PressToContinue() {
            Information.PressToContinueInfo();
            Console.ReadKey();
            Console.Clear();
        }
        // Convert amount between monthly and annually
        private static float ConvertToMonthly(float amountEarned, int ans) {
            if (ans == 1) {
                float monthly = amountEarned/12;
                return monthly;
            } else {
                float monthly = amountEarned;
                return monthly;
            }
        }
        // Used to get user choice
        public static float GetMonthlyIncome(float income) {

            Information.DisplayOneTwo();
            // Insert try-catch statement below before submission
            int oneAndTwo = int.Parse(Console.ReadLine());
            return ConvertToMonthly(income, oneAndTwo);
        }
        // Total amount in income list
        public float GetIncomeTotal() {
            var incList = GetIncomeList();
            SetIncomeOrExpensesTotal(incList);
            float expTotal = _incomeStatement.GetTotal();
            return expTotal;
        }

        // Total amount in expenses list
        public float GetExpensesTotal() {
            var expList = GetExpensesList();
            SetIncomeOrExpensesTotal(expList);
            float expTotal = _expenseStatement.GetTotal();
            return expTotal;
        }
        // Compute total for income and expenses
        public void SetIncomeOrExpensesTotal(List<Statement> objectList) {
            foreach (Statement statement in objectList) {
                float amt = statement.GetAmount();
                statement.SetStatementTotal(amt);                    
            }
        }
        // Compute surplus or deficit amount
        public float GetSurplusOrDeficit() {
            float totalIncome = GetIncomeTotal();
            float totalExpenses = GetExpensesTotal();
            return totalIncome - totalExpenses;
        }
        // Conditional statement
        public static bool IsSurplus(float amount) {
            if (amount > 0)
                return true;
            return false;
        }
        // Complements the savings reduction
        public static void ReduceAmount(List<Statement> state, int x) {
            Console.WriteLine($"{state[x-1].GetAmount()}");
            Console.Write($"Reduce this amount by: ");
            float amt = float.Parse(Console.ReadLine());
            state[x-1].SetAmount(amt);
        }
        // This method is called by FineTuneFPrudence()
        public void UpdateStatementAndGoal(List<Statement> objList) {
            int count = 1;
            Console.WriteLine();
            foreach (Statement objAndGoal in objList) {
                Console.WriteLine($"{count}. {objAndGoal.GetName()}, {objAndGoal.GetDescription()}, ({objAndGoal.GetAmount()})");
                count++;
            }
            Information.SelectAnyInfo();
            // Insert try-catch statement if time permits
            int sN = int.Parse(Console.ReadLine());
            var obj1 = objList[sN - 1];
            Console.WriteLine();
            Information.ReduceOrDeleteInfo();
            Console.WriteLine();
            // Insert try-catch statement if time permits
            int selected = int.Parse(Console.ReadLine());
            DeleteOrUpdate(objList, obj1, selected);
        }
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
                        Information.AdjustAmountInfo(amtOld);
                        float amtNew = float.Parse(Console.ReadLine());
                        object1[i].SetAmount(amtNew);
                    }
                }
            } else if (selected == 3){
                obj.GetStatement();
                object1.Add(obj);
                Information.AddObjectInfo(obj);
                Console.WriteLine();
                Information.PressToContinueInfo();
            }
        }
        public void SetIncomeTotalNew() {
            var incList = GetIncomeList();
            for (int i = 0; i < incList.Count; i++) {
                var amount = incList[i].GetAmount();
                _incomeStatement.SetStatementTotal(amount);
            }
        }
        public void SetExpensesTotalNew() {
            var expList = GetExpensesList();
            for (int i = 0; i < expList.Count; i++) {
                var amount = expList[i].GetAmount();
                _expenseStatement.SetStatementTotal(amount);
            }
        }
        public void DisplayGoalAndPoints() {
            var saveList = GetSavingsList();
            for (int i = 0; i < saveList.Count; i++) {
                var amount = saveList[i].GetAmount();
                _savings.SetStatementTotal(amount);
            }
            for (int i = 0; i < saveList.Count; i++) {
                var amount = saveList[i].GetAmount();
                var name = saveList[i].GetName();
                var points = ComputePoints(amount);
                Console.WriteLine($"{i+1}. Goal name: {name}, Amount:{amount} Points: {points} ---{TimeManagement.GetToday()}");
            }
        } 
        public float GetMaxAmount() {
            SetIncomeTotalNew();
            SetExpensesTotalNew();
            float surplus = GetSurplusOrDeficit(); // Returns difference between income and expenses
            var maxAmountPerGoal = surplus/6; // Due to 6 savings predetermine goals
            return maxAmountPerGoal;
        }
        public int ComputePoints(float userAmount) {
            var maxAmount = GetMaxAmount();
            var points = userAmount/maxAmount * 10; // 
            return (int) Math.Floor(points);
        }
    }
}