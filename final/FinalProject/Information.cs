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
1. Delete expense item
2. Reduce expense amount
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

     Please, select 1 to 6 below:
======================================
1. Create a new file
2. Select a file
3. Adjust savings goals
4. Update selected file
5. Display points from savings
6. Quit program
";
        private static string _incomeInfo = $@"

Please, input statement name, description, 
and amount.
";
private static string _savingNotice = $@"You have a surplus and are about to make goals statement.";
private static string _noExpStatement = $@"Please, make expenses statements.";
private static string _noIncStatement = $@"Please, make income statements.";
private static string _savingsStatement = $@"You are about to make savings statements.";
private static string _surplusMade = $"You have just made a savings statement.\nYou can make adjustments in the main menu.";
private static string _successfullyCreatedNotice = $"You have successfully created a new file.\nYou may now quit to select it.";
private static string _successfullyOpenedNotice = $"You have successfully opened a file.\nYou may now quit to quit to adjust it.";
private static string _noFileOpenedNotice = $"You have no file opened.\nSelect or create a new file.";
private static string _aboutToAnalyze = $"You are about to analyze your financial profile.";
private static string _deficitNotice = $@"Your expenses are more than income. Please, consider adjusting.";
private static string _oneZero = $@"Enter 1 to add more statements or any other number not to";

        private static string _selectAnyInfo = $@"

Please, select any savings above to adjust  ";
        private static string _reduceIncreaseInfo = $@"

    Please, make a choice below:
===================================
1. Increase Income
2. Reduce Expenses
3. Quit
";
        private static string _statementInfo = $@"

    Please, make a choice below:
===================================
1. Make Income statement
2. Make Expenses statement
3. Quit
";
        private static string _pressToContinueInfo = $@"

Press any key to continue...";
        public static int ReduceOrIncreaseInfo() {
            Console.WriteLine(_reduceIncreaseInfo);
            int select = int.Parse(Console.ReadLine());
            return select;
        }
        public static int SelectStatementInfo() {
            Console.WriteLine(_statementInfo);
            int select = int.Parse(Console.ReadLine());
            return select;
        }
        public static void ReduceOrDeleteInfo() {
            Console.WriteLine(_deleteInfo);
        }
        public static void SurplusMadeInfo() {
            Console.WriteLine(_surplusMade);
        }
        public static void NoIncStatementMade() {
            Console.WriteLine(_noIncStatement);
        }
        public static void NoExpStatementMade() {
            Console.WriteLine(_noExpStatement);
        }
        public static void AboutToAnalyze() {
            Console.WriteLine(_aboutToAnalyze);
        }
        public static void OneOrZero() {
            Console.WriteLine(_oneZero);
        }
        public static void SavingsStatementInfo() {
            Console.WriteLine(_savingsStatement);
        }
        public static void SuccessfullyCreated() {
            Console.WriteLine(_successfullyCreatedNotice);
        }
        public static void NoFileOpened() {
            Console.WriteLine(_noFileOpenedNotice);
        }
        public static void SuccessfullyOpened() {
            Console.WriteLine(_successfullyOpenedNotice);
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