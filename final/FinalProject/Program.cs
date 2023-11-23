using System;

namespace FinancialPrudence {

    class Program {
        static void Main(string[] args) {
            Helper helper = new Helper();
            Information info = new Information();
            info.DisplayInfo();

            Console.WriteLine("\n");
            info.DisplayPrompt();
            int selectedPrompt = helper.GetStartPrompt();
            helper.GetStatements(selectedPrompt);
        }
    }
}