using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialPrudence {

    class Program {
        // Helper helper = new Helper();
        static void Main(string[] args) {
            Helper helper = new Helper();
            FilesHandler filesHandler = new FilesHandler();
            // Play animation and generate the menu for user selection
            // Animation.AnimateShapes();
            Information.DisplayInfo();
            Helper.PressToContinue();
            bool Quit = true;
            while (Quit) {
                Information.DisplayPrompt();
                var prompt1 = Helper.GetStartPrompt();
                // string prompt = Console.ReadLine();
                // int prompt1 = int.Parse(prompt);
                switch (prompt1) {
                    case 1:
                    Console.WriteLine($"CreateNewFile\n");
                    // Create a new file and set income and expenses statements
                    // CreateNewFile();
                    filesHandler.CreateNewFile(); //Note: verify why on 2nd run the 'GetTwoStatements()' is skipped
                    helper.GetTwoStatements();
                    // ToSavingsOrDebtManagement();
                    break;
                    case 2:
                    Console.WriteLine("OpenExistingFile");
                    // Open an existing file and Check financial profile
                    // OpenAnExistingFile();
                    filesHandler.OpenAFileForUse();
                    helper.FineTuneFinancialPrudence();
                    break;
                    case 3:
                    Console.WriteLine("goals setting");
                    // Check goals setting progress
                    break;
                    case 4:
                    // Quit program
                    Quit = false; // _filesHandler.QuitOrContinue();
                    break;
                }
            }
        }

        // static void CreateNewFile() {
        //     FilesHandler.CreateNewFile(); //Note: verify why on 2nd run the 'GetTwoStatements()' is skipped
        //     Helper.GetTwoStatements();
            
        // }
        // void OpenAnExistingFile() {
        //     FilesHandler.OpenAFileForUse();
        //     helper.FineTuneFinancialPrudence();
        // }
        
    
    }
}