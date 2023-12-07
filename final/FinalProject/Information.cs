using System;

namespace FinancialPrudence {

    public class Information {
        // private string _name;

        // public Information(string name = "User Name") {
        //     _name = name;
        // }
        private static string _mainInfo = $@"

        Welcome to Financial Prudence where you
        get the best guide on how to set your
        financial goals and keep track of them 
        to help you enjoy all the benefits that 
        sprout out of being financially prudent. ";
        private static string _quitInfo = $@"

Please, select 1 or 2 below:
=================================
1. Continue to add statement
2. Quit 
";
        private static string _deleteInfo = $@"

Please, select 1 or 2 below:
============================
1. Reduce expense amount
2. Delete expense item
";
        private static string _incExpInfo = $@"

Please, make a choice below:
============================
1. Make Income Statements
2. Make Expenses Statements
3. Quit
";
        private static string _oneTwoInfo = $@"

Please, choose the spread:
==========================
1. Annually
2. Monthly
";
        private static string _promptInfo = $@"

  Please, select 1, 2, 3 or 4 below:
======================================
1. Create a new file
2. Open an existing file
3. Set savings goals
4. Quit
";
        private static string _incomeInfo = $@"

Please, input statement name, description, 
and amount.
";
private static string _savingNotice = $@"You have a surplus and are about to make goals statement.";
private static string _deficitNotice = $@"Your expenses are more than income. Please, consider adjusting.";

        private static string _selectAnyInfo = $@"

Please, select any one above to adjust  ";
        private static string _reduceIncreaseInfo = $@"

    Please, make a choice below:
===================================
1. Increase Income
2. Reduce Expenses
3. Quit
";
        private static string _pressToContinueInfo = $@"

Press any key to continue...";
        public static int ReduceOrIncreaseInfo() {
            Console.WriteLine(_reduceIncreaseInfo);
            int select = int.Parse(Console.ReadLine());
            return select;
        }
        public static void ReduceOrDeleteInfo() {
            Console.WriteLine(_deleteInfo);
        }
        public static void SelectAnyInfo() {
            Console.WriteLine(_selectAnyInfo);
        }
        public static void SavingsNotice() {
            Console.WriteLine(_savingNotice);
        }
        public static void DeficitNotice() {
            Console.WriteLine(_deficitNotice);
        }
        public static void DisplayInfo() {
            Console.WriteLine(_mainInfo);
        }
        public static void QuitContinueInfo() {
            Console.WriteLine(_quitInfo);
        }
        public static void DisplayOneTwo() {
            Console.WriteLine(_oneTwoInfo);
        }
        public static void DisplayPrompt() {
            Console.WriteLine(_promptInfo);
        }
        public static void DisplayIncomeInfo() {
            Console.WriteLine(_incomeInfo);
        }
        public static void DisplayIncomeExpensesInfo() {
            Console.Write(_incExpInfo);
        }
        public static void PressToContinueInfo() {
            Console.Write(_pressToContinueInfo);
        }
        public static void RemoveObjectInfo(Statement obj) {
            Console.WriteLine($"{obj.GetName()} has been removed from the list of goals.");
        }
        public static void AdjustAmountInfo(float amtOld) {
        Console.Write($"Current amount is: {amtOld}. Enter new amount: ");
        }
    }
}