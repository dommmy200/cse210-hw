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
                    // Create a new file and set income and expenses statements
                    Program.CreateNewFile();
                    // FilesHandler.CreateNewFile(); //Note: verify why on 2nd run the 'GetTwoStatements()' is skipped
                    // Helper.GetTwoStatements();
                    // ToSavingsOrDebtManagement();
                    break;
                    case 2:
                    Console.WriteLine("OpenExistingFile");
                    // Open an existing file and Check financial profile
                    Program.OpenAnExistingFile();
                    // FilesHandler.OpenExistingFile();
                    // Helper.FineTuneFinancialPrudence();
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
       
        public static void CreateNewFile() {
            FilesHandler.CreateNewFile(); //Note: verify why on 2nd run the 'GetTwoStatements()' is skipped
            Helper.GetTwoStatements();
            
        }
        public static void OpenAnExistingFile() {
            FilesHandler.OpenAFileForUse();
            Helper.FineTuneFinancialPrudence();
        }
    }
}