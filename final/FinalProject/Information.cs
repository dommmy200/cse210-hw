using System;

namespace FinancialPrudence {

    public class Information {
        private string _welcomeMsg = $@"

        Welcome to Financial Prudence where you
        get the best guide on how to set your
        financial goals and keep track of them 
        to help you enjoy all the benefits that 
        sprout out of being financially prudent.
        
        ";

        private string _startPrompts = $@"

         Please, select your 1 or 2 below:
        ===================================
        1. Start Financial Prudence exercise
        2. Assess your Financial Prudence plan 
        
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

         Please, select your 1 or 2 below:
        ===================================
        1. Enter Income Statement
        2. Enter Expenses Statement
        
        ";

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