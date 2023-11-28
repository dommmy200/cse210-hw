using System;

namespace FinancialPrudence {

    public class Information {
        private string _name;
        private string _welcomeMsg = $@"

        Welcome to Financial Prudence where you
        get the best guide on how to set your
        financial goals and keep track of them 
        to help you enjoy all the benefits that 
        sprout out of being financially prudent.
        
        ";

        private string _startPrompts = $@"

           Please, select 1,2,3 or 4 below:
        ======================================
        1. Start Financial Prudence exercise
        2. Assess your Financial Prudence plan
        3. Record Achievements
        4. Quit
        
        ";
        private string _oneOrTwo = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Annually
        2. Monthly 
        
        ";
        private string _quitOrContinue = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Continue to add statement
        2. Quit adding statement 
        
        ";
        private string _incomeStatementInfo = $@"

        Please, input income type name, description, 
        and estimated amount earned for this goal.
        
        ";
        private string _incomeExpensesInfo = $@"

             Please, select 1 or 2 below:
        ======================================
        1. Enter Income and Expenses Statement
        2. Quit
        
        ";
        private string _reduceOrIncreaseInfo = $@"

            Please, make a choice below:
        ===================================
        1. Increase Income
        2. Reduce Expenses
        3. Quit
        
        ";
        private string _reduceOrDelete = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Reduce expense amount
        2. Delete expense item
        
        ";
        public Information(string name = "User Name") {
            _name = name;
        }
        public int ReduceOrIncreaseInfo() {
            Console.WriteLine(_reduceOrIncreaseInfo);
            int select = int.Parse(Console.ReadLine());
            return select;
        }
        public void ReduceOrDeleteInfo() {
            Console.WriteLine(_reduceOrDelete);
        }
        public void DisplayInfo() {
            Console.WriteLine(_welcomeMsg);
        }
        public void QuitContinueInfo() {
            Console.WriteLine(_quitOrContinue);
        }
        public void DisplayOneTwo() {
            Console.WriteLine(_oneOrTwo);
        }
        public void DisplayPrompt() {
            Console.WriteLine(_startPrompts);
        }
        public void DisplayIncomeInfo() {
            Console.WriteLine(_incomeStatementInfo);
        }
        public void DisplayIncomeExpensesInfo() {
            Console.WriteLine(_incomeExpensesInfo);
        }

    }
}