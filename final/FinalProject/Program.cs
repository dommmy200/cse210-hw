using System;

namespace FinancialPrudence {

    class Program {
        static void Main(string[] args) {
            bool Quit = true;
            // Generate the menu for user selection 
            Helper helper = new Helper();
            Information info = new Information();
            info.DisplayInfo(); //Press any key to continue
            while (Quit) {
                Console.WriteLine("\n");
                info.DisplayPrompt();
                int selectedPrompt = helper.GetStartPrompt();
                helper.StartPrudenceExercise(selectedPrompt, Quit);
            }
        }
    }
}