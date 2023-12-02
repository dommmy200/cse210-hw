using System;

namespace FinancialPrudence {

    class Program {
        static void Main(string[] args) {
            bool Quit = true;
            // Generate the menu for user selection
            Animation.AnimateShapes();
            Information.DisplayInfo();
            Helper.PressToContinue();
            while (Quit) {
                Information.DisplayPrompt();
                int prompt1 =Helper.GetStartPrompt();
                // string prompt = Console.ReadLine();
                // int prompt1 = int.Parse(prompt);
                switch (prompt1) {
                    case 1:
                    Console.WriteLine($"CreateNewFile");
                    // FilesHandler _filesHandler = new FilesHandler();
                    // Create a new file and set income and expenses statements
                    FilesHandler.CreateNewFile();
                    Helper.GetTwoStatements();
                    // ToSavingsOrDebtManagement();
                    break;
                    case 2:
                    Console.WriteLine("OpenExistingFile()");
                    // Open an existing file and Check financial profile
                    // _filesHandler.OpenExistingFile();
                    // FineTuneFPrudence();
                    break;
                    case 3:
                    Console.WriteLine("goals setting");
                    // Check goals setting progress
                    break;
                    case 4:
                    // Quit program
                    Quit = false; //_filesHandler.QuitOrContinue();
                    break;
                }
            }
        }
    }
}