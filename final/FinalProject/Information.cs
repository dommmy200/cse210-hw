using System;

namespace FinancialPrudence {

    public static class Information {
        // private string _name;

        // public Information(string name = "User Name") {
        //     _name = name;
        // }
        private static string _mainInfo = $@"

        Welcome to Financial Prudence where you
        get the best guide on how to set your
        financial goals and keep track of them 
        to help you enjoy all the benefits that 
        sprout out of being financially prudent.
        
        ";
        private static string _quitInfo = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Continue to add statement
        2. Quit 
        
        ";
        private static string _deleteInfo = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Reduce expense amount
        2. Delete expense item
        
        ";
        private static string _incExpInfo = $@"

                    Please, make a choice below:
                ===================================
                1. Make Income Statements
                2. Make Expenses Statements
                3. Quit
                
                ";
        private static string _oneTwoInfo = $@"

              Is this amount entered:
        ===================================
        1. Annually
        2. Monthly 
        
        ";
        private static string _promptInfo = $@"

          Please, select 1, 2, 3 or 4 below:
        ======================================
        1. Create a new file
        2. Open an existing file
        3. Set savings goals
        4. Quit";
        private static string _incomeInfo = $@"

        Please, input income type name, description, 
        and estimated amount earned for this goal.
        
        ";
        private static string _incomeExpenseInfo = $@"

        Please, input income type name, description, 
        and estimated amount earned for this goal.
        
        ";
        private static string _reduceIncreaseInfo = $@"

            Please, make a choice below:
        ===================================
        1. Increase Income
        2. Reduce Expenses
        3. Quit
        
        ";
        private static string _pressToContinueInfo = $@"

        Press any key to continue...
        
        ";
        public static int ReduceOrIncreaseInfo() {
            Console.WriteLine(_reduceIncreaseInfo);
            int select = int.Parse(Console.ReadLine());
            return select;
        }
        public static void ReduceOrDeleteInfo() {
            Console.WriteLine(_deleteInfo);
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
            Console.WriteLine(_incExpInfo);
        }
        public static void PressToContinueInfo() {
            Console.WriteLine(_pressToContinueInfo);
        }
    }
}