using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialPrudence {

    class Program {
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
                switch (prompt1) {
                    case 1:
                    // Create a new file and set income and expenses statements
                    filesHandler.CreateNewFile();
                    FilesHandler.GetInExStatements(helper);
                    break;
                    case 2:
                    // Analyze financial statements in memory
                    filesHandler.OpenAFileForUse();
                    Information.OneOrZero();
                    int x = int.Parse(Console.ReadLine());
                    if (1 == x){
                    filesHandler.ToSavingsOrDebtManagement();
                    }
                    break;
                    case 3:
                    // Adjust goals made for better financial standing
                    filesHandler.FineTuneFinancialPrudence();
                    break;
                    case 4:
                    // Load a file to memory and adjust as necessary
                    filesHandler.TemplateToObject();
                    break;
                    case 5:
                    // Display goals and points scored
                    helper.DisplayGoalAndPoints();
                    break;
                    case 6:
                    // Save an opened file automatically and quit Program
                    filesHandler.AutoSave();
                    Quit = false;
                    Animation.AnimateGoodbye();
                    break;
                }
            }
        }
    }
}