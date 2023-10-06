using System;
using System.Diagnostics.Contracts;
using MyMainProgram.Choice1;
using MyMainProgram.Journal01;

namespace MyMainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Console.WriteLine("Welcome to the Journal Program");
            
            
            
            while (true)
            {
                // instantiate a Choice object and call the displayChoice method
                Choice ch = new();
                ch.displayChoices();

                Console.WriteLine("Please select one of the following choices: ");
                int selected = int.Parse(Console.ReadLine());
                if (selected == 1)
                {   
                    // Write entries
                    JournalFiling.WriteJournal();
                    continue;

                } else if (selected == 2){
                    
                    // Display
                    JournalFiling.DisplayJournal();
                    continue;

                } else if (selected == 3){
                    
                    // Load
                    JournalFiling.LoadFile();
                    continue;
                    
                } else if (selected == 4){
                    // Save
                    JournalFiling.SaveJournal();
                    // List<string> toSave = new();
                    // Choice saveObj = new();
                    
                    // toSave.Add(saveObj.JournalDate.ToShortDateString());
                    // toSave.Add(saveObj.Prompt);
                    // toSave.Add(saveObj.Response);

                    // List<Choice> asChoiceObj = toSave.Cast<Choice>().ToList();
                    
                    // JournalFiling.SaveJournal(asChoiceObj);
                    continue;
                } else if (selected == 5){
                    // Quit
                    System.Environment.Exit(0);
                } else {
                    // Error
                }

            }
        }
    }
}
