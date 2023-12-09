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
                    Console.WriteLine($"Create a New File\n");
                    // Create a new file and set income and expenses statements
                    filesHandler.CreateNewFile();
                    FilesHandler.GetInExStatements(helper);
                    break;
                    case 2:
                    Console.WriteLine($"Load and save file\n");
                    Console.WriteLine("Select File To View\n"); //Remove this
                    filesHandler.OpenAFileForUse();
                    // helper.FineTuneFinancialPrudence();
                    break;
                    case 3:
                    Console.WriteLine($"Goals adjustment\n");
                    filesHandler.FineTuneFinancialPrudence();
                    // var x = Information.SelectStatementInfo();
                    // FilesHandler.GetInExStatements(x, helper);
                    break;
                    case 4:
                    Console.WriteLine("Adjust Selected File\n");
                    filesHandler.TemplateToObject();
                    break;
                    case 5:
                    Console.WriteLine("Display points obtained\n");
                    helper.DisplayGoalAndPoints();
                    break;
                    case 6:
                    Console.WriteLine("Quit Program\n");
                    filesHandler.AutoSave();
                    Quit = false;
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